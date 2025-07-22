public static class AlunoService
{
    private static uint proximaMatricula = 1;
    public static uint GerarMatricula() => proximaMatricula++;

    public static string CalcularDesempenho(params double[] notas)
    {

        double media = notas.Average();
        string desempenho;

        if (media >= 0 && media <= 4)
            desempenho = $"Média {media.ToString("F2")} - Reprovado";
        else if (media >= 5 && media < 7)
            desempenho = $"Média {media.ToString("F2")} - Recuperação";
        else
            desempenho = $"Média {media.ToString("F2")} - Aprovado";

        return desempenho;

    }
    public static int CalcularIdade(DateTime dataNascimento)
    {
        int idade = DateTime.Now.Year - dataNascimento.Year;

        if (DateTime.Now < dataNascimento.AddYears(idade))
        {
            idade--;
        }

        return idade;
    }

}