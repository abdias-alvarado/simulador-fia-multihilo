using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimuladorFIA
{
    class Pista
    {
        //VARIABLES MIEMBRO
        protected string nombre;
        protected string localidad;
        protected string tipo;
        protected double longitud;
        protected int vueltas;

        //PROPIEDADES
        public string Nombre 
        {
            get { return nombre; }
            set
            {
                if (value.Length > 5)
                    nombre = value.ToUpper();
                else
                {
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                     ");
                    Posicion(30, 40);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("¡ERROR! EL NOMBRE DEBE CONTENER MAS DE 5 CARACTERES.");
                    Thread.Sleep(2000);
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                           ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    
                    
                    InsertarDatos(5, 18);
                }
            }
        }
        public string Localidad
        {
            get { return localidad; }
            set
            {
                localidad = value.ToUpper();
            }
        }
        public string Tipo
        {
            get { return tipo; }
            set
            {
                tipo = value.ToUpper();
            }
        }
        public string Longitud
        {
            get { return longitud.ToString(); }
            set
            {
                try
                {
                    longitud = double.Parse(value);
                }
                catch (Exception)
                {
                    Posicion(30, 40);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("¡ERROR! EL DATO INGRESADO NO ES UNA CANTIDAD. SE HA SETEADO 10KM AL VALOR.");
                    Thread.Sleep(2000);
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                           ");
                    longitud = 10;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }

        
        }
        public string Vueltas 
        {
            get { return vueltas.ToString(); }
            set
            {
                try
                {
                    vueltas = int.Parse(value);
                }
                catch (Exception e)
                {
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                                ");
                    Posicion(30, 40);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("¡ERROR! EL DATO INGRESADO NO ES UNA CANTIDAD. SE HA SETEADO 60 VUELTAS.");
                    Thread.Sleep(2000);
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                           ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    vueltas = 60;

                }
            }
        }

        //CONSTRUCTORES
        public Pista() { }

        //METODOS
        /// <summary>
        /// Solicita al usuario los datos de la pista.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        public bool InsertarDatos(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(x, y+1);
            Console.Write("============================== INGRESE LOS DATOS DE LA PISTA =============================");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y+2);
            Console.Write("NOMBRE DE LA PISTA:                  ");
            Nombre = Console.ReadLine();

            Posicion(x, y+3);
            Console.Write("LONGITUD DE LA PISTA {0} (KM):       ", Nombre);
            Longitud = Console.ReadLine();

            Posicion(x, y+4);
            Console.Write("LOCALIDAD DE LA PISTA:               ");
            Localidad = Console.ReadLine();

            Posicion(x, y+5);
            Console.Write("TIPO DE LA PISTA:                    ");
            Tipo = Console.ReadLine();

            Posicion(x, y+6);
            Console.Write("NUMERO DE VUELTAS:                   ");
            Vueltas = Console.ReadLine();

            Console.WriteLine("");
            
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
            Posicion(x, y);
            Console.Write("================================== DETALLES DE LA PISTA ==================================");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y+2);
            Console.Write("NOMBRE:\t{0}", Nombre);
            
            Posicion(x, y+3);
            Console.Write("LONGITUD:\t{0} KM", Longitud);
            
            Posicion(x, y+4);
            Console.Write("LOCALIDAD:\t{0}", Localidad);
            
            Posicion(x, y+5);
            Console.Write("TIPO:\t{0}", Tipo);
            
            Posicion(x, y+6);
            Console.Write("VUELTAS:\t{0} VUELTAS", Vueltas);
            
            

            return true;
        }
        /// <summary>
        /// Se utiliza para asignar una posición específica al cursor en la Consola.
        /// </y>
        /// <param name="x"> Valor de la coordenada en x.</param>
        /// <param name="y"> Valor de la coordenada en y.</param>
        /// <returns>Retorna true si se realiza con éxito.</returns>
        private bool Posicion(int x, int y)
        {
            Console.SetCursorPosition(x + 30, y);
            return true;
        }

        
        

    }
}
