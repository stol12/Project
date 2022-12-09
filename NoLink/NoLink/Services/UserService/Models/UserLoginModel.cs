namespace NoLink.Services.UserService.Models
{
    using System.ComponentModel.DataAnnotations;
    using static NoLink.Data.DataConstants.User;
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
