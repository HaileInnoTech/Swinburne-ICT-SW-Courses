using NUnit.Framework;
using Swin_Adventure;

namespace Interation6
{
    [TestFixture()]
    public class LocationTests
    {
        private I6_Location _river;
        private I2_Item _sword;
        private I2_Player _me;

        [SetUp()]
        public void Init()
        {
            _river = new I6_Location(new string[] { "location","river" }, "Sai gon river", "a river in sai gon city");
            _sword = new I2_Item(new string[] { "weapon1","_sword" }, "sword", "Rusty Sword"); 
            _me = new I2_Player("Hai Le", "wassup");
        }

        [TestCase()]
        public void LocationIdentifyItself()
        {

            Assert.That(_river, Is.EqualTo(_river.Locate("river")));
        }
        [TestCase()]
        public void LocationCanLocateItems()
        {
            _river.Inventory.Take(_sword);

            Assert.That(_sword, Is.EqualTo(_river.Locate("_sword")));
        }
        [TestCase()]
        public void PlayerCanLocateItemsInTheirLocation()
        {
            _river.Inventory.Take(_sword); 

            _me.Location = _river; 


            Assert.That(_sword, Is.EqualTo(_me.Locate("_sword")));
        }
        [TestCase()]
        public void PlayersCanLocateTheirLocation()
        {
            _me.Location = _river;
            Assert.That(_river, Is.EqualTo(_me.Locate("location")));
        }
    }
}