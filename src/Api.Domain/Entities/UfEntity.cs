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
        public string Nome { get; set; }
    }
}