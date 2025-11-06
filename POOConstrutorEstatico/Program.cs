try
{
    ClasseMonitorada instancia1 = new("Instancia 1");
    ClasseMonitorada instancia2 = new("Instancia 2");
    ClasseMonitorada instancia3 = new("Instancia 3");
    ClasseMonitorada instancia4 = new("Instancia 4");
    ClasseMonitorada instancia5 = new("Instancia 5");
    ClasseMonitorada instancia6 = new("Instancia 6");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
ClasseMonitorada.Instancias();
public class ClasseMonitorada
{
    public static int contador_instancias;
    public static int limite_instancias;
    public string Nome;

    static ClasseMonitorada()
    {
        contador_instancias = 0;
        limite_instancias = 5;
    }
    public ClasseMonitorada(string nome)
    {
        LimitadorDeInstancias();
        this.Nome = nome;
        contador_instancias++;
    }


    public static void Instancias()
    {
        Console.WriteLine($"Numero de vezes que a classe foi instânciada: {contador_instancias}");
    }

    public static void LimitadorDeInstancias()
    {
        if (contador_instancias >= limite_instancias)
        {
            throw new InvalidOperationException("Essa classe atingiu o seu limite de instâncias");
        }
    }
}