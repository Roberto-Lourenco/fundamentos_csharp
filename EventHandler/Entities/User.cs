using Aula_EventHandler.Entities.Enums;

namespace Aula_EventHandler.Entities;
public class User
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public EmailStatus EmailStatus { get; set; }
    public DateTime CreatedAt { get; }
    private User(string name, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        EmailStatus = EmailStatus.Unverified;
        CreatedAt = DateTime.UtcNow;
    }
    public static User Create (string name, string email, string password)
    {
        var user = new User(name, email, password);
        return user;
    }
}
