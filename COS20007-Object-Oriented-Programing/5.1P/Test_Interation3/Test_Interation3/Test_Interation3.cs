using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swin_Adventure;
using NUnit.Framework;

namespace Test_Interation3
{
    [TestFixture()]
    public class Test_Interation3
    {
        I2_Item _weapon = new I2_Item(new string[] { "Gun" }, "Mp5", "tachtachtachtach");
        I2_Item _shield = new I2_Item(new string[] { "Shield" }, "Doran Shield", "item in lol");

        I3_Bag bag = new I3_Bag(new string[] { "uselessbag" }, "Bag", "This bag cant carry anything");

        [Test()]
        public void TestBagLocatesItems()
        {
            bag.Inventory.Take(_shield);

            Assert.That(_shield, Is.EqualTo(bag.Locate(_shield.FirstId())));
            Assert.IsTrue(bag.Inventory.CarryItem(_shield.FirstId()));
        }


        [Test()]
        public void TestBagLocatesItself()
        {
            Assert.That(bag, Is.EqualTo(bag.Locate(bag.FirstId())));

        }
        [Test()]
        public void TestBagLocatesNothing()
        {
            Assert.That(null, Is.EqualTo(bag.Locate("sadfasdfsdafasdf")));

        }


        [Test()]
        public void TestFullDescription()
        {

            bag.Inventory.Take(_weapon);
            bag.Inventory.Take(_shield);

            Assert.That($"In the {bag.Name} you can see:\n\t{_weapon.Name} ({_weapon.FirstId()})" +"\n\t" +$"{_shield.Name} ({_shield.FirstId()})", Is.EqualTo(bag.full_Description));
        }

    }
}
