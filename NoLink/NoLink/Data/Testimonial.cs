namespace NoLink.Data
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Testimonial;
    public class Testimonial
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(TextMaxLength, MinimumLength = TextMinLength)]
        public string Text { get; set; }        
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
