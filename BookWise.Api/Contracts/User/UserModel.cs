using System.ComponentModel.DataAnnotations;

namespace BookWise.Api.Contracts.User
{
    public record UserModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
