using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ImportCustomerDto[] customerDtos = xmlString.DeserializeFromXml<ImportCustomerDto[]>("Customers");
            List<Customer> customersToAdd = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                if (customersToAdd.Any(c => c.FullName == customerDto.FullName || c.Email == customerDto.Email || c.PhoneNumber == customerDto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new Customer()
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber
                };

                customersToAdd.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.Customers.AddRange(customersToAdd);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportBookingDto[] bookingDtos = jsonString.DeserializeFromJson<ImportBookingDto[]>();
            List<Booking> bookingsToAdd = new List<Booking>();

            foreach (var bookingDto in bookingDtos)
            {
                bool isValidBookingDate = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validBookingDate);

                if (!IsValid(bookingDto) || !isValidBookingDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customer = context.Customers.SingleOrDefault(c => c.FullName == bookingDto.CustomerName)!;
                TourPackage tourPackage = new TourPackage()
                {
                    PackageName = bookingDto.TourPackageName,
                };

                Booking booking = new Booking()
                {
                    BookingDate = validBookingDate,
                    Customer = customer,
                    CustomerId = customer.Id,
                    TourPackage = tourPackage
                };

                bookingsToAdd.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, booking.TourPackage.PackageName,
                    booking.BookingDate.ToString("yyyy-MM-dd")));
            }

            context.Bookings.AddRange(bookingsToAdd);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
