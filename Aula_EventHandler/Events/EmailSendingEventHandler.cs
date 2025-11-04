using Aula_EventHandler.Entities.Enums;
using FundamentosCS.Shared;

namespace Aula_EventHandler.Events;

public class EmailSendingEventHandler
{
    public event EventHandler<EmailSentEventArgs> EmailSent;
    private readonly static Random _random = new Random();
    public void OnUserRegistered(object sender, UserRegisteredEventArgs e)
    {
        if (sender == null) return;
        
        e.User.EmailStatus = EmailStatus.Pending;
        var code = _random.Next(1000, 9999);

        LogHelper.Info(nameof(EmailSendingEventHandler), nameof(OnUserRegistered), new
        {
            Email = e.User.Email,
            Code = code,
            Status = e.User.EmailStatus,
            RequestedAt = DateTime.UtcNow
        });
        EmailSent?.Invoke(this, new EmailSentEventArgs(e.User, code));

    }
}
