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
    public class CounterTest
    {
        [Test()]
        public void testStartsZero()
        {
            Counter c = new Counter("hopeitcorrect?");
            Assert.AreEqual(0, c.Count);
        }


        [Test()]
        public void testIncrement()
        {
            Counter c = new Counter("hopeitcorrect?");
            int previousValue = c.Count;
            int newValue = previousValue + 1;
            c.Increasement();
            Assert.AreEqual(newValue, c.Count);

        }
         [Test()]
        public void testMultipleIncreasement()
            {
                Counter c = new Counter("hopeitcorrect?");

                int previousValue = c.Count;
                int newValue = previousValue + 10;
                for (int i = 0; i < newValue; i++)
                {
                    c.Increasement();

                }
                Assert.AreEqual(newValue, c.Count);
            }
        [Test]
        public void TestCounterReset()
        {
            Counter c = new Counter("hopeitcorrect?");
            c.Increasement();
            c.Reset();
            Assert.AreEqual(0, c.Count);
        }
    }
    }
