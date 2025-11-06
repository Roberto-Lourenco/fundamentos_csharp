RelatorioService.SolicitarRelatorio("Reunião semanal");
RelatorioService.SolicitarRelatorio("Resumo de vendas", new DateTime(2025,05,25));
RelatorioService.SolicitarRelatorio("Briefing", new DateTime(2025,06,25), "PDF");
public class RelatorioService
{
    public static void SolicitarRelatorio(string nomeRelatorio)
    {
        Console.WriteLine($"Relatório: '{nomeRelatorio}' foi solicitado, aguarde atualizações.");
    }
    public static void SolicitarRelatorio(string nomeRelatorio, DateTime prazo)
    {
        Console.WriteLine($"Relatório: '{nomeRelatorio}' foi solicitado com o prazo limite até o dia {prazo:dd/MM/yyyy}.");
    }
    public static void SolicitarRelatorio(string nomeRelatorio, DateTime prazo, string tipoDeArquivo)
    {
        Console.WriteLine($"O Relatório '{nomeRelatorio}' foi solicitado para ser entregue até o dia {prazo:dd/MM/yyyy} em formato {tipoDeArquivo}.");
    }
}