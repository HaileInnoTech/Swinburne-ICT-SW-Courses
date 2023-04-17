public class Mainclass
{
    public static void Main(string[] args)
    {
        Counter_Task.Counter[] mycounters = new Counter_Task.Counter[3];
        mycounters[0] = new Counter_Task.Counter("Counter 1");
        mycounters[1] = new Counter_Task.Counter("Counter 2");
        mycounters[2] = mycounters[0];

        for(int i = 0; i < 3; i++)
        {
            mycounters[0].Increasement();
        }
        for (int i = 0; i < 9; i++)
        {
            mycounters[1].Increasement();
        }

        Printcounter(mycounters);

        mycounters[2].Reset();
        Printcounter(mycounters);
    }
    private static void Printcounter(Counter_Task.Counter[] counters)
    {
        foreach(var c in counters)
        {
            Console.WriteLine("{0} is {1} ", c.Name, c.Tick.ToString() );
        }
    }

   
}