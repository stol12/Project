namespace NoLink.Services.FirmServices
{
    using Microsoft.EntityFrameworkCore;
    using NoLink.Data;
    using NoLink.Services.FirmServices.Models;

    public class FirmService : IFirmService
    {
        private readonly Context data;
        public FirmService(Context data)
        {
            this.data = data;
        }
        public IEnumerable<TopServiceModel> TopServices()
            => this.data.Services
                        .Select(s => new TopServiceModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Description = s.Description,
                        })
                        .Distinct()
                        .OrderByDescending(s => s.Id)
                        .ThenBy(s => s.Name)
                        .ToList();

        public IEnumerable<FirmServiceQueryModel> AllServices()
            => this.data.Services
                        .Select(s => new FirmServiceQueryModel
                        { 
                            Id = s.Id,
                            Name = s.Name,
                            Description = s.Description,
                            
                        })
                        .OrderByDescending(s => s.Id)
                        .AsNoTracking()
                        .ToList();
       
        public int ServicesCount()
            => this.data.Services.Count();

        public IEnumerable<TopServiceModel> FilesContent()
            => this.data.Services
            .Select(s => new TopServiceModel
            {
                Id = s.Id,
                Name = s.Name,
                FileContent = s.Files.Select(f => f.FileContent).First(),
                Description = s.Description,
            })
            .ToList();

        public TopServiceModel Details(string id)
            => this.data.Services
                .Where(s => s.Id == id)
                .Select(s => new TopServiceModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                })
                .First();
    }
}
