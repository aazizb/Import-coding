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

    }
}