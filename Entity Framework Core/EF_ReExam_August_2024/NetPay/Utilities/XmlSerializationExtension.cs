using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NetPay.Utilities;

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

    /// <summary>
    /// Deserialize XML to DTOs (Data Transfer Objects).
    /// </summary>
    /// <typeparam name="T">Type of object to deserialize into.</typeparam>
    /// <param name="inputXml">XML string to deserialize.</param>
    /// <param name="rootName">Root element name of the XML.</param>
    /// <returns>Deserialized object of type T, or default value if deserialization fails.</returns>
    /// <exception cref="ArgumentNullException">Thrown if obj or rootName is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the serialization fails.</exception>
    public static T Deserialize<T>(string inputXml, string rootName)
    {
        if (string.IsNullOrEmpty(inputXml))
            throw new ArgumentException("Input XML cannot be null or empty.", nameof(inputXml));

        if (string.IsNullOrEmpty(rootName))
            throw new ArgumentException("Root name cannot be null or empty.", nameof(rootName));

        try
        {
            XmlRootAttribute xmlRoot = new(rootName);
            XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

            using var reader = new StringReader(inputXml);
            return (T)xmlSerializer.Deserialize(reader);
        }
        catch (XmlException ex)
        {
            Debug.WriteLine(ex);
            throw new InvalidOperationException("XML deserialization failed.", ex);
        }
        catch (InvalidOperationException ex)
        {
            Debug.WriteLine(ex);
            throw new InvalidOperationException($"{typeof(T)} deserialization failed.", ex);
        }
    }


    /// <summary>
    /// Serializes an object of type T to an XML string.
    /// </summary>
    /// <typeparam name="T">The type of object to serialize.</typeparam>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="rootName">The root element name for the XML.</param>
    /// <param name="omitXmlDeclaration">If true, omits the XML declaration from the output.</param>
    /// <returns>A string representing the serialized XML.</returns>
    /// <exception cref="ArgumentNullException">Thrown if obj or rootName is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the serialization fails.</exception>
    public static string Serialize<T>(T obj, string rootName, bool omitXmlDeclaration = false)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj), "Object to serialize cannot be null.");

        if (string.IsNullOrEmpty(rootName))
            throw new ArgumentNullException(nameof(rootName), "Root name cannot be null or empty.");

        try
        {
            XmlRootAttribute xmlRoot = new(rootName);
            XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

            XmlSerializerNamespaces namespaces = new();
            namespaces.Add(string.Empty, string.Empty);

            XmlWriterSettings settings = new()
            {
                OmitXmlDeclaration = omitXmlDeclaration,
                Indent = true
            };

            StringBuilder sb = new();
            using var stringWriter = new StringWriter(sb);
            using var xmlWriter = XmlWriter.Create(stringWriter, settings);

            xmlSerializer.Serialize(xmlWriter, obj, namespaces);
            return sb.ToString().TrimEnd();
        }
        catch (InvalidOperationException ex)
        {
            Debug.WriteLine($"Serialization error: {ex.Message}");
            throw new InvalidOperationException($"Serializing {typeof(T)} failed.", ex);
        }
    }
}