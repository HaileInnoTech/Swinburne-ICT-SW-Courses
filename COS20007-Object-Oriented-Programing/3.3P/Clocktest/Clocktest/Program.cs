using System;

namespace Clocktest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                Clock timeKeeper = new Clock();
                for (int i = 0; i < 60 * 60 * 24; i++)
                {
                    Console.WriteLine(timeKeeper.ReadTime);
                    timeKeeper.Tick();
                }
            
        }
    }
}
