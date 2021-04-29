using System;

namespace CalculadoraDePrestamos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("CALCULADORA DE PRESTAMOAS");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();            
            Console.WriteLine();
            Console.WriteLine("Favor ingresar monto de prestamo:");
            string valorPrestamo = Console.ReadLine();
            Console.WriteLine("Favor ingresar cantidad de coutas:");
            string valorCoutas = Console.ReadLine();
            Console.WriteLine("Favor ingresar interes anual:");
            string valorInteres = Console.ReadLine();
                                    
            var prestamo = new Prestamo()
            {
                InteresAnual = float.Parse(valorInteres),
                CantidadCoutas = int.Parse(valorCoutas),
                MontoPrestamo =  double.Parse(valorPrestamo)
            };

            prestamo.ImprimirTablaAmortizacion();
        }
    }
}
