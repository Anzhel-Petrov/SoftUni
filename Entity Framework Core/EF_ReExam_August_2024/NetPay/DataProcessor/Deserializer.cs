using Castle.Core.Resource;
using NetPay.Data;
using NetPay.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using NetPay.Data.Models;
using NetPay.DataProcessor.ImportDtos;
using System.Globalization;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using System.Linq;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ImportHouseholdDto[] householdsDtos = xmlString.DeserializeFromXml<ImportHouseholdDto[]>("Households");
            List<Household> householdsToAdd = new List<Household>();

            foreach (var householdDto in householdsDtos)
            {
                if (!IsValid(householdDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (householdsToAdd.Any(hh => hh.ContactPerson == householdDto.ContactPerson)
                    || householdsToAdd.Any(hh => hh.Email == householdDto.Email)
                    || householdsToAdd.Any(hh => hh.PhoneNumber == householdDto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                householdsToAdd.Add(new Household()
                {
                    ContactPerson = householdDto.ContactPerson,
                    Email = householdDto.Email,
                    PhoneNumber = householdDto.PhoneNumber,
                });

                sb.AppendLine(string.Format(SuccessfullyImportedHousehold, householdDto.ContactPerson));
            }

            context.Households.AddRange(householdsToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportExpenseDto[] expencesDtos = jsonString.DeserializeFromJson<ImportExpenseDto[]>();
            List<Expense> expencesToAdd = new List<Expense>();

            foreach (var expenseDto in expencesDtos)
            {
                bool isValidDueDate = DateTime.TryParseExact(expenseDto.DueDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDueDate);

                bool isValidPaymentStatus =
                    Enum.TryParse(expenseDto.PaymentStatus, true, out PaymentStatus validPaymentStatus);

                if (!IsValid(expenseDto)
                    || !isValidDueDate
                    || !isValidPaymentStatus)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //List<int> validHouseholdIds = context.Households.Select(h => h.Id).ToList();
                //List<int> validServiceIds = context.Services.Select(s => s.Id).ToList();

                //if (!validServiceIds.Contains(expenseDto.ServiceId)
                //    || !validHouseholdIds.Contains(expenseDto.ServiceId))
                //{
                //    sb.AppendLine(ErrorMessage);
                //    continue;
                //}

                if (!context.Households.Any(hh => hh.Id == expenseDto.HouseholdId)
                    || !context.Services.Any(s => s.Id == expenseDto.ServiceId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                expencesToAdd.Add(new Expense()
                {
                    ExpenseName = expenseDto.ExpenseName,
                    Amount = expenseDto.Amount,
                    DueDate = validDueDate,
                    PaymentStatus = validPaymentStatus,
                    HouseholdId = expenseDto.HouseholdId,
                    ServiceId = expenseDto.ServiceId
                });

                sb.AppendLine(string.Format(SuccessfullyImportedExpense, expenseDto.ExpenseName, expenseDto.Amount.ToString("F2")));
            }

            context.Expenses.AddRange(expencesToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
