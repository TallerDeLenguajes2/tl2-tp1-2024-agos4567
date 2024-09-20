
namespace EspacioDatos
{
    public class Cadeteria
    {
        private string? nombre;

        private string telefono;
        //    private List<Cadete> listadoCadetes;
     private List<Cadete> listadoCadetes = new List<Cadete>();
     
        // Nueva lista para pedidos dados de alta
        private List<Pedido> pedidosDisponibles = new List<Pedido>();
        

        public string? Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        // public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
         public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> PedidosDisponibles { get => pedidosDisponibles; set => pedidosDisponibles = value; }



        //     public Cadeteria(){

        //     ListadoCadetes = new List<Cadete>();
        // }

        public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        // Direccion = direccion;
        Telefono = telefono;
    }
    // public void AgregarCadete(Cadete cadete)
    // {
    //     listadoCadetes.Add(cadete);
    // }



        public void AgregarCadete(Cadete nuevoCadete)
        {
            if (nuevoCadete != null)
            {
                listadoCadetes.Add(nuevoCadete);
            }
        }

          // metodo para buscar un pedido por su id
        public Pedido? BuscarPedidoPorId(int pedidoId)
        {
            foreach (var pedido in pedidosDisponibles)
            {
                if (pedido.Nro == pedidoId)
                {
                    return pedido;
                }
            }
            return null; // Retorna null si no se encuentra el pedido
        }



   // metodo para asignar un pedido a un cadete
   public void AsignarPedidoACadete(int cadeteId, int pedidoId)
{
    // Buscar el pedido en la lista de pedidos disponibles
    Pedido? pedido = BuscarPedidoPorId(pedidoId);
    
    if (pedido == null)
    {
        Console.WriteLine("El pedido no ha sido dado de alta y no puede ser asignado.");
        return;
    }

    // Si no se encuentra el cadete, se lanza una excepción
    Cadete? cadete = listadoCadetes.FirstOrDefault(c => c.Id == cadeteId);

    if (cadete != null)
    {
        cadete.AgregarPedido(pedido);
        // Una vez asignado el pedido, podrías removerlo de la lista de pedidos disponibles si es necesario
        // pedidosDisponibles.Remove(pedido);
    }
    else
    {
        throw new Exception("Cadete no encontrado.");
    }
}

//    public void AsignarPedidoACadete(int cadeteId, Pedido pedido) // cambia el segundo paramtro de int a Pedido
// {
//     if (listadoCadetes == null)
//     {
//         listadoCadetes = new List<Cadete>();
//     }

//     Cadete? cadete = null;

//     // Buscar el cadete por su ID
//     foreach (var c in listadoCadetes)
//     {
//         if (c.Id == cadeteId)
//         {
//             cadete = c;
//             break; // salir del bucle si se encuentra el cadete
//         }
//     }

//     // si el cadete fue encontrado, asignar el pedido
//     if (cadete != null)
//     {
//         cadete.AgregarPedido(pedido);
//     }
//     else
//     {
//         throw new Exception("Cadete no encontrado");
//     }
// }


       // reasignar un pedido de un cadete a otro
       public void ReasignarPedido(int pedidoId, int nuevoCadeteId)
{
    Pedido? pedido = BuscarPedidoPorId(pedidoId);

    if (pedido == null)
    {
        Console.WriteLine("El pedido no ha sido dado de alta y no puede ser reasignado.");
        return;
    }

    Cadete? cadeteActual = null;

    // Buscar el pedido en los cadetes
    foreach (var cadete in listadoCadetes)
    {
        if (cadete.ListadoPedidos.Contains(pedido))
        {
            cadeteActual = cadete;
            break;
        }
    }

    if (cadeteActual != null)
    {
        cadeteActual.ListadoPedidos.Remove(pedido);
        AsignarPedidoACadete(nuevoCadeteId, pedidoId);
    }
    else
    {
        Console.WriteLine("El pedido no está asignado a ningún cadete.");
    }
}

        // public void ReasignarPedido(int pedidoId, int nuevoCadeteId)
        // {
        //     Pedido? pedido = null;
        //     Cadete? cadeteActual = null;

        //     // Buscar el pedido en los cadetes
        //     foreach (var cadete in listadoCadetes)
        //     {
        //         foreach (var p in cadete.ListadoPedidos)
        //         {
        //             if (p.Nro == pedidoId)
        //             {
        //                 pedido = p;
        //                 cadeteActual = cadete;
        //                 break; // salir  del bucle si se encuentra el pedido
        //             }
        //         }

        //         if (pedido != null)
        //         {
        //             break; // salir  del bucle exterior si ya se encontró el pedido
        //         }
        //     }

        //         //si el pedido fue encontrado, reasignarlo al nuevo cadete
        //         if (pedido != null && cadeteActual != null)
        //         {
        //             cadeteActual.ListadoPedidos.Remove(pedido);
        //             AsignarPedidoACadete(nuevoCadeteId, pedido);
        //         }
        //         else
        //         {
        //             throw new Exception("Pedido o Cadete no encontrado");
        //         }
        // }

        // // Mostrar un informe de todos los cadetes y sus pedidos
        // public void MostrarInforme()
        // {
        //     foreach (var cadete in listadoCadetes)
        //     {
        //         Console.WriteLine($"Cadete: {cadete.Nombre}, Pedidos Asignados: {cadete.ListadoPedidos.Count}, Jornal: {cadete.JornalACobrar()}");
        //     }
        // }
        
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
                if (cadete.ListadoPedidos == null)
                {
                    cadete.ListadoPedidos = new List<Pedido>();
                }

                totalJornal += cadete.JornalACobrar();
                totalEnvios += cadete.ListadoPedidos.Count;
            }

            double promedioEnvios = (double)totalEnvios / ListadoCadetes.Count;

            foreach (var cadete in ListadoCadetes)
            {
                Console.WriteLine($"Cadete: {cadete.Nombre}, Pedidos Asignados: {cadete.ListadoPedidos.Count}, Jornal: {cadete.JornalACobrar()}");
            }

            Console.WriteLine($"Total Jornal: {totalJornal}, Total Envíos: {totalEnvios}, Promedio Envíos por Cadete: {promedioEnvios:F2}");
        }
            
    }
}