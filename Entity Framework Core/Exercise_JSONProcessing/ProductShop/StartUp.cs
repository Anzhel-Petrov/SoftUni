using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var users = File.ReadAllText("../../../Datasets/users.json");
            var products = File.ReadAllText("../../../Datasets/products.json");
            var categories = File.ReadAllText("../../../Datasets/categories.json");
            var categoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportUsers(context, users));
            //Console.WriteLine(ImportProducts(context, products));
            //Console.WriteLine(ImportCategories(context, categories));
            //Console.WriteLine(ImportCategoryProducts(context, categoryProducts));
            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        // Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson)!;
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";
        }

        // Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson)!;
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Length}";
        }

        // Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)!;
            Category[] nonNullCategories = categories.Where(c => c.Name is not null).ToArray();
            context.Categories.AddRange(nonNullCategories);
            context.SaveChanges();
            return $"Successfully imported {nonNullCategories.Length}";
        }

        // Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)!;
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Length}";
        }

        // Query 5. Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .OrderBy(p => p.price)
                .AsEnumerable();

            var json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return json;
        }

        // Query 5. Export Products in Range
        public static string GetSoldProducts(ProductShopContext context)
        {
            var solidProducts = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName
                    })
                    .AsEnumerable()
                })
                .AsEnumerable();

            var json = JsonConvert.SerializeObject(solidProducts, Formatting.Indented);

            return json;
        }

        // Query 7. Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductCount = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .OrderByDescending(c => c.productsCount)
                .AsEnumerable();

            var json = JsonConvert.SerializeObject(categoriesByProductCount, Formatting.Indented);

            return json;
        }

        // Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId.HasValue && ps.Price != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = u.ProductsSold
                        .Where(ps => ps.BuyerId.HasValue && ps.Price != null)
                        .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price
                        })
                        .AsEnumerable()
                })
                .OrderByDescending(u => u.soldProducts.Count())
                .AsEnumerable();

            //var output = new
            //{
            //    userCount = usersWithSoldProducts.Count(),
            //    users = usersWithSoldProducts.Select(u => new
            //    {
            //        u.firstName
            //    })
            //};

            var json = JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented);

            return json;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();
            ICollection<string> foo = new List<string>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}