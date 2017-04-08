using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el texto");
            string texto;
            texto = Console.ReadLine();
            new ChangeString().build(texto);
        }

        // DESCOMENTAR PARA USAR EJERCICIO 2
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Ingrese el texto");
        //    string texto;
        //    texto = Console.ReadLine();
        //    new CompleteRange().build(texto);
        //}


        // DESCOMENTAR PARA USAR EJERCICIO 3
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Ingrese el valor");
        //    string texto;
        //    texto = Console.ReadLine();
        //    var valor = 0.0m;
        //    valor = Convert.ToDecimal(texto);
        //    new MoneyParts().build(valor);
        //}
    }
}
