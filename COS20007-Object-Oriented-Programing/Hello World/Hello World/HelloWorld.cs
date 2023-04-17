using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hello_World
{
    internal class HelloWorld
    {
        private const string V = "Chris";

        static void Main(string[] args)
        {
            Message mymessage;
            mymessage = new Message("Hello - From the Message Object");

            mymessage.Print();
            Message[] array = new Message[4];

            array[0] = new Message("Welcome back oh great educator");
            array[1] = new Message("What a lovely name");
            array[2] = new Message("Great name");
            array[3] = new Message("This is a silly name");
         

            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

             name = name.ToLower();
           
            switch (name)
            {
                case "chris":
                    array[0].Print();
                    break;
                case "fred":
                    array[1].Print();
                    break;
                case "wilma":
                    array[2].Print();
                    break;
                default:    
                    array[3].Print();
                    break;
            }
            Console.ReadLine();
        }
    }
}
