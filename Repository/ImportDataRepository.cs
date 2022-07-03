using Contract.Models;

using System.Net.Http.Json;
using System.Text.Json;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Repository
{
    public class ImportDataRepository
    {
        private static string ReadFileContent(string fileFullPath)
        {
            using (StreamReader file = new StreamReader(fileFullPath))
            {
                return file.ReadToEnd();
            }
        }
        public static JsonProduct GetJsonProducts(string jsonContent)
        {
            var xx = (JsonProduct)JsonSerializer.Deserialize(jsonContent, typeof(JsonProduct),
                         new JsonSerializerOptions()
                         {
                             PropertyNameCaseInsensitive = true
                         });
            return (JsonProduct)JsonSerializer.Deserialize(jsonContent, typeof(JsonProduct),
                         new JsonSerializerOptions()
                         {
                             PropertyNameCaseInsensitive = true
                         });
        }
        public static IList<YamlProduct> GetYamlProducts(string file)
        {
            //do not distinguish lowercase and uppercase
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            IList<YamlProduct> results = deserializer.Deserialize<IList<YamlProduct>>(file).ToList();
            return results;
        }
    }
}