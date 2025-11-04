using Aula_EventHandler.Entities;
using Aula_EventHandler.Entities.Enums;

namespace Aula_EventHandler.Events;

public class EmailSentEventArgs : EventArgs
{
    public User User { get; set; }
    public int ConfirmCode { get;}
    public DateTime SentAt { get;}
    public EmailSentEventArgs(User user, int confirmCode)
    {
        User = user;
        ConfirmCode = confirmCode;
        SentAt = DateTime.UtcNow;
    }

}
