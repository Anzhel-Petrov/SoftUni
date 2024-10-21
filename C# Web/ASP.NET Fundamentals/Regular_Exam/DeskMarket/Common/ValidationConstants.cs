namespace DeskMarket.Common;

public static class ValidationConstants
{
    //Product
    public const int ProductNameMinLength = 2;
    public const int ProductNameMaxLength = 60;
    public const int ProductDescriptionMinLength = 10;
    public const int ProductDescriptionMaxLength = 250;
    public const decimal ProductPriceMinRange = 1.00m;
    public const decimal ProductPriceMaxRange = 3000.00m;
    public const string ProductAddedOnFormat = "dd-MM-yyyy";
    public const string ProductAddedOnRegex = @"^\d{2}-\d{2}-\d{4}$";

    //Category
    public const int CategoryNameMinLength = 3;
    public const int CategoryNameMaxLength = 20;
}