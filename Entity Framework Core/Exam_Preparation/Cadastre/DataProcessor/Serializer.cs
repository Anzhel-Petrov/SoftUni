using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;
using JSON_XML_Extensions;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Where(p => p.DateOfAcquisition >= new DateTime(2000, 01, 01))
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    p.PropertyIdentifier,
                    p.Area,
                    p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens.Select(ps => new
                        {
                            ps.Citizen.LastName,
                            ps.Citizen.MaritalStatus
                        })
                        .OrderBy(ps => ps.LastName)
                        .ToArray()
                })
                .ToArray();

            var json = properties.SerializationToJson();

            return json;
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            ExportLargePropertyDto[] properties = dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportLargePropertyDto()
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PostalCode = p.District.PostalCode
                })
                .ToArray();

            //StringBuilder sb = new StringBuilder();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLargePropertyDto[]), new XmlRootAttribute("Properties"));
            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(string.Empty, string.Empty);

            //using StringWriter writer = new StringWriter(sb);
            //xmlSerializer.Serialize(writer, properties, namespaces);

            //return sb.ToString().TrimEnd();

            return properties.SerializeToXml("Properties");
        }
    }
}
