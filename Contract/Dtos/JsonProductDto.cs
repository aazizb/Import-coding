namespace Contract.Dtos
{
    public class JsonProductDto
    {
        public List<Product>? Products { get; set; }
    }

    public class Product
    {
        public IList<string>? Categories { get; set; }
        public string? Twitter { get; set; }
        public string? Title { get; set; }
    }
}
