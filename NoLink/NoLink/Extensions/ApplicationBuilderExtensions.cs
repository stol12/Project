namespace NoLink.Extensions
{
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using NoLink.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;


            MigrateDatabase(services);
            SeedServices(services);
            ReadImages(services);

            return app;
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<Context>();
            
            data.Database.Migrate();
        }
        private static void SeedServices(IServiceProvider services)
        {
            var data = services.GetRequiredService<Context>();

            if (data.Services.Any() || data.Services == null)
            {
                return;
            }
            // Add images for each service

            data.Services.AddRange(new[] {
                new Service { Name = "Network Security", Description = "Network security consists of the policies, processes and practices adopted to prevent, detect and monitor unauthorized access, misuse, modification, or denial of a computer network and network-accessible resources."},
                new Service { Name = "Database Security", Description = "Database security concerns the use of a broad range of information security controls to protect databases against compromises of their confidentiality, integrity and availability. It involves various types or categories of controls, such as technical, procedural/administrative and physical."},
                new Service { Name = "Web Security", Description = "Internet security is a branch of computer security. It encompasses the Internet, browser security, web site security,[1] and network security as it applies to other applications or operating systems as a whole. Its objective is to establish rules and measures to use against attacks over the Internet.[2] The Internet is an inherently insecure channel for information exchange, with high risk of intrusion or fraud, such as phishing,[3] online viruses, trojans, ransomware and worms."},
                new Service { Name = "Data Security", Description = "Data security means protecting digital data, such as those in a database, from destructive forces and from the unwanted actions of unauthorized users, such as a cyberattack or a data breach."},
                new Service { Name = "Cloud Security", Description = "Cloud computing security or, more simply, cloud security refers to a broad set of policies, technologies, applications, and controls utilized to protect virtualized IP, data, applications, services, and the associated infrastructure of cloud computing."},
                new Service { Name = "Lock Security", Description = "Lock Security offers a highly effective cryptographic algorithm which generates secure passwords so you do not have to worry about your accounts being easily brute-forced."}
            });

            data.SaveChanges();
        }
        private static void ReadImages(IServiceProvider services)
        {
            var data = services.GetRequiredService<Context>();

            if (data.Files.Any()) return;

            string[] fileNames = new string[]
            {
                @"C:\Users\stjimmyyy\source\repos\NoLink\NoLink\wwwroot\images\763.jpg",
                @"C:\Users\stjimmyyy\source\repos\NoLink\NoLink\wwwroot\images\airodump.jpg",
                @"C:\Users\stjimmyyy\source\repos\NoLink\NoLink\wwwroot\images\MITM.jpg",
                @"C:\Users\stjimmyyy\source\repos\NoLink\NoLink\wwwroot\images\phishing.jpg",
                @"C:\Users\stjimmyyy\source\repos\NoLink\NoLink\wwwroot\images\ransomware.jpg",
                @"C:\Users\stjimmyyy\source\repos\NoLink\NoLink\wwwroot\images\shutterstock.jpg",
                @"C:\Users\stjimmyyy\source\repos\NoLink\NoLink\wwwroot\images\sql-injection-attack.jpg"
            };

            foreach(var fileName in fileNames)
            {
                var file = Convert.ToBase64String(File.ReadAllBytes(fileName));

                var formFile = new FormFile
                {
                    FileName = fileName,
                    Description = "No description",
                    FileContent = file,
                    ServiceId = GetRandomId(data)
                };

                data.Files.Add(formFile);

            }

            data.SaveChanges();
        }

        //TODO MOVE TO FILE SERVICE
        private static string GetRandomId(Context data)
        {
            var rand = new Random();
            var toSkip = rand.Next(1, data.Services.Count());

            return data.Services.Select(s => s.Id).Skip(toSkip).Take(1).First();
        }

    }
  
}   
