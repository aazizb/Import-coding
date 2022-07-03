using Contract.Dtos;

namespace Contract
{
    public interface IImportData
    {
        T ImportCsv<T>(string url);
        T ImportJson<T>(string jsonFile);
        IList<YamlProductDto> ImportJaml(string yamlFile);
    }
}