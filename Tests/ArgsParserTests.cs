using CommandPromptArgs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ArgsParserTests
    {
        [TestMethod]
        public void CountTest()
        {
            var parser = new ArgsParser();
            string[] args = { "arg1", "arg2:value2", "arg3" };

            parser.Parse(args);

            Assert.AreEqual(3, parser.Count);
        }

        [TestMethod]
        public void GetValuesByNameTest()
        {
            var parser = new ArgsParser();
            string[] args = { "arg1", "arg2:value2", "arg3 = value3" };

            parser.Parse(args);

            Assert.AreEqual("arg1", parser.GetValue("arg1"));
            Assert.AreEqual("value2", parser.GetValue("arg2"));
            Assert.AreEqual("value3", parser.GetValue("arg3"));
        }

        [TestMethod]
        public void GetValuesByIndexTest()
        {
            var parser = new ArgsParser();
            string[] args = { "arg1", "arg2:value2", "arg3 = value3" };

            parser.Parse(args);

            Assert.AreEqual("arg1", parser.GetValue(0));
            Assert.AreEqual("value2", parser.GetValue(1));
            Assert.AreEqual("value3", parser.GetValue(2));
        }
    }
}
