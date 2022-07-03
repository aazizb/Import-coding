using Contract.Models;

using Repository;

namespace Service
{
    public class ImportDataService
    {
        public static List<YamlProduct> GetYamlProducts(string fileContent)
        {
            IList<YamlProduct> data = ImportDataRepository.GetYamlProducts(fileContent);

            return data.ToList();
        }
        public static List<JsonProduct> GetJsonProducts(string fileContent)
        {
            IList<JsonProduct> data = ImportDataRepository.GetJsonProducts(fileContent);

            return data.ToList();
        }

    }
}