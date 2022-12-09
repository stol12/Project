namespace NoLink.Services.FormFIleServices
{
    using NoLink.Data;
    public interface IFormFileService
    {
        FormFile ImplementFile(string description, string fileName, string articleId);
        FormFile EstablishArticleRelationship(FormFile file, string articleId);
    }
}
