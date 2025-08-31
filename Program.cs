
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
                string archivoCadetes = "Cadete.csv";
                string archivoCadeteria = "Cadeteria.csv";

                // Crear una instancia de GestorCsv para manejar la carga de datos
                GestorCsv gestorCsv = new GestorCsv();

                // Cargar los cadetes desde el archivo CSV
                List<Cadete> cadetes = gestorCsv.CargarCadetesDesdeCsv(archivoCadetes);

                // Cargar la cadetería desde el archivo CSV
                Cadeteria cadeteria = gestorCsv.CargarCadeteriaDesdeCsv(archivoCadeteria);

                // Asignar los cadetes cargados a la Cadeteria
                foreach (var cadete in cadetes)
                {
                    cadeteria.AgregarCadete(cadete);
                }

                // Mostrar un informe inicial de la cadetería y los cadetes
                cadeteria.MostrarInforme();

                // Llamar al menú interactivo
                MostrarMenu(cadeteria);






                static void MostrarMenu(Cadeteria cadeteria){

                int opcion = 0;
                while (opcion != 5) // Cambia 4 a 5 para incluir la nueva opción
                {
                    Console.WriteLine("\n--- MENÚ DE OPCIONES ---");
                
                     Console.WriteLine("1. Dar de alta un pedido");
                    Console.WriteLine("2. Asignar pedido a cadete");
                    Console.WriteLine("3. Reasignar pedido");
                    Console.WriteLine("4. Mostrar informe de cadetes");
                    Console.WriteLine("5. Salir");
                    Console.Write("Elija una opción: ");
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                             DarDeAltaPedido(cadeteria);
                           
                            break;
                        case 2:
                             AsignarPedidoACadete(cadeteria);
                            
                            break;
                        case 3:
                            ReasignarPedido(cadeteria);
                           
                            break;
                        case 4: // Nueva opción
                          cadeteria.MostrarInforme();
                            break;
                        case 5:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida, intente de nuevo.");
                            break;
                    }
                }
            }

                static  void DarDeAltaPedido(Cadeteria cadeteria){
            
                int nroPedido;
                Console.Write("Ingrese el número de pedido: ");
                while (!int.TryParse(Console.ReadLine(), out nroPedido))
                {
                    Console.WriteLine("No ingresó un número válido. Inténtelo de nuevo.");
                }

                // Información del cliente
                Console.WriteLine("Ingrese una observación para el pedido:");
                string? observacion = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del cliente:");
                string? nombreCliente = Console.ReadLine();
                Console.WriteLine("Ingrese la dirección del cliente:");
                string? direccionCliente = Console.ReadLine();
                Console.WriteLine("Ingrese el teléfono del cliente:");
                int telefonoCliente; // Cambiado a int, asumiendo que es un número
                while (!int.TryParse(Console.ReadLine(), out telefonoCliente))
                {
                    Console.WriteLine("No ingresó un número válido. Inténtelo de nuevo.");
                }
                Console.WriteLine("Ingrese datos de referencia del cliente:");
                string? datosDeReferencia = Console.ReadLine(); // Agregar esta línea

                // Crear el objeto cliente con todos los parámetros
                Clientes nuevoCliente = new Clientes(nombreCliente, direccionCliente, telefonoCliente, datosDeReferencia);

                // Crear el nuevo pedido
                Pedido nuevoPedido = new Pedido(nroPedido, observacion, nuevoCliente, EstadoPedido.Pendiente);
                // 🔹 Agregar el pedido a la lista de pedidos de la cadetería
                cadeteria.PedidosDisponibles.Add(nuevoPedido);
              // Mensaje de confirmación
                Console.WriteLine("Pedido dado de alta exitosamente.");
  
 
        }

  

                static void AsignarPedidoACadete(Cadeteria cadeteria){
            
                Console.WriteLine("Ingrese el ID del cadete:");
                if (!int.TryParse(Console.ReadLine(), out int cadeteId))
                {
                    Console.WriteLine("ID de cadete inválido.");
                    return;
                }

                Console.WriteLine("Ingrese el ID del pedido:");
                if (!int.TryParse(Console.ReadLine(), out int pedidoId))
                {
                    Console.WriteLine("ID de pedido inválido.");
                    return;
                }

                // Verifico si existen
                var cadete = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == cadeteId);
                var pedido = cadeteria.PedidosDisponibles.FirstOrDefault(p => p.Nro == pedidoId);

                if (cadete == null)
                {
                    Console.WriteLine("No se encontró un cadete con ese ID.");
                    return;
                }
                if (pedido == null)
                {
                    Console.WriteLine("No se encontró un pedido con ese número. Primero debe darlo de alta.");
                    return;
                }

                cadeteria.AsignarPedidoACadete(cadeteId, pedidoId);
                Console.WriteLine("Pedido asignado al cadete exitosamente.");
                      
                }
                    
        

            static void ReasignarPedido(Cadeteria cadeteria)
            {
                Console.WriteLine("Ingrese el ID del pedido a reasignar:");
                int pedidoId = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo ID del cadete:");
                int nuevoCadeteId = int.Parse(Console.ReadLine());

                cadeteria.ReasignarPedido(pedidoId, nuevoCadeteId);
                Console.WriteLine("Pedido reasignado al cadete exitosamente.");

            }




        }




    }




}
