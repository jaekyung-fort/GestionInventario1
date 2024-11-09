using GestionInventario; 
using System;

public class Program
{
    public static void Main(string[] args)
    {

        Inventario inventario = new Inventario();

        while (true)
        {
            Console.WriteLine("Ingrese el nombre del producto (y 'o' para terminar):");
            string nombre = Console.ReadLine();
            if (nombre.ToLower() == "o") break;

            Console.WriteLine("Ingrese el precio del producto:");
            if (decimal.TryParse(Console.ReadLine(), out decimal precio) && precio > 0)
            {
                inventario.AgregarProducto(new Producto(nombre, precio));
            }
            else
            {
                Console.WriteLine("Precio inválido. Intente nuevamente.");
            }
        }

        Console.WriteLine("Ingrese el precio mínimo para filtrar:");
        if (decimal.TryParse(Console.ReadLine(), out decimal precioMinimo))
        {
            inventario.FiltrarYOrdenar(precioMinimo);
        }


        inventario.ContarYAgruparProductos();

        inventario.GenerarReporte();

    }
}
