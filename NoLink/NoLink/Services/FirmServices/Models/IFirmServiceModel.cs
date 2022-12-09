using System.ComponentModel.DataAnnotations;

namespace NoLink.Services.FirmServices.Models
{
    public interface IFirmServiceModel
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Image { get; set; }
       string FileContent { get; set; }
    }
}
