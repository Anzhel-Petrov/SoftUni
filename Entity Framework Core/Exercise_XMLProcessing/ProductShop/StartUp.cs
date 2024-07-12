using ProductShop.Data;
using System.Xml.Serialization;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();

            string users = File.ReadAllText("../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(context, users));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
            var deserializedUsers = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml))!;

            //context.Users.AddRange(deserializedUsers);
            return "";
        }
    }
}