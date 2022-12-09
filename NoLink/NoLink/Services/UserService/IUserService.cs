namespace NoLink.Services.UserService
{
    using NoLink.Data;

    public interface IUserService
    {
        string HashPasswordOnRegister(string password);
        bool UserExists(string username);
        User GetUserByUsername(string username);
    }
}
