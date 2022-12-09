namespace NoLink.Services.ArticleServices
{
    using NoLink.Data;
    using NoLink.Services.ArticleServices.Models;
    using System.Collections.Generic;

    public class ArticleService : IArticleService
    {
        private readonly Context data;
        private int articlesPerPage = 6;
        private int currentPage = 1;
        public ArticleService(Context data)
        {
            this.data = data;
        }

        public ArticleListingModel FilterArticles(string searchString)
        {
            var article = new ArticleListingModel
            {
                Articles = this.data.Articles
                        .Where(a => a.Title.Contains(searchString) || a.Text.Contains(searchString))
                        .Select(a => new ArticleQueryModel
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Author = a.Author,
                            Files = a.Files.Where(f => f.ArticleId == a.Id).ToList()
                        })
                        .ToList()
            };

            return article;
        } 
        
    

        public Article? ArticleById(string id)
            => this.data.Articles
            .Where(a => a.Id == id)
            .FirstOrDefault();

        public ArticleQueryModel? GetArticleDetails(string id)
            => this.data.Articles.Where(a => a.Id == id)
            .Select(a => new ArticleQueryModel
            {
                Id = a.Id,
                Title = a.Title,
                Text = a.Text,
                FileContent = a.Files.FirstOrDefault(f => f.ArticleId == id).FileContent
            })
            .FirstOrDefault();
         
        public ArticleListingModel Articles()
        {
            var article = new ArticleListingModel
            {
                Articles = this.data.Articles
                                    .Select(a => new ArticleQueryModel
                                    {
                                        Id = a.Id,
                                        Title = a.Title,
                                        Author = a.Author,
                                        Files = a.Files.Where(f => f.ArticleId == a.Id).ToList()
                                    })
                                    .ToList()

            };


            return article;
        }
    }
}
