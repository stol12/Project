namespace NoLink.Data
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Article;
    public class Article
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(TextMaxLength, MinimumLength = TextMinLength)]
        public string Text { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public IEnumerable<FormFile>? Files { get; set; } = new List<FormFile>();
    }
}
