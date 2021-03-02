using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        public int CodIBGE { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        public Guid UfId { get; set; }
        public UfEntity Uf { get; set; }

        public IEnumerable<CepEntity> Ceps { get; set; }
    }
}