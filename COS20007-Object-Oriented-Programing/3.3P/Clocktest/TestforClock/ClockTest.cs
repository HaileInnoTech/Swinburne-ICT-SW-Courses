using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clocktest;

namespace TestforClock
{
    [TestFixture()]
    public class ClockTest
    {
        [Test()]
        public void testTimeInitial()
        {
             Clock c = new Clock();
        
                string time = c.ReadTime;
                Assert.AreEqual("00:00:00", time);
            
        }
        [Test]
        public void testticktohour()
        {
            Clock c = new Clock();

            for (int i = 0; i < 3600; i++)
            {

                c.Tick();
            }
            Assert.AreEqual("01:00:00", c.ReadTime);
        }


    }
}

