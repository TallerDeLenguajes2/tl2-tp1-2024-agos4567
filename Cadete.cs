using System;
using System.Collections.Generic;


namespace EspacioDatos
{
    public class Cadete
    {
        private int id;

        private string? nombre;

        private string? direccion;

        private int telefono;

         private List<Pedido> listadoPedidos;



        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }


        //constructor


        public Cadete(int id, string nombre, string direccion, int telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;

               // Inicializo la lista de pedidos
            ListadoPedidos = new List<Pedido>();
}
   
            public double JornalACobrar()
        {
            double valorPorPedido = 50; 
            return ListadoPedidos.Count * valorPorPedido;
        }

           // agrego un pedido al listado
        public void AgregarPedido(Pedido pedido)
        {
            ListadoPedidos.Add(pedido);
        }



    

  }
  
  
  }