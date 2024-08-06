namespace TravelAgency.Data;

public static class DataConstraints
{
    public const byte CustomerFullNameMinLength = 4;
    public const byte CustomerFullNameMaxLength = 60;
    public const byte CustomerEmailMinLength = 6;
    public const byte CustomerEmailMaxLength = 50;
    public const byte CustomerPhoneNumberLength = 13;
    public const string CustomerPhoneNumberRegex = @"^\+[0-9]{12}$";

    public const byte GuideFullNameMinLength = 4;
    public const byte GuideFullNameMaxLength = 60;

    public const byte TourPackageNameMinLength = 2;
    public const byte TourPackageNameMaxLength = 40;
    public const byte TourPackageDescriptionMaxLength = 200;
    public const byte TourPackagePriceMinRange = 0;
    public const int TourPackagePriceMaxRange = int.MaxValue;
    //[Range(0, int.MaxValue)]

}