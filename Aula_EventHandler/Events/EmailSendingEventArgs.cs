using Aula_EventHandler.Entities;
using Aula_EventHandler.Entities.Enums;

namespace Aula_EventHandler.Events;

public class EmailSendingEventArgs : EventArgs
{
    public User User { get;}
    public int ConfirmCode { get;}
    public DateTime RequestedAt { get;}
    public EmailSendingEventArgs(User user, int confirmCode)
    {
        User = user;
        ConfirmCode = confirmCode;
        RequestedAt = DateTime.UtcNow;
    }
}
