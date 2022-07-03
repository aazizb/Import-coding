using Contract.Dtos;

namespace Contract
{
    public interface IImportData
    {
        T ImportCsv<T>(string url);
        JsonProductDto ImportJson(string jsonFile);
        IList<YamlProductDto> ImportJaml(string yamlFile);
    }
}