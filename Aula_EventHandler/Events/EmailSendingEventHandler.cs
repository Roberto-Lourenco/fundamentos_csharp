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
        
        var code = _random.Next(1000, 9999);
        var sendingArgs = new EmailSendingEventArgs(e.User, code);
        e.User.EmailStatus = EmailStatus.Pending;

        LogHelper.Info(nameof(EmailSendingEventHandler), nameof(OnUserRegistered), new
        {
            Email = sendingArgs.User.Email,
            Code = sendingArgs.ConfirmCode,
            Status = sendingArgs.User.EmailStatus,
            SendAt = sendingArgs.RequestedAt
        });
        EmailSent?.Invoke(this, new EmailSentEventArgs(
            sendingArgs.User,
            sendingArgs.ConfirmCode
            ));
    }
}
