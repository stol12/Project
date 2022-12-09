namespace NoLink.Data
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants.Service;

    public class Service
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(ServiceNameMaxLength, MinimumLength = ServiceNameMinLength)]
        public string? Name { get; set; }

        [Required]
        [StringLength(ServiceDescriptionMaxLength, MinimumLength = ServiceDescriptionMinLength)]
        public string? Description { get; set; }
        public IEnumerable<FormFile>? Files { get; set; } = new List<FormFile>();
    }
}
