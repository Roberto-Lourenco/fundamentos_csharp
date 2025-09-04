using MsgConsole;
namespace ArrayComFor
{

    public class ArrayImparPar
    {
        public int[] arrayInt { get; private set; }
        private static Random random = new Random();

        public void converterArray()
        {

            if (this.arrayInt == null)
            {
                MensagensConsole.errorMsg("O array está vazio");
                return;
            }

            string arrayAntigo = string.Join(",", this.arrayInt);

            for (int i = 0; i < this.arrayInt.Length; i++)
            {
                this.arrayInt[i] = this.arrayInt[i] + 1;
            }

            string tipo_atual_do_array = "";

            if (this.arrayInt[0] % 2 == 0) { tipo_atual_do_array = "Par "; }
            if (this.arrayInt[0] % 2 != 0) { tipo_atual_do_array = "Impar"; }

            MensagensConsole.sucessMsg($"Array ({arrayAntigo}) Convertido para {tipo_atual_do_array}: {string.Join(',', this.arrayInt)}");
        }

        public void gerarNumerosImpares()
        {
            int[] impares = new int[3];
            int index = 0;

            while (index < 3)
            {
                int numeroAleatorio = random.Next(1, 100);
                if (!impares.Contains(numeroAleatorio) && numeroAleatorio % 2 != 0)
                {
                    impares[index] = numeroAleatorio;
                    index++;
                }
            }
            Array.Sort(impares);
            this.arrayInt = impares;
            MensagensConsole.sucessMsg($"Array atualizado com numeros Impares: {string.Join(',', this.arrayInt)}");

        }

        public void gerarNumerosPares()
        {
            int[] pares = new int[3];
            int index = 0;

            while (index < 3)
            {

                int numeroAleatorio = random.Next(1, 100);
                if (!pares.Contains(numeroAleatorio) && numeroAleatorio % 2 == 0)
                {
                    pares[index] = numeroAleatorio;
                    index++;
                }

            }
            Array.Sort(pares);
            this.arrayInt = pares;
            MensagensConsole.sucessMsg($"Array atualizado com numeros Pares: {string.Join(',', this.arrayInt)}");

        }
    }
}

