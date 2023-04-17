using NUnit.Framework;
using Swin_Adventure;
namespace Test_Interation2
{
    public class Test_Item
    {
        
        [Test]
        public void Test_Item_Identifiable()
        {
            I2_Item potion = new I2_Item(new string[] { "potion" }, "potion", "energy potion");
            Assert.IsTrue(potion.AreYou("Potion"));
        }
        [Test()]
        public void ShortDescription()
        {
            I2_Item potion = new I2_Item(new string[] { "potion" }, "potion", "energy potion");

            Assert.That("potion (potion)", Is.EqualTo(potion.short_Description));

        }


        [Test()]
        public void LongDescription()
        {
            I2_Item potion = new I2_Item(new string[] { "potion" }, "potion", "energy potion");
            Assert.That("energy potion", Is.EqualTo(potion.full_Description));
        }
    }
}