namespace NoLink.Services.FirmServices
{
    using NoLink.Services.FirmServices.Models;
    public interface IFirmService
    {
        IEnumerable<TopServiceModel> TopServices();
        IEnumerable<FirmServiceQueryModel> AllServices();
        IEnumerable<TopServiceModel> FilesContent();
        TopServiceModel Details(string id);
        int ServicesCount();
    }
}   
