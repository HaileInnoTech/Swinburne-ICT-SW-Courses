#include <SPI.h>
#include <MFRC522.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include <Servo.h>
// include libraries

#define SS_PIN 10// define signal pin for rfid
#define RST_PIN 9 // define pin for rfid

MFRC522 rfid(SS_PIN, RST_PIN);  //create object for rfid
Servo myservo;  //create object for servo
LiquidCrystal_I2C lcd(0x27, 16, 2); // replace with your LCD's I2C address and dimensions

byte uid[4];
void setup() {
  // Initialize the serial connection
  pinMode(4,OUTPUT);      //green led on for system works
  digitalWrite(4,HIGH);


  Serial.begin(9600);  //initial for serial wrie
  SPI.begin();
  rfid.PCD_Init();

  myservo.attach(6); // signal pin for servo
  myservo.write(0);

  lcd.init(); // display string on lcd
  lcd.backlight();
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("RFID Servo Lock");
  lcd.setCursor(0, 1);
  lcd.print("Scan to unlock");
}

void loop() {
  if (rfid.PICC_IsNewCardPresent() && rfid.PICC_ReadCardSerial()) {//scan the card for id
      Serial.print("RFID card ID: ");
     
      for (int i = 0; i < 4; i++) { //format the id in hexa deciaml
        uid[i] = rfid.uid.uidByte[i];
        Serial.print(rfid.uid.uidByte[i], HEX);
        Serial.print(" ");
      }
           Serial.println(); //serial print for edge 
           delay(1000);

  }
// Read any incoming messages from the serial connection
      if (Serial.available()>0) {
        String message = Serial.readStringUntil('\n');

        // If the message is "granted", activate the servo
        if (message == "GRANTED") {         //  edge sends back granted card
          Serial.println("Status: Granted");
          nhay_xanh();
          lcd.clear();
          lcd.setCursor(0, 0);
          lcd.print("Status: Granted");
          lcd.setCursor(0, 1);
          lcd.print("Opening lock");
          myservo.write(180);       //servo activate to unlock
          delay(1000);
          lcd.clear();
          lcd.setCursor(0, 0);
          lcd.print("Lock opened");
          lcd.setCursor(0, 1);
          lcd.print("Wait to lock");    
          delay(5000);
          myservo.write(0);       //after 5s lock again
          lcd.clear();
          lcd.setCursor(0, 0);
          lcd.print("Lock closed");
          lcd.setCursor(0, 1);
          lcd.print("Scan to unlock");
        }
        else if (message == "DENIED"){ //  edge sends back denied card
          Serial.println("Status: Denial");
          nhay_do();
          lcd.clear();
          lcd.setCursor(0, 0);
          lcd.print("Status: Denial");
          lcd.setCursor(0, 1);
          lcd.print("Please try again");
          delay(2000);
          lcd.clear();
          lcd.setCursor(0, 0);
          lcd.print("RFID Servo Lock");
          lcd.setCursor(0, 1);
          lcd.print("Scan to unlock");
        }
      }

}

void nhay_xanh(){       //function if card is granted blink the green led 
   digitalWrite(4, LOW); 
    delay(500); // wait for 1 second
  digitalWrite(4, HIGH); 
  delay(500); 
    digitalWrite(4, LOW); 
      delay(500); 
        digitalWrite(4, HIGH); 


}

void nhay_do(){   //function if card is denied blink the red led
digitalWrite(3, HIGH); 
    delay(500); // wait for 1 second
  digitalWrite(3, LOW); 
  delay(500); 
  digitalWrite(3, HIGH); 
    delay(500); // wait for 1 second
  digitalWrite(3, LOW); 
  
}