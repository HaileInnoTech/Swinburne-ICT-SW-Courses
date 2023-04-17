using System;


namespace Swin_Adventure
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Swin Adventure");
            Console.WriteLine("What is your name adventurer?");
            string name = Console.ReadLine();

            Console.WriteLine("Describce yourself.");
            string desc = Console.ReadLine();

            I2_Player me = new I2_Player(name, desc);


            I2_Item sword = new I2_Item(new string[] { "weapon1" }, "sword", "Rusty Sword");

            I2_Item helmet = new I2_Item(new string[] { "armor1" }, "helmet", "Paper Helmet");


            me.Inventory.Take(sword);
            me.Inventory.Take(helmet);

            I3_Bag balo = new I3_Bag(new string[] { "bag" }, "balo", "Beginning balo");

            me.Inventory.Take(balo);

            I2_Item shoes = new I2_Item(new string[] { "shoes" }, "Jordan1", "beginning sneaker");

            balo.Inventory.Take(shoes);

            I4_Look_Command look = new I4_Look_Command();

            string command;
            bool ongoing = true;
            while (ongoing)
            {
                Console.Write("Command: ");
                command = Console.ReadLine();
                if (command.ToLower() != "end")
                {
                    Console.WriteLine(look.Execute(me, command.Split()));
                }
                else
                {
                    Console.WriteLine("Exiting...");
                    ongoing = false;
                }
            }

        }

    }
}

