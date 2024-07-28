namespace Medicines.Data;

public static class DataConstraints
{
    public const byte PharmacyNameMinLength = 2;
    public const byte PharmacyNameMaxLength = 50;
    public const byte PharmacyPhoneLength = 14;
    public const string PharmacyBooleanRegex = @"^(true|false)$";
    public const string PharmacyPhoneNumberRegex = @"^\([0-9]{3}\)\ [0-9]{3}\-[0-9]{4}$";
    // ^\(\d{3}\)\ \d{3}\-\d{4}$

    public const byte MedicineNameMinLength = 3;
    public const byte MedicineNameMaxLength = 150;
    public const decimal MedicinePriceMinRange = 0.01m;
    public const decimal MedicinePriceMaxRange = 1000.00m;
    public const byte MedicineProducerMinLength = 3;
    public const byte MedicineProducerMaxLength = 100;

    public const byte PatientFullNameMinLength = 5;
    public const byte PatientFullNameMaxLength = 100;
}