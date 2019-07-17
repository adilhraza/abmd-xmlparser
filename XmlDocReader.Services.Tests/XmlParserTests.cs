using System.IO;
using System.Xml;
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
        public void XmlParser_FileFoundButInvalidXml_ThrowXmlException()
        {
            var parser = new XmlParser();

            Assert.Throws<XmlException>(() => parser.ReadRefText("c:\\invalid-file.xml", "CAR"));
        }

        [Test]
        public void XmlParser_XmlFileNotExists_ThrowFileNotFoundException()
        {
            var parser = new XmlParser();

            Assert.Throws<FileNotFoundException>(() => parser.ReadRefText("c:\\not-found.xml", "CAR"));
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

            var res = parser.ReadRefText("c:\\file.xml", "MWB");
            
            Assert.AreEqual(res.Length, 9);
        }
    }
}