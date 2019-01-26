/*  Clase:      Program
 *  Detalle:    Es la clase principal o controladora de la simulacion.
 *  Autor:      Abdias Alvarado Pineda
 *  Cuenta:     0318-1997-00125
 *  Email:      abdias.alvarado@unah.hn
 *  Celular:    (504) 8882-2467
 *  Fecha:      13/Julio/2017
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Media;
using System.Threading;

namespace SimuladorFIA
{
    class Program
    {
        static void Main(string[] args)
        {

            string respuesta = "";

            System.Console.SetWindowPosition(0,0);
            Simulador sim = new Simulador();

            sim.Iniciar();

            do
            {
                Console.WriteLine("\n\n\t\t\t\t\t\t\t¿Desea volver a simular? (S/N)");
                Console.Write("\t\t\t\t\t\t\tR=> ");

                respuesta = Console.ReadLine();

                switch (respuesta.ToUpper())
                {
                    case "S":
                        Console.Clear();
                        Simulador sim2 = new Simulador();
                        sim2.Iniciar();
                        break;
                    case "N":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\n\t\t\t\t\t\t\t¡GRACIAS POR SIMULAR CON NOSOTROS!");
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine("\n\n\n\t\t\t\t\t\t\t¡ERROR! NO VALIDO.");
                        Thread.Sleep(1000);
                        break;
                }
            }
            while (respuesta != "N");
        }
    }
}
