using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void FiltrarYOrdenar(decimal precioMinimo)
        {
            var productosFiltrados = productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);

            Console.WriteLine("Productos filtrados y ordenados:");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }
        }

        public void ActualizarPrecio(string nombreProducto, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre == nombreProducto);
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine("Precio actualizado.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(string nombreProducto)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre == nombreProducto);
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("Producto eliminado.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void ContarYAgruparProductos()
        {
            var grupos = productos.GroupBy(p =>
                p.Precio < 100 ? "Menores a 100" : p.Precio <= 500 ? "Entre 100 y 500" : "Mayores a 500");

            foreach (var grupo in grupos)
            {
                Console.WriteLine($"{grupo.Key}: {grupo.Count()} productos");
            }
        }

        public void GenerarReporte()
        {
            Console.WriteLine($"Total de productos: {productos.Count}");
            Console.WriteLine($"Precio promedio: {productos.Average(p => p.Precio):C}");

            var productoMasCaro = productos.OrderByDescending(p => p.Precio).First();
            var productoMasBarato = productos.OrderBy(p => p.Precio).First();

            Console.WriteLine($"Producto más caro: {productoMasCaro.Nombre} - {productoMasCaro.Precio:C}");
            Console.WriteLine($"Producto más barato: {productoMasBarato.Nombre} - {productoMasBarato.Precio:C}");
        }
    }

}
