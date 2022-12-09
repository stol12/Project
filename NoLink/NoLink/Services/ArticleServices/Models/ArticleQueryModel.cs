namespace NoLink.Services.ArticleServices.Models
{
    using NoLink.Data;
    public class ArticleQueryModel : IArticleModel
    {
        public const int ArticlesPerPage = 6;
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public User Author { get; set; }
        public IEnumerable<FormFile> Files { get; set; } = new List<FormFile>();
        public IEnumerable<Article> Articles { get; set; } = new List<Article>();
        public string FileContent { get; set; }
    }
}
