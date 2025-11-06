using Aula_EventHandler.Entities;
using Aula_EventHandler.Entities.Enums;
using Aula_EventHandler.Events;
using Aula_EventHandler.Services;
using FundamentosCS.Shared;

var app = new App();
app.Run();

internal class App
{
    private readonly UserService _userService;
    private readonly EmailSendingEventHandler _emailSendingHandler;
    private readonly EmailSentEventHandler _emailSentHandler;
    private readonly EmailConfirmationService _emailConfirmationService;
    private readonly EmailConfirmedEventHandler _emailConfirmedHandler;

    private readonly List<User> _users = new();

    public App()
    {
        _userService = new UserService();
        _emailSendingHandler = new EmailSendingEventHandler();
        _emailSentHandler = new EmailSentEventHandler();
        _emailConfirmationService = new EmailConfirmationService();
        _emailConfirmedHandler = new EmailConfirmedEventHandler();

        ConfigureEventPipeline();
    }

    private void ConfigureEventPipeline()
    {
        _userService.UserRegistered += _emailSendingHandler.OnUserRegistered;
        _emailSendingHandler.EmailSent += _emailSentHandler.OnEmailSent;
        _emailSendingHandler.EmailSent += _emailConfirmationService.OnEmailSent;
        _emailConfirmationService.EmailConfirmed += _emailConfirmedHandler.OnEmailConfirmed;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            ShowMenu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    ConfirmEmail();
                    break;
                case "3":
                    Login();
                    break;
                case "4":
                    ListConfirmedUsers();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    MensagemConsole.warningMsg("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        MensagemConsole.normalMsg($"\n{new string('=', 20)} MENU {new string('=', 20)}");
        MensagemConsole.normalMsg("1. Criar usuário");
        MensagemConsole.normalMsg("2. Confirmar email");
        MensagemConsole.normalMsg("3. Fazer login");
        MensagemConsole.normalMsg("4. Listar usuários validados");
        MensagemConsole.normalMsg("5. Sair");
        MensagemConsole.normalMsg($"{new string('=', 46)}");
        Console.Write("Escolha uma opção: ");
    }

    private void CreateUser()
    {
        Console.Write("Nome: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Email: ");
        var email = Console.ReadLine().Trim() ?? "";
        Console.Write("Senha: ");
        var password = Console.ReadLine() ?? "";

        var user = _userService.Register(name, email, password);
        _users.Add(user);
    }

    private void ConfirmEmail()
    {
        Console.Write("Email do usuário: ");
        var email = Console.ReadLine().Trim() ?? "";

        var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        if (user == null)
        {
            MensagemConsole.warningMsg("Usuário não encontrado.");
            return;
        }

        Console.Write("Código de confirmação: ");
        if (!int.TryParse(Console.ReadLine(), out int inputCode))
        {
            MensagemConsole.warningMsg("Entrada inválida. Código deve ser numérico.");
            return;
        }

        _emailConfirmationService.ValidateCode(user, inputCode);

    }

    private void ListConfirmedUsers()
    {
        var confirmedUsers = _users.Where(u => u.EmailStatus == EmailStatus.Confirmed).ToList();

        if (!confirmedUsers.Any())
        {
            MensagemConsole.normalMsg("Nenhum usuário confirmado encontrado.");
            return;
        }

        Console.WriteLine("\n=== Usuários Confirmados ===");
        foreach (var user in confirmedUsers)
        {
            Console.WriteLine($"ID: {user.Id} | Nome: {user.Name} | Email: {user.Email}");
        }
    }
    private void Login()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine().Trim() ?? "";
        Console.Write("Senha: ");
        var password = Console.ReadLine() ?? "";
        var user = _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        if (user == null || user.Password != password)
        {
            MensagemConsole.errorMsg("Email ou senha inválidos.");
            return;
        }     
        if (user.EmailStatus != EmailStatus.Confirmed)
        {
            MensagemConsole.warningMsg("O usuário está com a confirmação de email pendente. Confirme o email para fazer login.");
            return;
        }

        MensagemConsole.successMsg($"Seja bem vindo {user.Name}!");
    }
}
