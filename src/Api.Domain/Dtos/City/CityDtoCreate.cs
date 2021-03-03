using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.City
{
    public class CityDtoCreate
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(60, ErrorMessage = "Max is 60 characters")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "CodIBGE invalid.")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Uf code is required.")]
        public Guid UfId { get; set; }
    }
}