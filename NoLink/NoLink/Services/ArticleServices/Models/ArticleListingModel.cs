namespace NoLink.Services.ArticleServices.Models
{
    using NoLink.Data;
    using System.ComponentModel.DataAnnotations;

    public class ArticleListingModel
    {
        public List<ArticleQueryModel> Articles { get; set; } = new List<ArticleQueryModel>();

        public const int ArticlesPerPage = 6;
        public int CurrentPage { get; set; } = 1;

    }
}
