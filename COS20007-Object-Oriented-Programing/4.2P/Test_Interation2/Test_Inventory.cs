using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swin_Adventure;
using NUnit.Framework;

namespace Test_Interation2
{

    public class Test_Inventory
    {
        private I2_Inventory _inventory;
        private I2_Item _item;

        [SetUp]
        public void Setup()
        {
            _inventory = new I2_Inventory();
            string[] idents = {"Mp5"};
            _item = new I2_Item(idents, "this is a submachine gun", "tachtachtachtach");
        }
        [Test]
        public void TestFindItem()
        {
            _inventory.Take(_item);
            Assert.True(_inventory.CarryItem("mp5"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.False(_inventory.CarryItem(""));
        }


        [Test]
        public void TestFetchItem()
        {
            _inventory.Take(_item);
            Assert.AreEqual(_item, _inventory.Find("Mp5"));
        }


        [Test]
        public void TestTakeItem()
        {
            _inventory.Take(_item);
            _inventory.Find("Mp5");
            Assert.False(_inventory.CarryItem("BFG"));
        }
        [Test]
        public void TestItemList()
        {
            string[] gun = { "Weapon", "Mp5", "Submachine gun" };
            I2_Item weapon = new I2_Item(gun, "Submachine gun", "this is for tsting");

            string[] shield = { "shield", "Doran", "Doran shiel" };
            I2_Item armour = new I2_Item(shield, "Doran shield", "An item in LOL");

           


            _inventory.Take(weapon);
            _inventory.Take(armour);
         
            string expected = "\n\tSubmachine gun (weapon)\n\tDoran shield (shield)";

            Assert.That(_inventory.Items, Is.EqualTo(expected));

        }
    }
}
