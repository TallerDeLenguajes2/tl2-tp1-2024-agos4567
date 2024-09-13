using System;
using System.Collections.Generic;
using System.Linq;

namespace EspacioDatos
{
    public class Cadeteria
    {
        private string? nombre;
        private string telefono;
        private List<Cadete> listadoCadetes = new List<Cadete>(); // Lista de cadetes
        private List<Pedido> pedidosDisponibles = new List<Pedido>(); // Lista de pedidos

        public string? Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> PedidosDisponibles { get => pedidosDisponibles; set => pedidosDisponibles = value; }

        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }

        public void AgregarCadete(Cadete nuevoCadete)
        {
            if (nuevoCadete != null)
            {
                listadoCadetes.Add(nuevoCadete);
            }
        }

        public Pedido? BuscarPedidoPorId(int pedidoId)
        {
            return pedidosDisponibles.FirstOrDefault(pedido => pedido.Nro == pedidoId);
        }

        // Asignar un pedido a un cadete
        public void AsignarPedidoACadete(int pedidoId, int cadeteId)
        {
            Pedido? pedido = BuscarPedidoPorId(pedidoId);
            Cadete? cadete = listadoCadetes.FirstOrDefault(c => c.Id == cadeteId);

            if (pedido == null)
            {
                throw new Exception("Pedido no encontrado.");
            }

            if (cadete == null)
            {
                throw new Exception("Cadete no encontrado.");
            }

            // Asignar el pedido al cadete
            pedido.CadeteAsignado = cadete;
        }

        // Reasignar un pedido de un cadete a otro
        public void ReasignarPedido(int pedidoId, int nuevoCadeteId)
        {
            Pedido? pedido = BuscarPedidoPorId(pedidoId);
            Cadete? nuevoCadete = listadoCadetes.FirstOrDefault(c => c.Id == nuevoCadeteId);

            if (pedido == null)
            {
                throw new Exception("Pedido no encontrado.");
            }

            if (nuevoCadete == null)
            {
                throw new Exception("Nuevo cadete no encontrado.");
            }

            // Reasignar el pedido al nuevo cadete
            pedido.CadeteAsignado = nuevoCadete;
        }

        public void MostrarInforme()
        {
            if (ListadoCadetes == null || !ListadoCadetes.Any())
            {
                Console.WriteLine("No hay cadetes disponibles para mostrar el informe.");
                return;
            }

            double totalJornal = 0;
            int totalEnvios = 0;

            foreach (var cadete in ListadoCadetes)
            {
                // Filtrar los pedidos asignados a este cadete
                var pedidosDelCadete = PedidosDisponibles.Where(p => p.CadeteAsignado == cadete).ToList();
                double jornal = pedidosDelCadete.Count * 50; // Calcula jornal para cada cadete (50 es un ejemplo de tarifa por pedido)

                totalJornal += jornal;
                totalEnvios += pedidosDelCadete.Count;

                Console.WriteLine($"Cadete: {cadete.Nombre}, Pedidos Asignados: {pedidosDelCadete.Count}, Jornal: {jornal}");
            }

            double promedioEnvios = (double)totalEnvios / ListadoCadetes.Count;
            Console.WriteLine($"Total Jornal: {totalJornal}, Total Envíos: {totalEnvios}, Promedio Envíos por Cadete: {promedioEnvios:F2}");
        }
    }
}
