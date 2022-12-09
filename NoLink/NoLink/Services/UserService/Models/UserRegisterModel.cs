namespace NoLink.Services.UserService.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.User;
    public class UserRegisterModel
    {

        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        [RegularExpression("([A-z0-9]+)", ErrorMessage = "Username is not in the correct format")]
        public string UserName { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not in the correct format")]
        public string Email { get; set; }

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [RegularExpression("[A-z0-9!@#$%^&*()_]{8,}", ErrorMessage = "Think of a stronger password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match, Try again! ")]
        public string ConfirmPassword { get; set; }
    }
}
