using NUnit.Framework;
using Swin_Adventure;

namespace Test_Interation4
{
    public class Tests
    {
        [TestFixture()]
        public class Test_Interation4
        {
            I4_Look_Command look = new I4_Look_Command();
            I2_Player me = new I2_Player("Hai", "handsome");

            I2_Item _gem = new I2_Item(new string[] { "Gem" }, "Emerald", "This gem has no value");
            I2_Item _weapon = new I2_Item(new string[] { "Gun" }, "Mp5", "tachtachtachtach");
            I2_Item _shield = new I2_Item(new string[] { "Shield" }, "Doran Shield", "item in lol");
            I3_Bag bag = new I3_Bag(new string[] { "Bag" }, "UselessBag", "This bag cant carry anything");

            [Test()]
            public void TestLookAtMe()
            {
                I2_Player me = new I2_Player("Hai", "handsome");
                Assert.That(look.Execute(me, new string[] { "look", "at", "inventory" }), Is.EqualTo("You are Hai handsome\nYou are carrying:"));
            }

            [Test()]
            public void TestLookAtGem()
            {
                me.Inventory.Take(_gem);
                Assert.That(_gem.full_Description, Is.EqualTo(look.Execute(me, new string[] { "look", "at", "gem" })));
            }
            [Test()]
            public void TestLookAtUnk()
            {
                Assert.That(look.Execute(me, new string[] { "look", "at", "gem" }), Is.EqualTo("I can't find the gem"));
            }

            [Test()]
            public void TestLookAtGeminMe()
            {
                me.Inventory.Take(_gem);
                Assert.That(_gem.full_Description, Is.EqualTo(look.Execute(me, new string[] { "look", "at", "gem", "in", "inventory" })));
            }

            [Test()]
            public void TestLookAtGeminBag()
            {
                bag.Inventory.Take(_gem);
                me.Inventory.Take(bag);
                Assert.That(_gem.full_Description, Is.EqualTo(look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" })));
            }

            [Test()]
            public void TestLookAtGeminNoBag()
            {   
                me.Inventory.Take(_gem);
                Assert.That(look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I can't find the bag"));
            }

            [Test()]
            public void TestLookAtGemInNoGeminBag()
            {
                me.Inventory.Take(bag);
                Assert.That(look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I can't find the gem"));
            }
            [Test()]
            public void TestInvalidLook()
            {
                me.Inventory.Take(bag);
                Assert.That(look.Execute(me, new string[] { "Look around", "at", "a", "at", "b" }), Is.EqualTo("Error in look input."));
            }
        }
    }
}