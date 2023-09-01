using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.User;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();
    // static naming convention is `Users` not `_users
    
    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}