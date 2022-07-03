namespace Contract.Models
{

    public class JsonProducts
    {
        public List<JsonProduct>? Products { get; set; }
    }

    public class JsonProduct
    {
        public IList<string>? Categories { get; set; }
        public string? Twitter { get; set; }
        public string? Title { get; set; }
    }
}
