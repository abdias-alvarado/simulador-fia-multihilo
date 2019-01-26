using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimuladorFIA
{
    class Equipo
    {
        //VARIABLES MIEMBRO
        protected string nombre;
        protected string compuesto;
        protected DateTime fechaCreacion;
        protected int cantidadMiembros;


        //PROPIEDADES
        public string Nombre
        {
            get { return nombre; }
            set
            {
                
                    nombre = value.ToUpper();
               
            }
        }
        public string CompuestoUtilizado 
        {   get 
            { 
                return compuesto; 
            }
            set 
            {
                try
                {
                    compuesto = value.ToUpper(); ;
                }
                catch (Exception Error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n*** ¡ERROR! ***");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("FUENTE: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("{0}", Error.Source.ToUpper());
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("METODO EN CONFLICTO: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("{0}", Error.TargetSite.ToString().ToUpper());
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("MENSAJE: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("{0}", Error.Message.ToUpper());
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("PARA SOPORTE VISITE: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("{0}", Error.HelpLink);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n*** ¡DETALLES DEL ERROR! ***");
                    if (Error.Data != null)
                    {
                        foreach (DictionaryEntry Diccionario in Error.Data)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("=> {0}: ", Diccionario.Key);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("{0}", Diccionario.Value);
                        }


                    }
                }
                
            }
        }
        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        public int CantidadMiembros
        {
            set;
            get;
        }

        //CONSTRUCTORES
        public Equipo() { }

        //METODOS
        /// <summary>
        /// Solicita al usuario los datos del nuevo equipo.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        public bool NuevoEquipo(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(x, y+1);
            Console.Write("================================ REGISTRAR NUEVO EQUIPO ==================================");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y + 2);
            Console.Write("NOMBRE DEL EQUIPO:   ", Nombre);
            Nombre = Console.ReadLine();

            Posicion(x, y + 3);
            Console.Write("FECHA DE CREACION:   {0}", DateTime.Now);
            FechaCreacion = DateTime.Now.Date;

            Posicion(x, y + 4);
            Console.Write("COMPUESTO UTILIZADO: ", CompuestoUtilizado);
            CompuestoUtilizado = Console.ReadLine();

            CantidadMiembros = 0;
            return true;
        }
        /// <summary>
        /// Despliega los detalles del Equipo.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        public bool MostrarDetalles(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(x, y+1);
            Console.Write("================================== DETALLES DEL EQUIPO ===================================");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y + 2);
            Console.Write("NOMBRE DEL EQUIPO:   \t{0}", Nombre);

            Posicion(x, y + 3);
            Console.Write("FECHA DE CREACION:   \t{0}", FechaCreacion);

            Posicion(x, y + 4);
            Console.Write("COMPUESTO UTILIZADO:");

            if (CompuestoUtilizado.ToUpper() == "SUPER BLANDO")
                Console.ForegroundColor = ConsoleColor.Red;
            if (CompuestoUtilizado.ToUpper() == "BLANDOS")
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (CompuestoUtilizado.ToUpper() == "MEDIOS")
                Console.ForegroundColor = ConsoleColor.White;
            if (CompuestoUtilizado.ToUpper() == "DUROS")
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write(" \t{0}", CompuestoUtilizado);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y + 5);
            Console.Write("MIEMBROS:            \t{0} MIEMBROS", CantidadMiembros);

            return true;
        }
        /// <summary>
        /// Coloca el cursor en una posición específica personalizada.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        private bool Posicion(int x, int y)
        {
            Console.SetCursorPosition(x + 30, y);
            return true;
        }

    }
}
