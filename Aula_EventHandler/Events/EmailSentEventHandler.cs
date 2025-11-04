using Aula_EventHandler.Entities.Enums;
using FundamentosCS.Shared;

namespace Aula_EventHandler.Events;

public class EmailSentEventHandler
{
    public void OnEmailSent(object sender, EmailSentEventArgs e)
    {
        e.User.EmailStatus = EmailStatus.Sent;

        LogHelper.Info(nameof(EmailSentEventHandler), nameof(OnEmailSent), new
        {
            Email = e.User.Email,
            Status = e.User.EmailStatus,
            Code = e.ConfirmCode,
            SentAt = e.SentAt
        });
    }
}
