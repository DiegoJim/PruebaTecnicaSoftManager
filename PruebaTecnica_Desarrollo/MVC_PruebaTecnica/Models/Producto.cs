using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_PruebaTecnica.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int CantidadActual { get; set; }
        public int CantidadPedido { get; set; }
        public int CantidadVendida { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}