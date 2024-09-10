namespace EspacioDatos
{
     public enum EstadoPedido
    {
        Pendiente,
        EnProceso,
        Entregado,
        Cancelado
    }
    public class Pedido
    {
        private int nro;
        private string? observacion;

         private Clientes cliente;

          private EstadoPedido estado;

        public int Nro { get => nro; set => nro = value; }
        public string? Observacion { get => observacion; set => observacion = value; }
        public Clientes Cliente { get => cliente; set => cliente = value; }
        public EstadoPedido Estado { get => estado; set => estado = value; }


        public Pedido(int nro, string observacion, Clientes cliente, EstadoPedido estado)
        {
            Nro = nro;
            Observacion = observacion;
            Cliente = cliente;
            Estado = estado;
        }
        
         // metodo para cambiar el estado del pedido
        public void CambiarEstado(EstadoPedido nuevoEstado)
        {
            Estado = nuevoEstado;
        }


    }
}