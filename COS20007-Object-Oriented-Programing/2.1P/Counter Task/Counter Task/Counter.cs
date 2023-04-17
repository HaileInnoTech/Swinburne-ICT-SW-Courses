using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Task
{
    internal class Counter
    {
        private int _count;
        private string _name;

        public Counter(string name)
        {
            _name = name;
            _count = 0;

        }

        public void Increasement()
        { 
            _count++;
        }
        public void Reset()
        {
            _count= 0;
        }

        public string Name
        {
            get{ 
            return _name;
            }
            set { 
                _name = value;  
            }
        }
        public int Tick
        {
            get { return _count; }
        }
    }
}
