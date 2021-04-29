using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraDePrestamos
{
    public class Cuota
    {
        public int NumeroCouta { get; set; }
        public DateTime Fecha { get; set; }
        public double MontoInteres { get; set; }
        public double MontoCapital { get; set; }
        public double Balance { get; set; }
        public double Couta { get; set; }
    }
}
