namespace WebApi.Data
{
    public class Product
    {
        public Product()
        {

        }
        public Product(string name,decimal price,string brand)
        {
            Name = name;
            Price = price;
            Brand = brand;
        }
        
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set;}        
    }
}
