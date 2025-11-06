using Aula_EventHandler.Entities;
using Aula_EventHandler.Events;
using FundamentosCS.Shared;

namespace Aula_EventHandler.Services;

internal class UserService
{
    public EventHandler<UserRegisteredEventArgs> UserRegistered;
    internal User Register(string name, string email, string password)
    {
        var user = User.Create(name,email,password);

        LogHelper.Info(nameof(UserService), nameof(Register), new { user.Id, user.Email, user.CreatedAt });

        UserRegistered?.Invoke(this, new UserRegisteredEventArgs(user));

        return user;
    }
}
