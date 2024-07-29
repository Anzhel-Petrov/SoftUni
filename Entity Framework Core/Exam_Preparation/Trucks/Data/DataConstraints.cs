namespace Trucks.Data;

public static class DataConstraints
{
    public const byte TruckRegistrationNumberLength = 8;
    public const string TruckRegistrationNumberRegex = @"^[A-Z]{2}\d{4}[A-Z]{2}$";
    public const byte TruckVinNumberLength = 17;
    public const int TruckTankCapacityMinRange = 950;
    public const int TruckTankCapacityMaxRange = 1420;
    public const int TruckCargoCapacityMinRange = 5000;
    public const int TruckCargoCapacityMaxRange = 29000;

    public const byte ClientNameMinLength = 4;
    public const byte ClientNameMaxLength = 40;
    public const byte ClientNationalityMinLength = 2;
    public const byte ClientNationalityMaxLength = 40;
    public const string ClientTypeRegex = @"^(^usual)$";

    public const byte DespatcherNameMinLength = 2;
    public const byte DespatcherNameMaxLength = 40;

}