using Aula_Delegate;
using FundamentosCS.Shared;

// Delegate Predicate
MensagemConsole.warningMsg("\nPressione uma tecla para iniciar o teste do Degate Predicate\n");
Console.ReadKey();
MensagemConsole.warningMsg($"\n{new string('*', 20)} Iniciando código do DELEGATE PREDICATE {new string('*', 20)}\n");

Predicate<int> VerificaNumeroPar = numero => numero % 2 == 0;
Predicate<string> PrimeiraLetraMaiuscula = palavra => palavra.ToString()[0].ToString() == palavra.ToString()[0].ToString().ToUpper();
Predicate<DateTime> DataFutura = data => data > DateTime.UtcNow;

DateTime dataTest1 = new DateTime(2026, 01, 01);
DateTime dataTest2 = new DateTime(2016, 01, 01);
int numeroTest1 = 5;
int numeroTest2 = 10;
string palavraTest1 = "hello world";
string palavraTest2 = "Hello world";

MensagemConsole.normalMsg($"O numero {numeroTest1} é par?: {VerificaNumeroPar(numeroTest1)}");
MensagemConsole.normalMsg($"O numero {numeroTest2} é par?: {VerificaNumeroPar(numeroTest2)}");

MensagemConsole.normalMsg($"Primeira letra da palavra '{palavraTest1}' é maiuscula?: {PrimeiraLetraMaiuscula(palavraTest1)}");
MensagemConsole.normalMsg($"Primeira letra da palavra '{palavraTest2}' é maiuscula?: {PrimeiraLetraMaiuscula(palavraTest2)}");

MensagemConsole.normalMsg($"A data {dataTest1.ToShortDateString()} é uma data futura?: {DataFutura(dataTest1)}");
MensagemConsole.normalMsg($"A data {dataTest2.ToShortDateString()} é uma data futura?: {DataFutura(dataTest2)}");

//Delegate Action
MensagemConsole.warningMsg("\nPressione uma tecla para iniciar o teste do Degate Action\n");
Console.ReadKey();

MensagemConsole.warningMsg($"\n{new string('*', 20)} Iniciando código do DELEGATE ACTION {new string('*', 20)}\n");
var processador = new ProcessadorDePedidos();
{
    MensagemConsole.warningMsg($"\n{new string('*',5)} Iniciando código do bloco 1... {new string('*', 5)}\n");
    using var pedidoOberserver = new PedidoObserver(processador);
    pedidoOberserver.StartObserving();
    processador.ProcessarPedido(102);
    processador.ProcessarPedido(103);
    processador.ProcessarPedido(110);
    MensagemConsole.warningMsg($"\n{new string('*', 5)} Fim do código do bloco 1. {new string('*', 5)}\n");
};

{
    MensagemConsole.warningMsg($"\n{new string('*', 5)} Iniciando código do bloco 2... {new string('*', 5)}\n");
    using var pedidoOberserver = new PedidoObserver(processador);
    pedidoOberserver.StartObserving();
    processador.ProcessarPedido(111);
    processador.ProcessarPedido(115);
    processador.ProcessarPedido(118);
    MensagemConsole.warningMsg($"\n{new string('*', 5)} Fim do código do bloco 2. {new string('*', 5)}\n");
};





