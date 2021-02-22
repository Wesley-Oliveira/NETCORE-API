using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(60, ErrorMessage = "Max length is {1}.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid mail format.")]
        [StringLength(100, ErrorMessage = "Max length is {1}.")]
        public string Email { get; set; }
    }
}