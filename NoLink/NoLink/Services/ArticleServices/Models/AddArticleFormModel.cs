namespace NoLink.Services.ArticleServices.Models
{
    using NoLink.Data;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Article;
    public class AddArticleFormModel
    { 
        public string Id { get; set; }

        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Title length must be between {0} and {1} characters long!")]
        [RegularExpression("[A-z]+", ErrorMessage = "Title is not in the correct format!")]
        public string Title { get; set; }
        
        [StringLength(TextMaxLength, MinimumLength = TextMinLength, ErrorMessage = "Article text length must be between {0} and {1} characters long!")]
        [RegularExpression("[A-z]+", ErrorMessage = "Text contains characters which are not allowed!")]
        public string Text { get; set; }
        public string FileContent { get; set; }

        public IEnumerable<FormFile> Files = new List<FormFile>();
        public string Path { get; set; }
    }
}
