using ArrayComFor;
using ClasseArray;

// Aula 1
//ArrayImparPar arrayImpar = new();
//ArrayImparPar arrayPar = new();

//arrayImpar.gerarNumerosImpares();
//arrayPar.gerarNumerosImpares();

//arrayPar.converterArray();
//arrayImpar.converterArray();

// Aula 2
int[] listaInt = new int[10];
Random random = new Random();
for (int i = 0; i < listaInt.Length;)
{
    int numeroAleatorio = random.Next(1, 20);
    if (!listaInt.Contains(numeroAleatorio)){
        listaInt[i] = numeroAleatorio;
        i++;
    }   
}
string[] listaString = new string[10] {"Miguel","Felipe","Micael","Ludimila","Santos","Ricciardo","Ayrton","Senna","Bruno","James"};

MenuBinarySearch.iniciar(listaString, listaInt);



