using NUnit.Framework;
using XmlDocReader.Services.Impl;

namespace XmlDocReader.Services.Tests
{
    [TestFixture]
    public class XmlParserTests
    {
        [Test]
        public void XmlParser_RefCodeParamIsEmpty_ReturnEmptyString()
        {
            var parser = new XmlParser();

            var res = parser.ReadRefText("c:\\file.xml", "");
            
            Assert.IsEmpty(res);
        }

        [Test]
        public void XmlParser_FilePathParamIsEmpty_ReturnEmptyString()
        {
            var parser = new XmlParser();

            var res = parser.ReadRefText("", "CAR");
            
            Assert.IsEmpty(res);
        }

        [Test]
        public void XmlParser_XmlFileNotExists_ReturnNull()
        {
            var parser = new XmlParser();

            var res = parser.ReadRefText("c:\\invalid-file.xml", "CAR");
            
            Assert.IsNull(res);
        }

        [Test]
        public void XmlParser_RefCodeNotFound_ReturnEmptyString()
        {
            var parser = new XmlParser();

            var res = parser.ReadRefText("c:\\file.xml", "BLAH");
            
            Assert.IsEmpty(res);
        }

        [Test]
        public void XmlParser_XmlFileReadOkAndRefCodeFound_ReturnRefText()
        {
            var parser = new XmlParser();

            var res = parser.ReadRefText("c:\\file.xml", "CAR");
            
            Assert.AreEqual(res, "71Q0019681");
        }
    }
}