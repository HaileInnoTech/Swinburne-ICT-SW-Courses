using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocktest
{
    public class Clock
    {
        private Counter minute;
        private Counter second;
        private Counter hours;

        public Clock()
        {
            minute = new Counter("minutes");
            second = new Counter("seconds");
            hours = new Counter("hours");

        }

        public void Reset()
        {
            minute.Reset();
            second.Reset();
            hours.Reset();
        }
        public string ReadTime
        {    get
            {
                return $"{hours.Count:00}:{minute.Count:00}:{second.Count:00}";
            }

        }
        public void Tick()
        {
            if (second.Count < 59)
            {
                second.Increasement();
            }
            else
            {
                second.Reset();
                if(minute.Count < 59)
                {
                    minute.Increasement();
                }
                else
                {
                    minute.Reset();
                    if(hours.Count == 23)
                    {
                        hours.Reset();
                    }
                    else
                    {
                        hours.Increasement();
                    }
                }
            }
        }

    }
}
