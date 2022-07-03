using Contract.Models;

using Repository;

namespace Service
{
    public class ImportDataService
    {
        public static List<YamlProduct> GetYamlProducts(string file)
        {
            IList<YamlProduct> data = ImportDataRepository.GetYamlProducts(file);

            return data.ToList();
        }
        public static JsonProduct GetJsonProducts(string file)
        {
            JsonProduct data = ImportDataRepository.GetJsonProducts(file);

            return data;
        }

    }
}