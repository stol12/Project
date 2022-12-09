namespace NoLink.Services.FirmServices.Models
{
    using System.ComponentModel.DataAnnotations;
    public class TopServiceModel : IFirmServiceModel
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set ; }
        public string Description { get; set; }
        public string CategoryName { get; set; }

        [StringLength(int.MaxValue)]
        public string FileContent { get; set; }
    }
}
