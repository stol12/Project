namespace NoLink.Data
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class FormFile
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Column(TypeName = "nvarchar(550)")]
        public string FileName { set; get; }
        [Column(TypeName = "nvarchar(550)")]
        public string Description { set; get; }
        public string FileContent { set; get; }
        public string? ServiceId { get; set; }
        public Service? Service { get; set; }
        public string? ArticleId { get; set; }
        public Article? Article { get; set; }

    }
}
