using System.Globalization;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using JSON_XML_Extensions;

namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder sb = new StringBuilder();
            ImportDistrictDto[] importDistrictDtos =
                xmlDocument.DeserializeFromXml<ImportDistrictDto[]>("Districts");
            List<District> validDistricts = new List<District>();

            foreach (var districtDto in importDistrictDtos)    
            {
                if (!IsValid(districtDto) || dbContext.Districts.Any(d => d.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District districtToAdd = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = districtDto.Region
                };

                foreach (var propertyDto in districtDto.Properties)
                {
                    bool isValidDate = DateTime.TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime validDateOfAcquisition);

                        
                    if (!IsValid(propertyDto)
                        || dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || dbContext.Properties.Any(p => p.Address == propertyDto.Address)
                        || !isValidDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    districtToAdd.Properties.Add(new Property()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = validDateOfAcquisition
                    });
                }
                validDistricts.Add(districtToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, districtToAdd.Name,
                    districtToAdd.Properties.Count));
            }

            dbContext.Districts.AddRange(validDistricts);
            dbContext.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
