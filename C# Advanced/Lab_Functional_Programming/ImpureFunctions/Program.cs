namespace ImpureFunctions;

class Program
{
    static void Main(string[] args)
    {
        decimal price = decimal.Parse(Console.ReadLine());
        Console.WriteLine($"Discounted price is: {GetPromotionsImpure(price)}");
        Console.WriteLine($"Discounted price is: {GetPromotionsPure(price, new DateTime(2024, 9, 27))}");
    }
    
    private static decimal GetPromotionsImpure(decimal price)
    {
        if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
        {
            price *= 0.8m;
        }

        if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
        {
            price *= 0.9m;
        }
            
        if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
        {
            price *= 0.3m;
        }
            
        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
        {
            price *= 0.4m;
        }
            
        if (DateTime.Now.Year == 2028)
        {
            price *= 0.9m;
        }

        return price;
    }

    private static decimal GetPromotionsPure(decimal price, DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Tuesday)
        {
            price *= 0.8m;
        }

        if (date.DayOfWeek == DayOfWeek.Wednesday)
        {
            price *= 0.9m;
        }
            
        if (date.DayOfWeek == DayOfWeek.Friday)
        {
            price *= 0.3m;
        }
            
        if (date.DayOfWeek == DayOfWeek.Sunday)
        {
            price *= 0.4m;
        }
            
        if (date.Year == 2028)
        {
            price *= 0.9m;
        }

        return price;
    }
}