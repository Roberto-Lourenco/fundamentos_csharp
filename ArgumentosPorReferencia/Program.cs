int x = 50;
Console.WriteLine($"Valor da variavel x antes de passar pela função sem ref: {x}");
Calculo sem_referencia = new Calculo();
sem_referencia.DobrarValorSemRef(x);
Console.WriteLine($"Valor da variavel x depois de passar pela função sem ref: {x}");

int j = 50;
Console.WriteLine($"\nValor da variavel j antes de passar pela função com ref: {j}");
Calculo com_referencia = new Calculo();
com_referencia.DobrarValorComRef(ref j);
Console.WriteLine($"Valor da variavel j depois de passar pela função com ref: {j}");

public class Calculo()
{
    public void DobrarValorComRef(ref int y)
    {
        y *= 2;
        Console.WriteLine("Valor da variavel j dentro da função com ref: " +y);
    }

    public void DobrarValorSemRef(int y)
    {
        y *= 2;
        Console.WriteLine("Valor da variavel x dentro da função sem ref: " + y);
    }
}
