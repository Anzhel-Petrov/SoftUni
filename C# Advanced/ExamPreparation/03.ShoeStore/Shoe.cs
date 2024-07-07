namespace _03.ShoeStore
{
    public class Shoe
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
        public string Material { get; set; }

        public Shoe(string brand, string type, string material)
        {
            this.Brand = brand;
            this.Type = type;
            this.Material = material;
        }

        public override string ToString()
        {
            return $"Size {Size}, {Material} {Brand} {Type} shoe.";
        }
    }
}
