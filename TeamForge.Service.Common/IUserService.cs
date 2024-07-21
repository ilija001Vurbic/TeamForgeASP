using TeamForge.Model;

public interface IUserService
{
    void Register(User user, string password);
    User Login(string username, string password);
    User GetUserByUsername(string username);
    void AddUser(User user);
}