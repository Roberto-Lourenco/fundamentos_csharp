using FundamentosCS.Shared;
using System;

namespace Aula_Delegate;

internal class PedidoObserver : IDisposable
{
    private readonly ProcessadorDePedidos _processadorDePedidos;
    public PedidoObserver(ProcessadorDePedidos processadorDePedidos)
    {
        _processadorDePedidos = processadorDePedidos;
    }
    internal void StartObserving()
    {
        MensagemConsole.warningMsg($"[LOG {DateTime.Now.ToLongTimeString()}]: Callback iniciado... Horário: " + DateTime.Now.ToLongTimeString());
        _processadorDePedidos.OnPedidoProcessado += LoggerPedido;
        _processadorDePedidos.OnPedidoProcessado += NotificarCliente;
    }
    public void Dispose()
    {
        _processadorDePedidos.OnPedidoProcessado -= LoggerPedido;
        _processadorDePedidos.OnPedidoProcessado -= NotificarCliente;
        MensagemConsole.warningMsg($"[LOG {DateTime.Now.ToLongTimeString()}]: Dipose finalizado. Horário: " + DateTime.Now.ToLongTimeString());
    }
    private void NotificarCliente(int idDoPedido)
    {
        MensagemConsole.successMsg($"[CALLBACK SNS]: Notificação recebida: Pedido {idDoPedido} pronto para envio!");
    }
    private void LoggerPedido(int idDoPedido)
    {
        MensagemConsole.successMsg($"[LOG {DateTime.Now.ToLongTimeString()}]: Pedido {idDoPedido} concluído com sucesso às {DateTime.Now.ToLongTimeString()}.");
    }
}
