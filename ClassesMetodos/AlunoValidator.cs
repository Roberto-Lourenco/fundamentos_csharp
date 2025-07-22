public static class AlunoValidator
{
    public static void Validar(string nome, string sexo, DateTime dataNascimento)
    {

        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 3)
        {
            throw new ArgumentException("O nome deve conter ao menos 3 letras e não pode estar vazio");
        }
        if (sexo != "masculino" && sexo != "feminino")
        {
            throw new ArgumentException("Sexo inválido. Digite apenas Masculino ou Feminino.");
        }

        int idade = AlunoService.CalcularIdade(dataNascimento);
        if (idade < 4 || idade > 22)
        {
            throw new InvalidDataException("Idade fora do padrão.");
        }
    }

    
}