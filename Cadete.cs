using System;
using System.Collections.Generic;


namespace EspacioDatos
{
    public class Cadete
    {
        private int id;

        private string? nombre;

        private string? direccion;

        private string telefono;

        //  private List<Pedido> listadoPedidos;

    //  private List<Pedido> listadoPedidos = new List<Pedido>(); 

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        // public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    //    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        //constructor


        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;

               // Inicializo la lista de pedidos
            // ListadoPedidos = new List<Pedido>();
}
   
        //     public double JornalACobrar()
        // {
        //     double valorPorPedido = 50; 
        //     return ListadoPedidos.Count * valorPorPedido;
        // }

        //    // agrego un pedido al listado
        //  public void AgregarPedido(Pedido pedido)
        // {
        //     if (pedido != null)
        //     {
        //         ListadoPedidos.Add(pedido);
        //     }
        //     else
        //     {
        //         throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo.");
        //     }
        // }



    

  }
  
  
  }