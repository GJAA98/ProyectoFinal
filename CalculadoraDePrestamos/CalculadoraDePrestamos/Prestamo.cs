using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraDePrestamos
{
    public class Prestamo
    {        
        public float InteresAnual { get; set; }
        public int CantidadCoutas { get; set; }
        public double MontoPrestamo { get; set; }

        public Cuota[] ObtenerTabla()
        {
            Cuota[] cuotas = new Cuota[CantidadCoutas];            
            double interesMensual = ObtenerInteresMensual();
            double pagoMensual = ObtenerPagoMensual();
            double balance = MontoPrestamo;
            DateTime fecha = DateTime.Now.Date;
            for (int i = 0; i < CantidadCoutas; i++)
            {

                double montoInteresCouta = Math.Round(balance * interesMensual,3);
                double pagoCapitalCouta = pagoMensual - montoInteresCouta;
                fecha = fecha.AddMonths(1);
                balance -= pagoCapitalCouta;
                cuotas[i] = new Cuota
                {
                    NumeroCouta = i+1,
                    Fecha = fecha,
                    MontoInteres = Math.Round(montoInteresCouta,3),
                    MontoCapital = Math.Round(pagoCapitalCouta,3),
                    Balance =Math.Round(balance),
                    Couta = pagoMensual
                };                
            }
            return cuotas;
        }

        public void ImprimirTablaAmortizacion()
        {
            var coutas = ObtenerTabla();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tabla de Amortizacion de Prestamo");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Monto de Prestamo Solicitado: {0:C}", MontoPrestamo);
            Console.WriteLine("Cantidad de Coutas:" + CantidadCoutas);
            Console.WriteLine("Tasa de interes anual: {0:P}", (InteresAnual/100));
            Console.WriteLine("Tasa de interes mensual: {0:P}", ObtenerInteresMensual());
            Console.WriteLine("Pago de prestamo:{0:C}", ObtenerPagoMensual());

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("{0}     {1,10}{2,15}{3,20}{4,15}{5,15}", "Numero", "Fecha",  "Couta", "Capital", "Interes","Balance");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            foreach (var couta in coutas)
            {
                Console.WriteLine("{0,5}    {1,15}{2,15:C}{3,15:C}{4,15:C}{5,15:C}", couta.NumeroCouta, couta.Fecha.ToString("dd/MM/yyyy"), couta.Couta, couta.MontoCapital, couta.MontoInteres, couta.Balance);
            }
        }

        public double ObtenerPagoMensual()
        {
            var interesMensual = ObtenerInteresMensual();
            double pagoMensual = (MontoPrestamo * interesMensual) / (1 - Math.Pow((1 + interesMensual),-CantidadCoutas));
            return Math.Round(pagoMensual,2);
        }

        public double ObtenerInteresMensual()
        {
            var interes = Math.Pow((1d + (InteresAnual / 100d)), (30d / 360d)) - 1d;
            return Math.Round(interes,2);
        }
    }
}
