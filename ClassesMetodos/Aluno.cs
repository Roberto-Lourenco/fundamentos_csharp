using System.Runtime.CompilerServices;

public class Aluno
{
    public string? Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string? Sexo { get; private set; }
    public UInt32 Matricula { get; private set; }
    public double[] Notas {  get; private set; }
    public string? Desempenho { get; private set; }
    public string? Status { get; private set; }

    internal Aluno (string nome, DateTime dataNascimento, string sexo, UInt32 matricula)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Sexo = sexo;
        Matricula = matricula;
        Notas = new double[3];
        Desempenho = "Não avaliado";
        Status = "Ativo";
    }

    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome) || novoNome.Length < 3)
        {
            throw new ArgumentException("O nome deve ter ao menos 3 letras e não pode estar vazio");
        }
        this.Nome = novoNome;
    }

    public void AtualizarNotas(params double[] notas)
    {
        if (notas == null || notas.Length == 0)
        {
            throw new ArgumentNullException("Notas inválidas ou Nulas.");
        }
        if (notas.Length > 3)
        {
            throw new ArgumentOutOfRangeException("Forneça no máximo 3 notas.");
        }
        if (notas.Any(nota => nota > 10 || nota < 0))
        {
            throw new ArgumentOutOfRangeException("Forneça uma nota de 0 a 10");
        }
        
        for (int i = 0; i<this.Notas.Length; i++)
        {
            this.Notas[i] = notas[i];
        }
        for (int i = notas.Length; i < this.Notas.Length; i++)
        {
            this.Notas[i] = 0;
        }

        this.Desempenho = AlunoService.CalcularDesempenho(notas);
    }

    public override string ToString()
    {
        return $"Dados do Aluno {this.Nome}" +
            $"\nNº da matrícula: {this.Matricula}" +
            $"\nIdade: {AlunoService.CalcularIdade(this.DataNascimento)} Anos" +
            $"\nNotas: {string.Join(", ", this.Notas)}" +
            $"\nDesempenho atual: {this.Desempenho}" +
            $"\nStatus: {this.Status}";
    }
}