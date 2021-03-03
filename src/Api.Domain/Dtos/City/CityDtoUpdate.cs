using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.City
{
    public class CityDtoUpdate
    {
        [Required(ErrorMessage = "Id is required.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(60, ErrorMessage = "Max is 60 characters")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "CodIBGE invalid.")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Uf code is required.")]
        public Guid UfId { get; set; }
    }
}