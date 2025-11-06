using Aula_EventHandler.Entities.Enums;

namespace Aula_EventHandler.Entities;

public class EmailConfirmationResult
{
    public EmailStatus Status { get; private set; }
    public string Message { get; private set; }
    public void Confirmed()
    {
        Status = EmailStatus.Confirmed;
        Message = "Email confirmado com sucesso!";
    }
    public void InvalidCode()
    {
        Status = EmailStatus.VerificationFailed;
        Message = "Código de confirmação inválido.";
    }
    public void Blocked()
    {
        Status = EmailStatus.Blocked;
        Message = "Conta bloqueada pelo proprietario do email";
    }
}