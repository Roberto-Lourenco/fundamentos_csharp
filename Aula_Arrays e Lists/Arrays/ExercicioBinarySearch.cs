using System;
using System.ComponentModel;
using MsgConsole;

namespace ClasseArray
{
    public static class MenuBinarySearch
    {
        public static void iniciar(string[] listaString, int[] listaInt)
        {
            bool limparMenu = true;
            while (true)
            {
                if (limparMenu == true)
                {
                    Console.Clear();

                    MensagensConsole.normalMsg(
                        "=======================================================================================\n" +
                        "------------------------------Exercício com BinarySearch-------------------------------\n" +
                        "======================================================================================="
                        );
                    MensagensConsole.normalMsg("\nMenu Interativo\n");
                    MensagensConsole.normalMsg("1 - Digite '1' para buscar na lista de numeros.");
                    MensagensConsole.normalMsg("2 - Digite '2' para buscar na lista de nomes.");
                    MensagensConsole.normalMsg("3 - Digite '3' para encerrar.");
                }

                string menuNumero = "1";
                string menuNome = "2";
                string menuSair = "3";
                string tipoDeDados = Console.ReadLine();

                if (tipoDeDados == "")
                {
                    MensagensConsole.errorMsg("Campo em branco.");
                    limparMenu = false;
                    continue;
                }

                tipoDeDados = tipoDeDados.Trim();
                if (tipoDeDados == menuSair) { break; }

                if (tipoDeDados != menuNome && tipoDeDados != menuNumero)
                {
                    MensagensConsole.errorMsg($"Digite apenas os valores 1 2 e 3. Valor digitado: {tipoDeDados}");
                    limparMenu = false;
                    continue;
                }

                limparMenu = true;

                if (tipoDeDados == menuNome)
                {
                    string nome;
                    while (true)
                    {
                        MensagensConsole.normalMsg($"Informe o nome que você deseja buscar na lista. (Digite 'menu' para retornar.)");
                        nome = Console.ReadLine();
                        if (nome.Trim().ToLower() == "menu") break;

                        BinarySearchClass.buscarIndiceEmArray(nome, listaString);
                    }
                    continue;
                }

                if (tipoDeDados == menuNumero)
                {
                    string numero;
                    while (true)
                    {
                        MensagensConsole.normalMsg($"Informe o numero que você deseja buscar na lista. (Digite 'menu' para retornar.)");
                        numero = Console.ReadLine();
                        if (numero.Trim().ToLower() == "menu") break;

                        BinarySearchClass.buscarIndiceEmArray(numero, listaInt);
                    }
                    continue;
                }
            }
        }
    }
    public static class BinarySearchClass
    {
        public static void buscarIndiceEmArray(string nome, string[] lista)
        {

            if (string.IsNullOrWhiteSpace(nome) || nome.Any(n => char.IsDigit(n)))
            {
                MensagensConsole.errorMsg("Digite um nome válido");
                return;
            }

            nome = nome.Trim();
            Array.Sort(lista);
            var indice = Array.BinarySearch(lista, nome, StringComparer.OrdinalIgnoreCase);

            if (indice >= 0)
            {
                MensagensConsole.sucessMsg($"O nome {nome} foi encontrado no indice: {indice}\n");
            }
            else
            {
                MensagensConsole.normalMsg($"Não encontrei o nome {nome} na lista.\n");
            }
        }

        public static void buscarIndiceEmArray(string numero, int[] lista)
        {
            numero = numero.Trim();
            if (!int.TryParse(numero, out int numeroConvertido))
            {
                MensagensConsole.errorMsg("Digite um número válido.");
                return;
            }

            Array.Sort(lista);
            var indice = Array.BinarySearch(lista, numeroConvertido);

            if (indice >= 0)
            {
                MensagensConsole.sucessMsg($"O número {numeroConvertido} foi encontrado com o indice: {indice}.\n");
            }
            else
            {
                MensagensConsole.normalMsg($"Não encontrei o número {numeroConvertido} na lista.\n");
            }
        }
    }
}
