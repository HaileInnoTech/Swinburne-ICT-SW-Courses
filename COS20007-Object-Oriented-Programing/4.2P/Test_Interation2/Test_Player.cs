using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swin_Adventure;
using NUnit.Framework;
namespace Test_Interation2
{
    [TestFixture()]
    public class Test_Player
    {  
        I2_Player  _player = new I2_Player("Hai", "Player 1");
        I2_Item _weapon = new I2_Item(new string[] { "Gun" }, "Mp5", "tachtachtachtach");
        I2_Item _shield = new I2_Item(new string[] { "Shield" }, "Doran Shield", "item in lol");

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.True(_player.AreYou("me"));
            Assert.True(_player.AreYou("inventory"));
        }
        [Test]

        public void TestPlayerLocatesItems()
        {
            _player.Inventory.Take(_weapon);
            _player.Inventory.Take(_shield);

            Assert.That(_player.Locate("Gun"), Is.SameAs(_weapon));
            Assert.That(_player.Locate("Shield"), Is.SameAs(_shield));

        }
        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.That(_player.Locate("me"), Is.SameAs(_player));
        }
        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.That(_player.Locate("Nothing"), Is.EqualTo(null));
        }
        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.That(
                _player.full_Description, Is.EqualTo("You are Hai Player 1\nYou are carrying:\n\tSubmachine gun (weapon)\n\tDoran shield (shield)"));
        }
    }
}
