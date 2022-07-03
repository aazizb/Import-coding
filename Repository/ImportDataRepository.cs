using Contract.Models;

using System.Text.Json;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Repository
{
    public class ImportDataRepository
    {
        public static List<JsonProduct> GetJsonProducts(string jsonContent)
        {
            List<JsonProduct> jsons = new();
            JsonProducts jsonProducts =  (JsonProducts)JsonSerializer.Deserialize(jsonContent, typeof(JsonProducts),
                         new JsonSerializerOptions()
                         {
                             PropertyNameCaseInsensitive = true
                         });
            foreach (JsonProduct product in jsonProducts.Products)
            {
                JsonProduct json = new()
                {
                    Categories= product.Categories.Select(s=>s.ToString()).ToList(),
                    Twitter = product.Twitter,
                    Title = product.Title
                };
                jsons.Add(json);
            }      
            return jsons;
        }
        public static IList<YamlProduct> GetYamlProducts(string fileContent)
        {
            //do not distinguish lowercase and uppercase
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            IList<YamlProduct> results = deserializer.Deserialize<IList<YamlProduct>>(fileContent).ToList();
            return results;
        }
    }
}