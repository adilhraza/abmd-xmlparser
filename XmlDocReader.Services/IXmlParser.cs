namespace XmlDocReader.Services
{
    public interface IXmlParser
    {
        string ReadRefText(string filePath, string refCode);
    }
}