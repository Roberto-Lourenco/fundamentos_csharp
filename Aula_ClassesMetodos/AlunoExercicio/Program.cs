var aluno = AlunoFactory.Criar("Testando", "2005/01/01", "Masculino");
var aluno2 = AlunoFactory.Criar("Teste", "2005/01/01", "Masculino");
aluno.AtualizarNotas(8, 4, 8);
Console.WriteLine(aluno);
Console.WriteLine("\n"+aluno2);