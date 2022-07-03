using Contract.Dtos;
using Contract.Models;

using System.Collections.Generic;
using System.Linq;

namespace Import.DataAdapter
{
    public static class JsonDataAdapter
    {
        public static List<JsonProductDto> BoToDto(this List<JsonProduct> jsonProducts)
        {
            if (jsonProducts is null)
            {
                return null;
            }
            
            List<JsonProductDto> dtos = new();
            foreach (JsonProduct item in jsonProducts)
            {
                JsonProductDto dto = new()
                {
                    Categories = item.Categories.Select(s=>s.ToString()).ToList(),
                    Twitter = item.Twitter,
                    Title = item.Title
                };
                dtos.Add(dto);
            }
            return dtos;
        }
        public static List<JsonProduct> DtoToBo(this List<JsonProductDto> jsonProductDto)
        {
            if (jsonProductDto is null)
            {
                return null;
            }
            List<JsonProduct> dtos = new();
            foreach (JsonProductDto item in jsonProductDto)
            {
                JsonProduct dto = new()
                {
                    Categories = item.Categories,
                    Twitter = item.Twitter,
                    Title = item.Title
                };
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
