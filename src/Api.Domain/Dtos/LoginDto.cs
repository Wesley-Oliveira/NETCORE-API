using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid mail format.")]
        [StringLength(100, ErrorMessage = "Max length is {1}.")]
        public string Email { get; set; }
    }
}