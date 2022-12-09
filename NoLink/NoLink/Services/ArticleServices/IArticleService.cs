namespace NoLink.Services.ArticleServices
{
    using NoLink.Data;
    using NoLink.Services.ArticleServices.Models;
    public interface IArticleService
    {
        ArticleListingModel Articles();
        ArticleListingModel FilterArticles(string searchString);
        Article? ArticleById(string id);
        ArticleQueryModel? GetArticleDetails(string id);

    }
}
