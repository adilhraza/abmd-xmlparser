using System;
using System.IO;
using System.Xml;

namespace XmlDocReader.Services.Impl
{
    public class XmlParser : IXmlParser
    {
        public string ReadRefText(string filePath, string refCode)
        {
            if (string.IsNullOrWhiteSpace(filePath) ||
                string.IsNullOrWhiteSpace(refCode))
            {
                return string.Empty;
            }

            string refText = "";

            try
            {
                using (var reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        if (reader.HasAttributes && reader.GetAttribute("RefCode") == refCode)
                        {
                            reader.ReadToFollowing("RefText");
                            refText = reader.ReadInnerXml();
                        }
                    }
                }
            }
            catch (XmlException e)
            {
                // log to logger utility
                Console.WriteLine(e);
                throw;
            }
            catch (FileNotFoundException e)
            {
                // log to logger utility
                Console.WriteLine(e);
                throw;
            }
            
            return refText;
        }
    }
}