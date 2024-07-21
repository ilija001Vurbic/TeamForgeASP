using TeamForge.Model;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUserById(Guid userId);
    User GetUserByUsername(string username);
    IEnumerable<User> GetAllUsers();
    void UpdateUser(User user);
    void DeleteUser(Guid userId);
    bool VerifyPassword(string enteredPassword, string storedHash);
}