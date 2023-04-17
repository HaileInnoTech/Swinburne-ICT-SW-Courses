#!/usr/bin/env python3
import serial
import MySQLdb
import time
device = '/dev/ttyACM0'

ser = serial.Serial(device, 9600, timeout=1)
ser.reset_input_buffer()

valid_id = ['D2 6C 83 20']  #list of valid ID
access_status ="Granted"

class DatabaseConnection:  # class implement to prevent error when send data to database 
    def __init__(self,host,user, password,db):
        self.host = host

        self.user = user
        
        self.password = password
                
        self.db = db
                        
        self.conn = None
    def __enter__(self):
        self.conn = MySQLdb.connect(
            host=self.host,
            user = self.user,
            password=self.password,
            db=self.db
            )
        return self.conn.cursor()
    def __exit__(self,exc_type,exc_val,exc_tb):
        if self.conn:
            self.conn.commit()
            self.conn.close()


while True:
        
    if ser.in_waiting > 0:
        rfid_line = ser.readline().decode('utf-8').rstrip() #read the serial monitor from Arduino
                                
        if rfid_line.startswith('RFID card ID:'):		# format string to get oly cardID
            rfid_id = rfid_line.split(': ')[1]
            if rfid_id in valid_id:
                ser.write(b"GRANTED\n")				# if ID in the valid id list send a message back to Arduino to activate servo
                access_status = "Granted"
                print('RFID card ID: ' + rfid_id + ', Access status: ' + access_status)  
            else:
                ser.write(b"DENIED\n")				# if ID in the valid id list send a message back to Arduino 
                access_status = "Denied"
                print('RFID card ID: ' + rfid_id + ', Access status: ' + access_status)
                
        with DatabaseConnection('localhost','pi','','rfic_db') as cursor:    #connect to the database set up before
            insert_query = "INSERT INTO doorLog (cardID, status) VALUES (%s ,%s)"		#SQL string to insert data in the table
            val1 = rfid_id
            val2 = access_status
            values = (val1,val2)
            cursor.execute(insert_query, values)					#execute SQL on the server 
            cursor.close;
            





        
        
