namespace ASPCoreFirstApp.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PriceString { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Tax { get; set; }

        public ProductDTO(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            PriceString = string.Format("{0:C}", price);
            Description = description;
            ShortDescription = description.Length <= 25 ? description : description.Substring(0, 25);
            Tax = price * 0.08M;
        }

        // alternate format- instead of asking for four separate values, we can pass in a single product model

        public ProductDTO(ProductModel p)
        {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            PriceString = string.Format("{0:C}", p.Price);
            Description = p.Description;
            ShortDescription = p.Description.Length <= 25 ? p.Description : p.Description.Substring(0, 25);
            Tax = p.Price * 0.08M;
        }
    }
}
