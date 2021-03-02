using System;

namespace Api.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        public int CodIBGE { get; set; }
        public string Name { get; set; }
        public Guid UfId { get; set; }
        public UfEntity Uf { get; set; }
    }
}