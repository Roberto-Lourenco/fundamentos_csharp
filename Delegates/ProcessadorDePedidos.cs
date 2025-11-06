using FundamentosCS.Shared;

namespace Aula_Delegate;

internal class ProcessadorDePedidos
{
    public Action<int>? OnPedidoProcessado { get; set; }

    internal void ProcessarPedido(int pedidoId)
    {
        MensagemConsole.normalMsg($"\n[Processador]: Iniciando processamento do Pedido #{pedidoId}...");
        Thread.Sleep(1000);
        MensagemConsole.successMsg($"[Processador]: Pedido #{pedidoId} concluído.");
        OnPedidoProcessado?.Invoke(pedidoId);
    }
}
