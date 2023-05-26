using MVC_PruebaTecnica.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_PruebaTecnica.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private const string CacheKey = "ProductosCache";

        public List<Producto> productos;

        // Acción para mostrar la lista de productos
        public ActionResult Index()
        {

            if (HttpContext.Cache[CacheKey] != null)
            {
                productos = (List<Producto>)HttpContext.Cache[CacheKey];
            }
            else
            {
                // Obtener productos de la base de datos
                productos = new List<Producto>
                {
                    new Producto { Id = 1, Nombre = "Producto1", Tipo = "Tipo1", CantidadActual = 10, CantidadPedido = 5, CantidadVendida = 0,PrecioVenta = 10.5m },
                    // Agrega los demás productos aquí
                    new Producto { Id = 2, Nombre = "Producto2", Tipo = "Tipo2", CantidadActual = 10, CantidadPedido = 5, CantidadVendida = 0,PrecioVenta = 10.5m },
                };

                HttpContext.Cache[CacheKey] = productos; // Almacenar productos en la caché
            }

            return View(productos);
        }

        // Acción para vender unidades de un producto
        public ActionResult Vender(int id, int cantidad)
        {
            List<Producto> productos = (List<Producto>)HttpContext.Cache[CacheKey];
            Producto producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                // Realizar la venta y restar la cantidad vendida
                producto.CantidadActual -= cantidad;

                // Realizar la venta y restar la cantidad vendida
                producto.CantidadVendida += cantidad;

                // Actualizar la entrada de la caché
                HttpContext.Cache[CacheKey] = productos;
            }

            return RedirectToAction("Index");
        }


        // Acción para hacer un pedido de un producto
        public ActionResult HacerPedido(int id, int cantidad)
        {
            List<Producto> productos = (List<Producto>)HttpContext.Cache[CacheKey];
            Producto producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                // Realizar el pedido y agregar la cantidad solicitada
                producto.CantidadActual += cantidad;

                // Actualizar la entrada de la caché
                HttpContext.Cache[CacheKey] = productos;
            }

            return RedirectToAction("Index");

        }


        /// <summary>
        /// Acción para ver el producto más vendido
        /// </summary>
        /// <returns></returns>
        public ActionResult MasVendido()
        {
            List<Producto> productos = (List<Producto>)HttpContext.Cache[CacheKey];

            Producto productoMasVendido = productos.OrderByDescending(p => p.CantidadVendida).FirstOrDefault();

            return View(productoMasVendido);
        }

        /// <summary>
        /// Acción para ver el producto menos vendido
        /// </summary>
        /// <returns></returns>
        public ActionResult MenosVendido()
        {
            List<Producto> productos = (List<Producto>)HttpContext.Cache[CacheKey];

            Producto productoMenosVendido = productos.OrderBy(p => p.CantidadVendida).FirstOrDefault();

            return View(productoMenosVendido);
        }

        /// <summary>
        /// Acción para ver el total de ventas
        /// </summary>
        /// <returns></returns>
        public ActionResult TotalVentas()
        {
            List<Producto> productos = (List<Producto>)HttpContext.Cache[CacheKey];

            decimal totalVentas = productos.Sum(p => p.CantidadVendida * p.PrecioVenta);

            ViewBag.TotalVentas = totalVentas;

            return View();
        }
    }
}