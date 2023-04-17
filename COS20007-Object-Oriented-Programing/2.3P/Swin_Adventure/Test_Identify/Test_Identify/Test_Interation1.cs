using NUnit.Framework;
using Swin_Adventure;

namespace Test_Identify
{
    public class Test_Interation1
    {
        [Test]
        public void Test_AreYou()
        {
            Interation1 id = new Interation1(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
        }
        [Test]
        public void TestNotAreYou()
        {
            Interation1 id = new Interation1(new string[] { "fred", "bob" });
            Assert.IsFalse(id.AreYou("wilma"));
            Assert.IsFalse(id.AreYou("boby"));
            
        }
        [Test]
        public void TestCaseSensitive()
        {
            Interation1 id = new Interation1(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("FRED"));
            Assert.IsTrue(id.AreYou("BOB"));
        }
        [Test]
        public void TestFirstID()
        {
            Interation1 id = new Interation1(new string[] { "fred", "bob" });
            Assert.IsTrue(id.FirstId == "fred");
        }
        [Test]
        public void TestAddID()
        {
            Interation1 id = new Interation1(new string[] { "fred", "bob" });
            id.AddIdentidfier("wilma");
            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
            Assert.IsTrue(id.AreYou("wilma"));
        }
    }
}