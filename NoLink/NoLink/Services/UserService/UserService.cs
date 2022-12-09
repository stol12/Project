namespace NoLink.Services.UserService
{
    using Microsoft.AspNetCore.Identity;
    using NoLink.Data;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly Context context;
        private readonly UserManager<User> userManager;
        public UserService(UserManager<User> userManager ,Context context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public string HashPasswordOnRegister(string password)
        {
            var result = "";

            using (SHA384 sha384hash = SHA384.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha384hash.ComputeHash(sourceBytes);

                string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                result = hash;
            }

            return result;
        }
        public User? GetUserByUsername(string username)
            => this.context.Users
                    .Where(u => u.UserName == username)
                    .Select(u => new User
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Password = u.Password,
                        Email = u.Email
                    })
                    .FirstOrDefault();

        public bool UserExists(string username)
                =>
                 this.context.Users.Where(u => u.UserName == username).FirstOrDefault() != null;
    }
}
