using Contract.Models;

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
        private static IList<T> DeserializeYaml<T>(string yamlContent)
        {
            //do not distinguish lowercase and uppercase
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            IList<T> results = deserializer.Deserialize<IList<T>>(yamlContent);
            return results;
        }
        public static IList<YamlProduct> GetYamlProducts(string file)
        {
            //do not distinguish lowercase and uppercase
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            IList<YamlProduct> results = deserializer.Deserialize<IList<YamlProduct>>(file).ToList();
            return results;

            //var fileContent = ReadFileContent(file);

            //List<YamlProduct> yaml = DeserializeYaml<YamlProduct>(fileContent).ToList<YamlProduct>();

            //return yaml;

        }
    }
}