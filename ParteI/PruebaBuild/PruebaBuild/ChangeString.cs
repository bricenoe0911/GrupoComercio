using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBuild
{
    public class ChangeString
    {
        public void build(string text)
        {
            var abecedario = "abcdefghijklmnñopqrstuvwxyz";
            var abecedarioMayus = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

            var tamano = text.Length;
            var nuevoTexto = string.Empty;
            for (int i = 0; i < tamano; i++)
            {
                var letra = text.Substring(i, 1);
                var posicion = abecedario.IndexOf(letra);
                if (posicion > -1)
                {
                    if (posicion < abecedario.Length - 1)
                    {
                        var nuevaLetra = abecedario.Substring(posicion + 1, 1);
                        nuevoTexto = string.Concat(nuevoTexto, nuevaLetra);
                    }
                    else
                    {
                        var nuevaLetra = abecedario.Substring(0, 1);
                        nuevoTexto = string.Concat(nuevoTexto, nuevaLetra);
                    }
                }
                else
                {
                    var posicionMayus = abecedarioMayus.IndexOf(letra);
                    if (posicionMayus > -1)
                    {
                        if (posicionMayus < abecedarioMayus.Length - 1)
                        {
                            var nuevaLetraMayus = abecedarioMayus.Substring(posicionMayus + 1, 1);
                            nuevoTexto = string.Concat(nuevoTexto, nuevaLetraMayus);
                        }
                        else
                        {
                            var nuevaLetraMayus = abecedarioMayus.Substring(0, 1);
                            nuevoTexto = string.Concat(nuevoTexto, nuevaLetraMayus);
                        }
                    }
                    else
                    {
                        nuevoTexto = string.Concat(nuevoTexto, letra);
                    }
                }
            }

            Console.Write(nuevoTexto);
            Console.ReadKey();
        }
    }
}
