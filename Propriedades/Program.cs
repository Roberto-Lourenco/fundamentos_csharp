using System;
using System.Runtime.CompilerServices;

Carro carro = new("Argo", 2024, "");
Console.WriteLine(carro);

public class Carro
{
    private string? modelo;
    public string Modelo
    {
        get => modelo!.ToUpper();
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new CampoObrigatorioException(nameof(Modelo));
            modelo = value;
        }
    }

    private string? marca;
    public string Marca
    {
        get => marca!.ToUpper();
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new CampoObrigatorioException(nameof(Marca));
            marca = value;
        }
    }

    private int ano;
    public int Ano
    {
        get => ano;
        private set
        {
            if (value == 0)
                throw new CampoObrigatorioException(nameof(Ano));
            if (value < 2000)
                throw new AnoInvalidoException(value);
            ano = value;
        }
    }

    public Carro(string modelo, int ano, string marca = "Desconhecida")
    {
        Modelo = modelo;
        Ano = ano;
        Marca = marca;
    }
    public override string ToString()
    {
        return $"\nDados do veículo:\n" +
            $"Modelo: {Modelo}\n"+
            $"Marca: {Marca}\n"+
            $"Ano: {Ano}\n"; ;
    }
}

public class CampoObrigatorioException : Exception
{
    public CampoObrigatorioException(string nomeCampo)
        : base($"O campo {nomeCampo} não pode estar em branco.") { }
}

public class AnoInvalidoException : Exception
{
    public AnoInvalidoException(int ano)
        : base($"Ano '{ano} inválido. O ano deve ser maior ou igual a 2000. ") { }
}
