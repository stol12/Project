namespace NoLink.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NoLink.Data;
    using NoLink.Services.ArticleServices;
    using NoLink.Services.ArticleServices.Models;
    using NoLink.Services.FormFIleServices;
    using System.Security.Claims;

    public class ArticlesController : Controller
    {
        private readonly IArticleService services;
        private readonly IFormFileService fileServices;
        private readonly UserManager<User> userManager;
        private readonly Context data;
        public ArticlesController(IFormFileService fileservices, IArticleService services, UserManager<User> userManager, Context data)
        {
            this.services = services;
            this.userManager = userManager;
            this.data = data;
            this.fileServices = fileservices;
        }
        public IActionResult Index()
        {
            var articles = this.services.Articles();
            return View(articles);
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var articles = this.services.FilterArticles(searchString);
            return View(articles);
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddArticle(AddArticleFormModel model)
        {
            // TODO reduce code amount by separating it into a partial view

            var username = this.User.FindFirstValue(ClaimTypes.Name);
            var userId = this.data.Users
                .Where(u => u.UserName == username)
                .Select(u => u.Id)
                .First();
            
            var author = this.data.Users.Where(u => u.Id == userId).FirstOrDefault();
            var file = fileServices.ImplementFile("No description", model.FileContent, model.Id);
            var files = new List<FormFile>();

            files.Add(file);

            if (author != null)
            {
                var article = new Article
                {
                    Title = model.Title,  
                    Text = model.Text,
                    AuthorId = userId,
                    Files = files
                };

                file = this.fileServices.EstablishArticleRelationship(file, article.Id);
            
                if(!this.data.Articles.Any(a => a.Id == article.Id) && !this.data.Files.Any(f => f.ArticleId == article.Id))
                {
                    this.data.Articles.Add(article);
                    this.data.Files.Add(file);
                    this.data.SaveChanges();
                }
            }
            return RedirectToAction(nameof(ArticlesController.Index), "Articles");
        }
        public IActionResult DeleteArticle(string id)
        {
            var article = this.services.ArticleById(id);
            
            if(article != null && this.data.Articles.Any(a => a == article))
            {
                var articleImageToRemove = this.data.Files.Where(f => f.ArticleId == article.Id).FirstOrDefault();

                this.data.Files.Remove(articleImageToRemove);
                this.data.Articles.Remove(article);
                this.data.SaveChanges();

                return RedirectToAction(nameof(ArticlesController.Index), "Articles");
            }

            throw new InvalidOperationException("Such article was not found");
        }

        public IActionResult Details(string Id)
        {
            var model = this.services.GetArticleDetails(Id);
            return View(model);
        }

    }
}
