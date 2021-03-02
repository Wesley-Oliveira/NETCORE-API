using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UfEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Uf { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        IEnumerable<CityEntity> Cities { get; set; }
    }
}