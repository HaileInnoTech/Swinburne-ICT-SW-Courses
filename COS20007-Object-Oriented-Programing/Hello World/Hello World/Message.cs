using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class Message
    {
        private string text;
        public Message(string text)
        {
            this.text = text;
        }
        public void Print()
        {
            Console.WriteLine(text);
        }
    }
}
