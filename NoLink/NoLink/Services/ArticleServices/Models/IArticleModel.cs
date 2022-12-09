namespace NoLink.Services.ArticleServices.Models
{
    using NoLink.Data;
    public interface IArticleModel
    {
        string Id { get; set; }
        string Title { get; set; }
        string Text { get; set; }
        DateTime DateAdded { get; set; }
        User Author { get; set; }
        string FileContent { get; set; }
    }
}
