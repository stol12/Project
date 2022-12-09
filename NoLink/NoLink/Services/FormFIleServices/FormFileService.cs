namespace NoLink.Services.FormFIleServices
{
    using NoLink.Data;
    public class FormFileService : IFormFileService
    {
        private readonly Context data;

        public FormFileService(Context data)
        {
            this.data = data;
        }
        public FormFile ImplementFile(string description, string filePath, string articleId)
        {
            var file = new FormFile
            {
                FileName = this.FileNameGenerator(),
                Description = description,
                FileContent = ProcessFileToUpload(filePath),
                ArticleId = articleId
            };
            return file;
        }
        public FormFile EstablishArticleRelationship(FormFile file, string articleId)
        {
            var article = this.data.Articles
                .Where(a => a.Id == articleId)
                .FirstOrDefault();

            file.Article = article;
            file.ArticleId = articleId;

            return file;
        }
        // random file name is generated for security reasons
        private string FileNameGenerator()
        {
            var result = "";
            var characters = "abcdefghijklmnopqrstuvwxyz!@#$%^^&**())_+1234567890";
            var random = new Random();

            var endPoint = characters.Length / 3;
            var index = 0;

            while (index < endPoint)
            {
                var characterIndex = random.Next(0, characters.Length);
                result += characters[characterIndex];
                index++;
            }

            return result;
        }
        private string ProcessFileToUpload(string fileName)
        {
            var hardcodedDir = @"C:\Users\stjimmyyy\pics-nokia-6.1\Pictures\Discord\" + fileName;

            return Convert.ToBase64String(File.ReadAllBytes(hardcodedDir));
        }

    }
}
