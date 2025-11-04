using Aula_EventHandler.Entities;

namespace Aula_EventHandler.Events;

public class UserRegisteredEventArgs : EventArgs
{
    public User User { get; set; }

    public UserRegisteredEventArgs(User user)
    {
        User = user;
    }

}
