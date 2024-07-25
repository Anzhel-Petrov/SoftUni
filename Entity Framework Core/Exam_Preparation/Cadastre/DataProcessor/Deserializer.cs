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
                //bool isValidRegion = Enum.TryParse(districtDto.Region, ignoreCase: true, out Region validRegion);

                if (!IsValid(districtDto) || dbContext.Districts.Any(d => d.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District districtToAdd = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region), districtDto.Region)
                    //Region = validRegion
                };

                foreach (var propertyDto in districtDto.Properties)
                {
                    bool isValidDate = DateTime.TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime validDateOfAcquisition);


                    if (!IsValid(propertyDto)
                        || dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || districtToAdd.Properties.Any(dp => dp.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || dbContext.Properties.Any(p => p.Address == propertyDto.Address) 
                        || districtToAdd.Properties.Any(dp => dp.Address == propertyDto.Address)
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
            StringBuilder sb = new StringBuilder();
            ImportCitizenDto[] citizenDtos = jsonDocument.DeserializeFromJson<ImportCitizenDto[]>();
            List<Citizen> validCitizens = new List<Citizen>();

            foreach (var citizenDto in citizenDtos)
            {
                bool isValidBirthDate = DateTime.TryParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validBirthDate);
                //bool isValidMaritalStatus = Enum.TryParse(citizenDto.MaritalStatus, ignoreCase: true,
                //    out MaritalStatus validMaritalStatus);

                if (!IsValid(citizenDto) || !isValidBirthDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Citizen citizenToAdd = new Citizen()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = validBirthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizenDto.MaritalStatus)
                };

                foreach (var propertyId in citizenDto.Properties)
                {
                    citizenToAdd.PropertiesCitizens.Add(new PropertyCitizen()
                    {
                        PropertyId = propertyId,
                        Citizen = citizenToAdd
                    });
                }

                validCitizens.Add(citizenToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizenToAdd.FirstName, citizenToAdd.LastName,
                    citizenToAdd.PropertiesCitizens.Count));
            }

            dbContext.Citizens.AddRange(validCitizens);
            dbContext.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
