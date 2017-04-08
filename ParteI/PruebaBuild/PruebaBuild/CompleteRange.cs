using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBuild
{
    public class CompleteRange
    {
        public void build(string coleccion)
        {
            var nuevaColeccion = new List<int>();
            var respuesta = string.Empty;
            coleccion = coleccion.Replace("[", "");
            coleccion = coleccion.Replace("]", "");

            if (coleccion.Length > 0)
            {
                var lista = coleccion.Split(',');
                if (lista.Length > 0)
                {
                    Array.Sort(lista);

                    var ultimo = Convert.ToInt32(lista[lista.Count() - 1]);

                    var listaOrdenada = lista.ToList();

                    for (int i = 1; i < ultimo + 1; i++)
                    {
                        var existe = listaOrdenada.Contains(i.ToString());
                        if (!existe)
                        {
                            listaOrdenada.Add(i.ToString());
                        }
                    }

                    nuevaColeccion = listaOrdenada.Select(s => Convert.ToInt32(s)).ToList();
                    nuevaColeccion = nuevaColeccion.OrderBy(x => x).ToList();

                    respuesta = "[" + string.Join(",", nuevaColeccion) + "]";

                    Console.WriteLine(respuesta);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Error");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }
    }
}
