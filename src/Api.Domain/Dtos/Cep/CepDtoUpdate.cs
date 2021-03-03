using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoUpdate
    {
        [Required(ErrorMessage = "Id is required.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP is required.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; }

        public string Number { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public Guid CityId { get; set; }
    }
}