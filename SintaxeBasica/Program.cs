// Exercicio 1
string nome;
int idade;
float nota;

nome = "Paulo";
idade = 17;
nota = 7.5f;

Console.WriteLine($"Exibição simples:\nAluno {nome} tem {idade} anos e nota {nota}");
Console.WriteLine($"Exibição com escapes:\nAluno: {nome}\nIdade: {idade}\nNota: {nota}");

// Exercicio fase 2.5

char letra1, letra2, letra3;
Console.WriteLine("Informe a 1º letra: ");
letra1 = Convert.ToChar(Console.ReadLine());
Console.WriteLine("Informe a 2º letra: ");
letra2 = Convert.ToChar(Console.ReadLine());
Console.WriteLine("Informe a 3º letra: ");
letra3 = Convert.ToChar(Console.ReadLine());

Console.WriteLine($"Você digitou as letras: {letra3}, {letra2}, {letra1}");

// Exercicio fase 2.8

int a = 1, b = 12, c = -13;
double delta, x1, x2;

delta = Math.Pow(b, 2) - 4 * a * c;
x1 = (-b + Math.Sqrt(delta)) / 2 * a;
x2 = (-b - Math.Sqrt(delta)) / 2 * a;

Console.WriteLine($"Valor de x1 = {x1}\nValor de x2 = {x2}");

// Exercicio fase 2.12
double x;

Console.WriteLine("Informe um valor numérico: \n");
x = Convert.ToDouble(Console.ReadLine());

Console.WriteLine(-6 + x * 5);
Console.WriteLine((13 - 2) * x);
Console.WriteLine((x + -2) * (20 / x));
Console.WriteLine((12 + x) / (x - 4));

double resultado = 3 * Math.Pow(x, 2) + x + 10;
double pi = Math.PI * Math.Pow(x, 2);

Console.WriteLine(resultado);
Console.WriteLine(pi);

// Exercicio fase 2.14
double celsius, kelvin, farhenheit;

Console.WriteLine("Informe a temperatura em celsius: ");
celsius = Convert.ToDouble(Console.ReadLine());

kelvin = celsius + 273.15;
farhenheit = (celsius * 9) / 5 + 32;

Console.WriteLine($"Temparatura em Fahrenheit: {farhenheit}");
Console.WriteLine($"Temparatura em Kelvin: {kelvin}");





