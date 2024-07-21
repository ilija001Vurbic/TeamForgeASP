using System.Security.Cryptography;
using System.Text;
using TeamForge.Model;
using TeamForge.Repository.Common;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Register(User user, string password)
    {
        if (_userRepository.GetUserByUsername(user.Username) != null)
        {
            throw new Exception("Username already exists.");
        }

        user.PasswordHash = HashPassword(password);
        _userRepository.AddUser(user);
    }

    public User Login(string username, string password)
    {
        var user = _userRepository.GetUserByUsername(username);
        if (user == null || !VerifyPassword(password, user.PasswordHash))
        {
            throw new Exception("Invalid username or password.");
        }

        return user;
    }

    private string HashPassword(string password)
    {
        using (var hmac = new HMACSHA512())
        {
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }

    private bool VerifyPassword(string enteredPassword, string storedHash)
    {
        using (var hmac = new HMACSHA512())
        {
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
            return storedHash == Convert.ToBase64String(hash);
        }
    }

    public User GetUserByUsername(string username)
    {
        return _userRepository.GetUserByUsername(username);
    }

    public void AddUser(User user)
    {
        _userRepository.AddUser(user);
    }
}