using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorFIA
{
    class Compuesto
    {
        //VARIABLES MIEMBRO
        protected string nombre;

        //PROPIEDADES
        public string Nombre
        {
            get { return nombre; }

            set 
            {
                nombre = value.ToUpper();
            }
        }
        public string Color { get; set; }
        public string Abreviatura { get; set; }
        public int Duracion { get; set; }
        public double Ganancia { get; set; }

        //CONSTRUCTORES
        public Compuesto() { }
        public Compuesto(string nombre) 
        {
            Nombre = nombre;
            if(Nombre == "SUPER BLANDO")
            {
                Color = "ROJO";
                Abreviatura = "SB";
                Duracion = 10;
                Ganancia = 0.10;
            }
            if (Nombre == "BLANDOS")
            {
                Color = "AMARILLO";
                Abreviatura = "B";
                Duracion = 15;
                Ganancia = 0.07;
            }
            if (Nombre == "MEDIOS")
            {
                Color = "BLANCO";
                Abreviatura = "M";
                Duracion = 25;
                Ganancia = 0.02;
            }
            if (Nombre == "DUROS")
            {
                Color = "MARRÓN";
                Abreviatura = "H";
                Duracion = 40;
                Ganancia = 0;
            }
        }

        //METODOS
        /// <summary>
        /// Despliega los detalles del compuesto.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        public bool MostrarDetalles(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(x, y + 1);
            Console.Write("================================ DETALLES DEL COMPUESTO ==================================");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y + 2);
            Console.Write("NOMBRE:\t\t{0}", Nombre.ToUpper());

            Posicion(x, y + 3);
            Console.Write("COLOR:");

            if  (Color.ToUpper() == "AMARILLO")
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (Color.ToUpper() == "BLANCO")
                Console.ForegroundColor = ConsoleColor.White;
            if (Color.ToUpper() == "ROJO")
                Console.ForegroundColor = ConsoleColor.Red;
            if (Color.ToUpper() == "MARRÓN")
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write("\t\t{0}", Color.ToUpper());      

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y + 4);
            Console.Write("ABREVIATURA:\t\t{0}", Abreviatura.ToUpper());

            Posicion(x, y + 5);
            Console.Write("DURACION:\t\t{0} VUELTAS", Duracion);

            Posicion(x, y + 6);
            Console.Write("GANANCIA:\t\t{0}%", Ganancia*100);

            

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
        /// <summary>
        /// Reemplaza el compuesto del vehículo por uno nuevo.
        /// </summary>
        /// <param name="nombre">Nombre del compuesto a utilizar.</param>
        public void CambiarCompuesto(string nombre)
        {
            Nombre = nombre;
            if (Nombre == "SUPER BLANDO")
            {
                Color = "ROJO";
                Abreviatura = "SB";
                Duracion = 10;
                Ganancia = 0.10;
            }
            if (Nombre == "BLANDOS")
            {
                Color = "AMARILLO";
                Abreviatura = "B";
                Duracion = 15;
                Ganancia = 0.07;
            }
            if (Nombre == "MEDIOS")
            {
                Color = "BLANCO";
                Abreviatura = "M";
                Duracion = 25;
                Ganancia = 0.02;
            }
            if (Nombre == "DUROS")
            {
                Color = "MARRÓN";
                Abreviatura = "H";
                Duracion = 40;
                Ganancia = 0;
            }
        }
    }
}
