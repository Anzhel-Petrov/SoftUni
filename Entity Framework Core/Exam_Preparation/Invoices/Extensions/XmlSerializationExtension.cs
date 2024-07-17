using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Invoices.Extensions;

public static class XmlSerializationExtension
{
    public static T DeserializeFromXml<T>(this string inputXml, string rootName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));
        
        using StringReader reader = new StringReader(inputXml);
        T resultDto = (T)xmlSerializer.Deserialize(reader)!;

        return resultDto;
    }
    
    public static IEnumerable<T> DeserializeXmlCollection<T>(this string inputXml, string rootName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(rootName));

        using StringReader reader = new StringReader(inputXml);
        T[] resultDto = (T[])xmlSerializer.Deserialize(reader)!;

        return resultDto;
    }
    
    public static string SerializeToXml<T>(this T dto, string xmlRootAttribute, bool omitXmlDeclaration = false, bool indent = true)
    {
        XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

        StringBuilder stringBuilder = new StringBuilder();

        XmlWriterSettings settings = new XmlWriterSettings()
        {
            OmitXmlDeclaration = omitXmlDeclaration,
            Encoding = Encoding.UTF8,
            Indent = indent
        };

        using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
        using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            try
            {
                xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
            }
            catch (Exception)
            {

                throw;
            }
        }

        return stringBuilder.ToString();
    }

    public static string SerializeToXmlStream<T>(this T obj, string xmlRootAttribute)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        string result = null;

        using (MemoryStream ms = new MemoryStream())
        {
            xmlSerializer.Serialize(ms, obj, namespaces);

            result = Encoding.UTF8.GetString(ms.ToArray());
        }

        return result;
    }
    
    public static string SerializeToXmlWriter<T>(this T obj, string xmlRootAttribute, bool omitXmlDeclaration = true, bool indent = true)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
        
        XmlWriterSettings settings = new XmlWriterSettings()
        {
            OmitXmlDeclaration = omitXmlDeclaration,
            Encoding = new UTF8Encoding(false),
            Indent = indent
        };

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        string result = null;

        using MemoryStream ms = new MemoryStream();
        using XmlWriter writer = XmlWriter.Create(ms, settings);
        xmlSerializer.Serialize(writer, obj, namespaces);
        
        return Encoding.UTF8.GetString(ms.ToArray());
    }
}