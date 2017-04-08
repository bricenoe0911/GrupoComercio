using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBuild
{
    public class MoneyParts
    {
        decimal[] denominaciones = new decimal[] { 0.05m, 0.1m, 0.2m, 0.5m, 1, 2, 5, 10, 20, 50, 100, 200 };
        public void build(decimal numero)
        {
            var resultado = string.Empty;
            var suma = 0.0m;
            var filtroDenominacion = denominaciones.Where(s => s <= numero).ToList();

            foreach (var item in filtroDenominacion)
            {
                suma = 0.0m;
                resultado = string.Empty;

                if (item != numero)
                {
                    if (numero % item == 0)
                    {
                        var cantidadRepetir = numero / item;

                        for (int i = 1; i <= cantidadRepetir; i++)
                        {
                            var x = i;

                            suma += item;
                            if (suma == numero)
                            {
                                for (int s = 0; s < x; s++)
                                {
                                    resultado += item.ToString() + ",";
                                }
                                break;
                            }
                        }
                        if (resultado.Length > 0)
                        {
                            resultado = "[" + resultado.Substring(0, resultado.Length - 1) + "]";
                            Console.WriteLine(resultado);
                        }
                    }
                    else
                    {
                        ResolverNoDivisible(numero, item);
                    }
                }
                else
                {
                    resultado = "[" + item.ToString() + "]";
                    Console.WriteLine(resultado);
                }
            }
            Console.ReadKey();
        }

        public void ResolverNoDivisible(decimal numero, decimal denominador)
        {
            var suma = 0.0m;
            var resultado = string.Empty;
            var limite = 0.0m;
            var restante = 0.0m;

            suma = denominador;

            while (suma < numero)
            {
                suma += denominador;
                resultado += denominador.ToString() + ",";
            }

            suma -= denominador;
            limite = suma;

            if (limite < numero)
            {
                restante = numero - suma;

                var filtroDenominacion = denominaciones.Where(s => s <= restante).ToList();

                foreach (var item in filtroDenominacion)
                {
                    var respuesta = ResolverRestante(restante, item);
                    respuesta = respuesta.Substring(0, respuesta.Length - 1);

                    Console.WriteLine("[" + resultado + respuesta + "]");
                }
            }
        }

        public string ResolverRestante(decimal numeroRestante, decimal denominador)
        {
            var suma = 0.0m;
            var resultado = string.Empty;

            while (suma < numeroRestante)
            {
                suma += denominador;
                resultado += denominador.ToString() + ",";
            }

            return resultado;
        }
    }
}
