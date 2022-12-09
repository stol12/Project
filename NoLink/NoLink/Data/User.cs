namespace NoLink.Data
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;
    public class User : IdentityUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = "Username must be between 3 and 50 characters long!")]
        [RegularExpression("([A-z0-9]+)", ErrorMessage = "Username is not in the correct format!")]
        public override string UserName { get; set; }

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not in the correct format")]
        public override string Email { get; set; }

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [RegularExpression("[A-z0-9!@#$%^&*()_]{8,}")]
        public string Password { get; set; }
        public DateTime RegisteredOn { get; set; } = DateTime.UtcNow;
        public IEnumerable<Article> Articles { get; set; } = new List<Article>();
        public IEnumerable<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
    }
}
