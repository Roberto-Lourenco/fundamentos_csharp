using Aula_EventHandler.Entities;
using Aula_EventHandler.Entities.Enums;

namespace Aula_EventHandler.Events;

public class EmailConfirmedEventArgs
{
    public User User { get;}
    public DateTime ConfirmedAt { get;}
    public EmailConfirmedEventArgs(User user)
    {
        User = user;
        ConfirmedAt = DateTime.UtcNow;
    }
}
