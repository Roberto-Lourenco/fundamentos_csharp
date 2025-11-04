using Aula_EventHandler.Entities.Enums;
using FundamentosCS.Shared;

namespace Aula_EventHandler.Events;

internal class EmailConfirmedEventHandler
{
    public void OnEmailConfirmed(object sender, EmailConfirmedEventArgs e)
    {
        e.User.EmailStatus = EmailStatus.Confirmed;

        LogHelper.Info(nameof(EmailConfirmedEventHandler), nameof(OnEmailConfirmed), new
        {
            UserId = e.User.Id,
            Email = e.User.Email,
            EmailStatus = e.User.EmailStatus,
            ConfirmedAt = e.ConfirmedAt

        });
    }
}
