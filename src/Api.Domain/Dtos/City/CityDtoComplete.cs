using System;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.City
{
    public class CityDtoComplete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }
        public UfDto Uf { get; set; }
    }
}