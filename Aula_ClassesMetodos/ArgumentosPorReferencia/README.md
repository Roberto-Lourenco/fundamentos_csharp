
# Aula C# - Argumentos por Referencia

Argumentos por referência no C# são utilizados para uma função atualizar o valor da variável fora do seu escopo.

## Desmistificando  
No C#, ao chamar um método com um argumento por valor, uma cópia da variável é feita na memória [Stack](https://www.dio.me/articles/heap-stack-atribuicao-por-referencia-e-por-valor-o-que-e-cada-uma). E as alterações feitas nessa cópia não afetam a variável original.  
Porém, ao utilizar Argumentos por Referência, podemos usar um método para modificar a variavel diretamente, alocando uma referência na memória entre o argumento e a variável.

#### A seguir estão os 2 exemplos:

---
### Atualizando o valor da variável sem Argumento por referência

  
Podemos armazenar o valor da variável após realizar uma função, passando a função como um novo valor a variável.

Abaixo segue o exemplo:

```
int x = 50;
Calculo sem_referencia = new Calculo(); 
x = sem_referencia.DobrarValorSemRef(x); 
Console.WriteLine(x);

public class Calculo
{
    public void DobrarValorSemRef(int y)
    {
        y *= 2;
        return y;
    }
}
```
>Saída no console: 100  

Esse método retorna um novo valor calculado, reatribuindo um novo valor a x. E ele não manipula diretamente o valor original passado, mas sim sua cópia.  

Seu processo na memória seria parecido com isto:  
| Stack     | Heap  | Descrição                                                                                          |
| --------- | ----- | -------------------------------------------------------------------------------------------------- |
| `x = 50`  |-      | Variável por valor `x` armazenada na Stack                                                         |
| `y = 50`  |-      | Dentro do método, `x` é copiado para `y`                                                           |
| `y = 100` |-      | `y` é modificado dentro do método (`y *= 2`)                                                       |
| `x = 100` |-      | Ao final da função o método apaga e retorna o valor de `y`, sobrescrevendo `x` com o novo valor    |


---
### Usando Argumento com Referência
```csharp
int j = 50;
Calculo com_referencia = new Calculo();
com_referencia.DobrarValorComRef(ref j); // Utilizando argumento por referência
Console.WriteLine(j); 

public class Calculo
{
    public void DobrarValorComRef(ref int y) // Declarando o parametro para aceitar argumento por referência
    {
        y *= 2;
    }
}
```
>Saída no console: 100

Ao utilizar o Argumento por Referência, a variável j é manipulada dentro do método, criando uma referência temporária de j a y. Ou seja, tudo que for alterado em y, está sendo alterado em j consequentemente.

Abaixo está seu passo a passo na memória:
| Stack       | Heap  | Descrição                                                                                        |
| ----------- | ----- | ------------------------------------------------------------------------------------------------ |
| j = 50      |-      | Variável por valor `j` armazenada na Stack                                                       |
| ref y -> j  |-      | Dentro do método, é criado uma referência de `j` a `y`, ambos compartilham o mesmo endereço      |
| j = 100     |-      | `y` é modificado dentro do método (`y *= 2`) alterando diretamente `j`                           |
| j = 100     |-      | Ao final da função, `y` é apagado da memória, mas `j` mantém o valor alterado                    |

## Conclusão

- Ao passar argumentos **por valor**, o método trabalha com uma **cópia da variável**, e alterações feitas dentro da função **não afetam** a variável original.
- Ao passar argumentos **por referência** (`ref`), o método opera diretamente sobre a variável original, permitindo que **modificações feitas no método persistam** após sua execução.
- Esse comportamento afeta diretamente como os dados são manipulados na memória (Stack) e é fundamental para escrever código **eficiente**.

> 🧠 Utilizar `ref` pode ter suas vantagens, principalmente ao trabalhar com grandes volumes de dados sendo atualizados em um curto espaço de tempo. Porém, devemos ter cuidado ao utilizá-lo, pois isso pode dificultar a leitura e manutenção do código.


# Referência

[Curso C# Essencial (Com LINQ, Net 7.0 .NET 8.0 e .NET 9.0](https://www.udemy.com/course/curso-c-essencial-2023-bonus-linq) - [Jose Carlos Macoratti](https://www.macoratti.net)
