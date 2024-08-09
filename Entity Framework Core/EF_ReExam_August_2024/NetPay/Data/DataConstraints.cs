namespace NetPay.Data;

public class DataConstraints
{
    public const byte HouseholdContactPersonMinLength = 5;
    public const byte HouseholdContactPersonMaxLength = 50;
    public const byte HouseholdEmailMinLength = 6;
    public const byte HouseholdEmailMaxLength = 80;
    public const byte HouseholdPhoneNumberLength = 15;
    public const string HouseHoldPhoneNumberRegex = @"^\+\d{3}/\d{3}-\d{6}$";

    public const byte ExpenseNameMinLength = 5;
    public const byte ExpenseNameMaxLength = 50;
    public const decimal ExpenseAmountMinRange = 0.01m;
    public const decimal ExpenseAmountMaxRange = 100_000;

    public const byte ServiceNameMinLength = 5;
    public const byte ServiceNameNameMaxLength = 30;

    public const byte SupplierNameMinLength = 3;
    public const byte SupplierNameMaxLength = 60;

    //public const byte TourPackagePriceMinRange = 0;
    //public const int TourPackagePriceMaxRange = int.MaxValue;
    //[Range(0, int.MaxValue)]
    // ^\+[0-9]{3}\/[0-9]{3}\-[0-9]{6}$
    // ^\+\d{3}\/\d{3}\-\d{6}$
}