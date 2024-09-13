using EspacioDatos;
using System.Collections.Generic;
using System;

namespace CadeteriaApp
{
    class Program
    {
            static void Main(string[] args)
            {
                // Ruta de los archivos CSV
              // Ruta de los archivos CSV
            string archivoCadetes = "Cadete.csv";
            string archivoCadeteria = "Cadeteria.csv";

            // Crear una instancia de GestorCsv para manejar la carga de datos
            GestorCsv gestorCsv = new GestorCsv();

            // Cargar los cadetes desde el archivo CSV
            List<Cadete> cadetes = gestorCsv.CargarCadetesDesdeCsv(archivoCadetes);

            // Cargar la cadetería desde el archivo CSV
            Cadeteria cadeteria = gestorCsv.CargarCadeteriaDesdeCsv(archivoCadeteria);

            // Verificar si la carga de la cadetería fue exitosa antes de proceder
            if (cadeteria == null)
            {
                Console.WriteLine("No se pudo cargar la cadetería desde el archivo.");
                return;
            }

            // Asignar los cadetes cargados a la Cadeteria
            foreach (var cadete in cadetes)
            {
                cadeteria.AgregarCadete(cadete);
            }

            // Mostrar un informe inicial de la cadetería y los cadetes
            cadeteria.MostrarInforme();

            // Llamar al menú interactivo
            MostrarMenu(cadeteria);
        }

        static void MostrarMenu(Cadeteria cadeteria)
        {
            int opcion = 0;
            while (opcion != 5) // Cambia 4 a 5 para incluir la nueva opción
            {
                Console.WriteLine("\n--- MENÚ DE OPCIONES ---");
                Console.WriteLine("1. Asignar pedido a cadete");
                Console.WriteLine("2. Reasignar pedido");
                Console.WriteLine("3. Mostrar informe de cadetes");
                Console.WriteLine("4. Dar de alta pedido"); // Nueva opción
                Console.WriteLine("5. Salir");
                Console.Write("Elija una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AsignarPedidoACadete(cadeteria);
                        break;
                    case 2:
                        ReasignarPedido(cadeteria);
                        break;
                    case 3:
                        cadeteria.MostrarInforme();
                        break;
                    case 4: // Nueva opción
                        DarDeAltaPedido(cadeteria);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            }
                static void DarDeAltaPedido(Cadeteria cadeteria)
                {
                    Console.WriteLine("Dar de alta pedido:");

                    // Datos del cliente
                    Console.Write("Nombre del cliente: ");
                    string? nombreCliente = Console.ReadLine();
                    Console.Write("Dirección del cliente: ");
                    string? direccionCliente = Console.ReadLine();
                    Console.Write("Teléfono del cliente: ");
                    int telefonoCliente = int.Parse(Console.ReadLine());
                    Console.Write("Referencia de dirección: ");
                    string? referenciaDireccion = Console.ReadLine();

                    Clientes cliente = new Clientes(nombreCliente, direccionCliente, telefonoCliente, referenciaDireccion);

                    // Datos del pedido
                    Console.Write("Número de pedido: ");
                    int nroPedido = int.Parse(Console.ReadLine());
                    Console.Write("Observación del pedido: ");
                    string observacion = Console.ReadLine();

                    Pedido nuevoPedido = new Pedido(nroPedido, observacion, cliente, EstadoPedido.Pendiente);

                    // Agregar el pedido a la lista de pedidos disponibles en la cadetería
                    cadeteria.PedidosDisponibles.Add(nuevoPedido);

                    Console.WriteLine("Pedido dado de alta con éxito.");
                }

             static void AsignarPedidoACadete(Cadeteria cadeteria)
{
    Console.WriteLine("Ingrese el ID del cadete:");
    string? cadeteIdInput = Console.ReadLine(); // permite el ingreso nulo

    if (!int.TryParse(cadeteIdInput, out int cadeteId)) // verifica si el valor es un número válido
    {
        Console.WriteLine("ID de cadete inválido.");
        return;
    }

    Console.WriteLine("Ingrese el número del pedido:");
    string? pedidoIdInput = Console.ReadLine(); // permite el ingreso nulo

    if (!int.TryParse(pedidoIdInput, out int pedidoId)) // verifica si el valor es un número válido
    {
        Console.WriteLine("Número de pedido inválido.");
        return;
    }

    // Verificar si el pedido ya existe utilizando el método BuscarPedidoPorId
    Pedido? pedido = cadeteria.BuscarPedidoPorId(pedidoId); // Método que busca el pedido en la lista de pedidos

    if (pedido == null)
    {
        Console.WriteLine("El pedido no existe. Debe dar de alta el pedido antes de asignarlo.");
        return; // Salir si el pedido no existe
    }

    try
    {
        // Asignar el pedido al cadete (corrección de los parámetros)
        cadeteria.AsignarPedidoACadete(pedidoId, cadeteId); // Pasar los IDs en lugar del objeto Pedido
        Console.WriteLine("Pedido asignado al cadete con éxito.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al asignar el pedido: {ex.Message}");
    }
}


            static void ReasignarPedido(Cadeteria cadeteria)
            {
                Console.WriteLine("Ingrese el ID del pedido a reasignar:");
                int pedidoId = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo ID del cadete:");
                int nuevoCadeteId = int.Parse(Console.ReadLine());

                cadeteria.ReasignarPedido(pedidoId, nuevoCadeteId);
            }




        }




    }




}
