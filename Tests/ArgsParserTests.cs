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
        public void GetValuesByNameWithDifferentRegisterTest()
        {
            var parser = new ArgsParser();
            string[] args = { "arg1", "aRg2:value2", "ARG3 = value3" };

            parser.Parse(args);

            Assert.AreEqual("arg1", parser.GetValue("ARG1"));
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

        [TestMethod]
        public void GetBoolValueTest()
        {
            var parser = new ArgsParser();
            string[] args = {"arg1:true", "arg2=false"};

            parser.Parse(args);

            Assert.IsTrue(parser.GetBoolValue("arg1"));
            Assert.IsFalse(parser.GetBoolValue("arg2"));
        }

        [TestMethod]
        public void GetIntValueTest()
        {
            var parser = new ArgsParser();
            string[] args = { "arg1:1" };

            parser.Parse(args);

            Assert.AreEqual(1, parser.GetIntValue("arg1"));
        }

        [TestMethod]
        public void IsSpecifiedTest()
        {
            var parser = new ArgsParser();
            string[] args = {"arg1"};

            parser.Parse(args);

            Assert.IsTrue(parser.IsSpecified("arg1"));
            Assert.IsFalse(parser.IsSpecified("arg2"));
        }
    }
}
