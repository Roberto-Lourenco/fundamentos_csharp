using Aula_EventHandler.Entities;
using Aula_EventHandler.Entities.Enums;
using Aula_EventHandler.Events;
using FundamentosCS.Shared;

namespace Aula_EventHandler.Services;

internal class EmailConfirmationService
{
    private int _expectedCode;
    public event EventHandler<EmailConfirmedEventArgs> EmailConfirmed;

    public void OnEmailSent(object sender, EmailSentEventArgs e)
    {
        _expectedCode = e.ConfirmCode;
    }
    internal EmailConfirmationResult ValidateCode(User user, int inputCode)
    {
        var result = new EmailConfirmationResult();

        if (inputCode == _expectedCode)
        {
            result.Confirmed();
            EmailConfirmed.Invoke(this, new EmailConfirmedEventArgs(user));
        }
        else if (inputCode == 0)
        {
            result.Blocked();
            user.EmailStatus = result.Status;
        }
        else
        {
            result.InvalidCode();
            user.EmailStatus = result.Status;
        }

        MensagemConsole.normalMsg(result.Message);

        LogHelper.Info(nameof(EmailConfirmationService), nameof(ValidateCode), new
        {
            Email = user.Email,
            InputCode = inputCode,
            ExpectedCode = _expectedCode,
            Status = result.Status,
            Message = result.Message
        });
        return result;
    }
}
