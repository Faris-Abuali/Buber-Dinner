using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.User;

public class User : AggregateRoot<UserId>
{
    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password) 
        : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    
    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        return new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password);
    }
}