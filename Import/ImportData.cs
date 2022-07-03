
using Contract;
using Contract.Dtos;
using Contract.Models;      ///

using Import.DataAdapter;

using Service;

using System.Collections.Generic;

namespace Import
{
    class ImportData : IImportData
    {
        public T ImportCsv<T>(string url)
        {
            throw new System.NotImplementedException();
        }

        public IList<YamlProductDto> ImportJaml(string yamlFile)
        {

            List<YamlProductDto> data = ImportDataService.GetYamlProducts(yamlFile).BoToDto();
                                                         
            return data;
  
        }

        public JsonProductDto ImportJson(string jsonFile)
        {
            return null;
        }
    }
}
