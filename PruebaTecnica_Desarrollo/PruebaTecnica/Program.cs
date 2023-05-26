using System;
using System.Collections.Generic;

namespace ControlInventarioDrogueria
{
    class Program
    {
        static List<Producto> inventario = new List<Producto>();
        static decimal totalVentas = 0;

        static void Main(string[] args)
        {
            // Agregar productos iniciales al inventario
            inventario.Add(new Producto("Producto 1", "Tipo 1", 50, 10, 10.5m));
            inventario.Add(new Producto("Producto 2", "Tipo 2", 30, 15, 8.2m));
            inventario.Add(new Producto("Producto 3", "Tipo 1", 20, 5, 12.0m));
            // Agregar más productos aquí...

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("1. Vender producto");
                Console.WriteLine("2. Hacer pedido de producto");
                Console.WriteLine("3. Mostrar producto más vendido");
                Console.WriteLine("4. Mostrar producto menos vendido");
                Console.WriteLine("5. Mostrar cantidad total de dinero obtenido por ventas");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Ingrese el número de la opción deseada:");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VenderProducto();
                        break;
                    case "2":
                        HacerPedido();
                        break;
                    case "3":
                        MostrarProductoMasVendido();
                        break;
                    case "4":
                        MostrarProductoMenosVendido();
                        break;
                    case "5":
                        MostrarTotalVentas();
                        break;
                    case "6":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, ingrese un número válido.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void VenderProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto a vender:");
            string nombre = Console.ReadLine();

            Producto producto = BuscarProducto(nombre);
            if (producto != null)
            {
                Console.WriteLine("Ingrese la cantidad a vender:");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                if (cantidad <= producto.CantidadActual)
                {
                    decimal totalVenta = cantidad * producto.PrecioVenta;
                    Console.WriteLine($"Venta realizada. Total a pagar: ${totalVenta}");
                    producto.CantidadActual -= cantidad;
                    totalVentas += totalVenta;
                }
                else
                {
                    Console.WriteLine("No hay suficientes unidades en inventario para realizar la venta.");
                }
            }
            else
            {
                Console.WriteLine("El producto ingresado no existe en el inventario.");
            }
        }

        static void HacerPedido()
        {
            Console.WriteLine("Ingrese el nombre del producto a pedir:");
            string nombre = Console.ReadLine();

            Producto producto = BuscarProducto(nombre);
            if (producto != null)
            {
                Console.WriteLine("Ingrese la cantidad a pedir:");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                producto.CantidadActual += cantidad;
                Console.WriteLine("Pedido realizado correctamente.");
            }
            else
            {
                Console.WriteLine("El producto ingresado no existe en el inventario.");
            }
        }

        static void MostrarProductoMasVendido()
        {
            Producto productoMasVendido = null;
            int maxVentas = 0;

            foreach (Producto producto in inventario)
            {
                if (producto.CantidadVentas > maxVentas)
                {
                    maxVentas = producto.CantidadVentas;
                    productoMasVendido = producto;
                }
            }

            if (productoMasVendido != null)
            {
                Console.WriteLine("Producto más vendido:");
                Console.WriteLine($"Nombre: {productoMasVendido.Nombre}");
                Console.WriteLine($"Tipo: {productoMasVendido.Tipo}");
                Console.WriteLine($"Unidades vendidas: {productoMasVendido.CantidadVentas}");
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
        }

        static void MostrarProductoMenosVendido()
        {
            Producto productoMenosVendido = null;
            int minVentas = int.MaxValue;

            foreach (Producto producto in inventario)
            {
                if (producto.CantidadVentas < minVentas)
                {
                    minVentas = producto.CantidadVentas;
                    productoMenosVendido = producto;
                }
            }

            if (productoMenosVendido != null)
            {
                Console.WriteLine("Producto menos vendido:");
                Console.WriteLine($"Nombre: {productoMenosVendido.Nombre}");
                Console.WriteLine($"Tipo: {productoMenosVendido.Tipo}");
                Console.WriteLine($"Unidades vendidas: {productoMenosVendido.CantidadVentas}");
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
        }

        static void MostrarTotalVentas()
        {
            Console.WriteLine($"Cantidad total de dinero obtenido por ventas: ${totalVentas}");
        }

        static Producto BuscarProducto(string nombre)
        {
            foreach (Producto producto in inventario)
            {
                if (producto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return producto;
                }
            }

            return null;
        }
    }

    class Producto
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int CantidadActual { get; set; }
        public int CantidadPedido { get; set; }
        public decimal PrecioVenta { get; set; }
        public int CantidadVentas { get; set; }

        public Producto(string nombre, string tipo, int cantidadActual, int cantidadPedido, decimal precioVenta)
        {
            Nombre = nombre;
            Tipo = tipo;
            CantidadActual = cantidadActual;
            CantidadPedido = cantidadPedido;
            PrecioVenta = precioVenta;
            CantidadVentas = 0;
        }
    }
}

