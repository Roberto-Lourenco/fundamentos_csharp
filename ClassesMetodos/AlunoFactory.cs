public static class AlunoFactory
{
    public static Aluno Criar(string nome, string dataNascimento, string sexo)
    {
        DateTime dataFormatada = FormatarData(dataNascimento);
        string sexoToLower = sexo.ToLower();

        AlunoValidator.Validar(nome, sexoToLower, dataFormatada);

        uint novaMatricula = AlunoService.GerarMatricula();
        return new Aluno(nome, dataFormatada, sexoToLower, novaMatricula);
    }

    private static DateTime FormatarData(string data)
    {
        if (!DateTime.TryParse(data, out DateTime dataFormatada))
        {
            throw new InvalidDataException("Erro ao formatar data. Use o formatado yyyy/MM/dd");
        }
        return dataFormatada;
    }
}