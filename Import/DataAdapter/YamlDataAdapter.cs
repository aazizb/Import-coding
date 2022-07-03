using Contract.Dtos;
using Contract.Models;

using System.Collections.Generic;

namespace Import.DataAdapter
{
    public static class YamlDataAdapter
    {
        public static List<YamlProductDto> BoToDto(this List<YamlProduct> yamlProducts)
        {
            if (yamlProducts is null)
            {
                return null;
            }
            List<YamlProductDto> yamlProductDtos = new();
            foreach (YamlProduct item in yamlProducts)
            {
                YamlProductDto dto = new()
                {
                    Tags = item.Tags,
                    Twitter = item.Twitter,
                    Name = item.Name
                };
                yamlProductDtos.Add(dto);
            }
            return yamlProductDtos;
        }
        public static List<YamlProduct> DtoToBo(this List<YamlProductDto> yamlProductDto)
        {
            if (yamlProductDto is null)
            {
                return null;
            }
            List<YamlProduct> yamlProducts = new();
            foreach (YamlProductDto item in yamlProductDto)
            {
                YamlProduct dto = new()
                {
                    Tags = item.Tags,
                    Twitter = item.Twitter,
                    Name = item.Name
                };
                yamlProducts.Add(dto);
            }
            return yamlProducts;
        }
    }
}
