var aluno = AlunoFactory.Criar("123", "2006/01/01", "Masculino");
var aluno2 = AlunoFactory.Criar("Tst", "2005/01/01", "Masculino");
aluno.AtualizarNotas(8, 4, 8);
Console.WriteLine(aluno);
Console.WriteLine("\n"+aluno2);