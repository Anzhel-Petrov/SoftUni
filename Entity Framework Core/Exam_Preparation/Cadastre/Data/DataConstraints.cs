namespace Cadastre.Data;

public static class DataConstraints
{
    // District
    public const byte DistrictNameMinLength = 2;
    public const byte DistrictNameMaxLength = 80;
    public const byte PostalCodeLength = 8;
    public const string DistrictPostalCodeRegexExpression = @"^[A-Z]{2}\-[0-9]{5}";

    //Property
    public const byte PropertyIdentifierMinLength = 16;
    public const byte PropertyIdentifierMaxLength = 80;
    public const byte AreaMinRange = 0;
    public const int AreaMaxRange = int.MaxValue;
    public const byte DetailsMinLength = 5;
    public const ushort DetailsMaxLength = 500;
    public const byte AddressMinLength = 5;
    public const byte AddressMaxLength = 200;

    //Citizen
    public const byte CitizenFirstNameMinLength = 2;
    public const byte CitizenFirstNameMaxLength = 30;
    public const byte CitizenLastNameMinLength = 2;
    public const byte CitizenLastNameMaxLength = 30;
}