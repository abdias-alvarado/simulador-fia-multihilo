/*  Clase:      Vehiculo
 *  Detalle:    Modela un vehículo con todas sus características.
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
using System.Threading;
using System.Diagnostics;

namespace SimuladorFIA
{
    class Vehiculo
    {
        //VARIABLES MIEMBRO
        protected string compuesto;
        protected string marca;
        protected string apodo;
        protected string modelo;
        protected string equipo;
        protected double combustibleMaximo;
        protected double velocidadMaxima;
        protected double velocidadActual;
        protected double combustibleInicial;
        
        //VARIABLES AUXILIARES
        double VelocidadPermitida = 0;
        double CombustibleActual = 0;
        double PorcentajeCombustible = 0;
        double ConsumoCombustiblePorVuelta = 0;
        double DistanciaPorVuelta = 0;
        double DistanciaRecorrida = 0;
        double VueltasRestantes = 0;
        Compuesto miCompuesto = new Compuesto();
        public bool Llegada = false;
        public TimeSpan TiempoLlegada;
        public int PosicionSalida;
        public int PosicionY = 11;

        //PROPIEDADES
        public string Marca
        {
            get { return marca; }
            set
            {
                if (value.Length > 2)
                {
                    marca = value.ToUpper();
                }
                else
                {
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                                ");
                    Posicion(30, 40);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("¡ERROR! LA MARCA NO PUEDE SER MENOR QUE 2 CARACTERES. SE HA ASIGNADO LA MARCA HONDA.");
                    Thread.Sleep(2000);
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                           ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    marca = "HONDA";
                }
            }

        }
        public string Apodo
        {
            get { return apodo; }
            set { apodo = value.ToUpper(); }
        }
        public string Modelo
        {
            get { return modelo; }
            set
            {
                
                    modelo = value.ToUpper();
                
            }

        }
        public string Equipo
        {
            get { return equipo; }
            set
            {
                
                    equipo = value.ToUpper();
               
            }

        }
        public string CombustibleMaximo
        {
            get { return combustibleMaximo.ToString(); }
            set
            {
                try
                {
                    combustibleMaximo = double.Parse(value);
                    if (combustibleMaximo <= 0)
                    {
                        Posicion(30, 40);
                        Console.WriteLine("                                                                                                ");
                        Posicion(30, 40);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("¡ERROR! EL VALOR NO PUEDE SER CERO. SE HA SETEADO 20 GALONES.");
                        Thread.Sleep(2000);
                        Posicion(30, 40);
                        Console.WriteLine("                                                                                           ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        
                        combustibleMaximo = 20;
                    }
                    
                }
                catch(Exception)
                {
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                                ");
                    Posicion(30, 40);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("¡ERROR! EL VALOR INGRESADO NO ES UN NÚMERO. SE HA SETEADO 20 GALONES.");
                    Thread.Sleep(2000);
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                           ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    
                    combustibleMaximo = 20;
                }
            }
        }
        public string VelocidadMaxima 
        {
            get {return velocidadMaxima.ToString();}
            set
            {
                try
                {
                    velocidadMaxima = double.Parse(value);
                    if ((velocidadMaxima <= 0) || (velocidadMaxima>300))
                    {
                        Posicion(30, 40);
                        Console.WriteLine("                                                                                                ");
                        Posicion(30, 40);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("¡ERROR! EL VALOR NO PUEDE SER CERO NI MAYOR DE 300. SE HA SETEADO 190 KM/H.");
                        Thread.Sleep(2000);
                        Posicion(30, 40);
                        Console.WriteLine("                                                                                           ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        
                       
                        velocidadMaxima = 190;
                    }

                }
                catch (Exception)
                {
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                                ");
                    Posicion(30, 40);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("¡ERROR! EL VALOR INGRESADO NO ES UN NÚMERO. SE HA SETEADO 190 KM/H.");
                    Thread.Sleep(2000);
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                           ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    
                    velocidadMaxima = 190;
                }
            }
            
        }
        public double VelocidadActual { get; set; }
        public string CombustibleInicial 
        {
            get { return combustibleInicial.ToString(); }
            set
            {
                try
                {
                    combustibleInicial = double.Parse(value);
                    if (combustibleInicial > 0)
                    {
                        if(combustibleInicial > combustibleMaximo)
                        {
                            Posicion(30, 40);
                            Console.WriteLine("                                                                                                ");
                            Posicion(30, 40);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("¡ERROR! NO PUEDE SUPERAR EL MÁXIMO DE COMBUSTIBLE. SE HA ASIGNADO EL 50% DEL MÁXIMO.");
                            Thread.Sleep(2000);
                            Posicion(30, 40);
                            Console.WriteLine("                                                                                           ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            
                            combustibleInicial = combustibleMaximo*0.50;
                        }
                    }
                    else
                    {
                        Posicion(30, 40);
                        Console.WriteLine("                                                                                                ");
                        Posicion(30, 40);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("¡ERROR! EL VALOR NO PUEDE SER CERO. SE HA SETEADO 80% DE LA CAPACIDAD.");
                        Thread.Sleep(2000);
                        Posicion(30, 40);
                        Console.WriteLine("                                                                                           ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        
                        combustibleInicial = combustibleMaximo * 0.80;
                    }


                    if (combustibleInicial < combustibleMaximo*0.40)
                    {

                        Posicion(30, 40);
                        Console.WriteLine("                                                                                                ");
                        Posicion(30, 40);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("¡ERROR! NO PUEDE SER INFERIOR AL 40% DE LA CAPACIDAD MAXIMA. SE HA ASIGNADO EL 80% DEL MÁXIMO.");
                        Thread.Sleep(2000);
                        Posicion(30, 40);
                        Console.WriteLine("                                                                                           ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                            
                            combustibleInicial = combustibleMaximo * 0.80; 
                    }
                   

                }
                catch (Exception)
                {
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                                ");
                    Posicion(30, 40);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("¡ERROR! EL VALOR INGRESADO NO ES UN NÚMERO. SE A SETEADO 80% DEL MAXIMO.");
                    Thread.Sleep(2000);
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                           ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    combustibleInicial = combustibleMaximo * 0.80; 
                }
            }
        }
        public string Compuesto 
        {
             get 
            { 
                return compuesto; 
            }
            set
            {
                try
                {
                    compuesto = value;
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

        //CONSTRUCTORES
        public Vehiculo() { }

        //METODOS
        /// <summary>
        /// Solicita al usuario los datos del vehículo.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        public bool InsertarDatos(int x, int y, List<Equipo> Equipos)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(x, y);            
            Console.Write("=========================== INGRESE LOS DATOS DE LOS VEHICULOS ===========================");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y + 1);
            Console.Write("MARCA:                               ");
            Marca = Console.ReadLine();

            Posicion(x, y + 2);
            Console.Write("MODELO:                              ");
            Modelo = Console.ReadLine();

            Posicion(x, y + 3);
            Console.Write("EQUIPO:                              ");
            Equipo = Console.ReadLine();
           
            //¿EXISTE EL EQUIPO QUE ELIGIÓ?
            if (ExisteEquipo(this, Equipo, Equipos))
            {
                Posicion(x, y + 4);
                Console.Write("VELOCIDAD MÁXIMA (KM/H):             ");
                VelocidadMaxima = Console.ReadLine();

                Posicion(x, y + 5);
                Console.Write("COMBUSTIBLE MAXIMO (GALONES):        ");
                CombustibleMaximo = Console.ReadLine();

                Posicion(x, y + 6);
                Console.Write("COMBUSTIBLE INICIAL (GALONES):       ");
                CombustibleInicial = Console.ReadLine();

                Posicion(x, y + 7);
                Console.Write("APODO:                               ");
                Apodo = Console.ReadLine();


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Posicion(30, 40);
                Console.Write("¡EL EQUIPO NO EXISTE! INGRESE UN EQUIPO EXISTENTE.");
                Thread.Sleep(2000);
                InsertarDatos(x, y, Equipos);

            }

            return true;
        }
        /// <summary>
        /// Despliega los detalles del Vehiculo.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <param name="Equipos">Lista de equipos registrados.</param>
        /// <param name="Compuestos">Lista de compuestos registrados.</param>
        /// <returns></returns>
        public bool MostrarDetalles(int x, int y, List<Equipo> Equipos, List<Compuesto> Compuestos)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(x, y+1);
            Console.Write("================================= DETALLES DEL VEHÍCULO ==================================");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y + 2);
            Console.Write("MARCA:       \t\t{0}", Marca);

            Posicion(x, y + 3);
            Console.Write("MODELO:      \t\t{0}", Modelo);

            Posicion(x, y + 4);
            Console.Write("EQUIPO:      \t\t{0}", Equipo);

            Posicion(x, y + 5);
            Console.Write("VELOCIDAD MÁXIMA:\t\t{0} KM/H", VelocidadMaxima);

            Posicion(x, y + 6);
            Console.Write("COMBUSTIBLE MÁXIMO:\t\t{0} GALONES", CombustibleMaximo);

            Posicion(x, y + 7);
            Console.Write("COMBUSTIBLE INICIAL:\t\t{0} GALONES", CombustibleInicial);

            Posicion(x, y + 8);
            Console.Write("COMPUESTO UTILIZADO:");

            if (Compuesto.ToUpper() == "SUPER BLANDO")
                Console.ForegroundColor = ConsoleColor.Red;
            if (Compuesto.ToUpper() == "BLANDOS")
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (Compuesto.ToUpper() == "MEDIOS")
                Console.ForegroundColor = ConsoleColor.White;
            if (Compuesto.ToUpper() == "DUROS")
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write(" \t{0}", Compuesto);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Posicion(x, y + 9);
            Console.Write("APODO:              \t\t{0}", Apodo);

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
        /// Verifica que el equipo al que el vehículo se está registrando
        /// exista en los equipos registrados.
        /// </summary>
        /// <param name="este">Apuntador a sí mismo "this".</param>
        /// <param name="equipo">Nombre del equipo a unirse.</param>
        /// <param name="Equipos">Lista de equipos registrados.</param>
        /// <returns></returns>
        private bool ExisteEquipo(Vehiculo este, string equipo, List<Equipo> Equipos)
        {
            bool respuesta = false;

            foreach(Equipo E in Equipos)
            {
                if (equipo.Trim().ToUpper() == E.Nombre.Trim().ToUpper())
                {
                    respuesta = true;
                    E.CantidadMiembros++;
                    este.Compuesto = E.CompuestoUtilizado;
                    return respuesta;
                }
                else
                    continue;       
            }

            return respuesta;
        }
        /// <summary>
        /// Inicializa la velocidad del vehículo en 0 KM/H.
        /// </summary>
        /// <returns></returns>
        public bool EncenderVehiculo()
        {
            VelocidadActual = 0;

            return true;
        }
        /// <summary>
        /// Llama a los métodos que dan marcha al vehículo.
        /// </summary>
        /// <param name="miPista">Pista en la que va a correr.</param>
        /// <param name="x">Coordenada en eje X a colocar el vehículo.</param>
        /// <param name="y">Coordenada en eje Y a colocar el vehículo.</param>
        public void IniciarCarrera(Pista miPista, int x, int y)
        {
            EncenderVehiculo();
            Arrancar(miPista, x, y);
        }
        /// <summary>
        /// Método fuente del simulador que controla el vehículo.
        /// </summary>
        /// <param name="miPista">Pista en la que corre.</param>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        public bool Arrancar(Pista miPista, int x, int y)
        {
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();

            VelocidadPermitida = velocidadMaxima;
            CombustibleActual = combustibleInicial;
            PorcentajeCombustible = combustibleInicial / combustibleMaximo;
            ConsumoCombustiblePorVuelta = 0;
            DistanciaPorVuelta = (double.Parse(miPista.Longitud) * 1000) / (int.Parse(miPista.Vueltas));
            DistanciaRecorrida = 0;
            VueltasRestantes = int.Parse(miPista.Vueltas);
            miCompuesto.CambiarCompuesto(Compuesto);

            //¿CUANTO COMBUSTIBLE PARA INICIAR LA CARRERA?
            if ((PorcentajeCombustible >= 0.90))
                VelocidadPermitida = velocidadMaxima * 0.75;

            if ((PorcentajeCombustible >= 0.65) && (PorcentajeCombustible <= 0.89))
                VelocidadPermitida = velocidadMaxima * 0.87;

            if ((PorcentajeCombustible >= 0.40) && (PorcentajeCombustible <= 0.64))
                VelocidadPermitida = velocidadMaxima;

            //APLICAR EL COMPUESTO SI NO SUPERA LA VELOCIDAD MAXIMA
            if ((VelocidadPermitida + VelocidadPermitida * miCompuesto.Ganancia) <= velocidadMaxima)
            {
                VelocidadPermitida += VelocidadPermitida * miCompuesto.Ganancia;
            }
            else
            {
                VelocidadPermitida = velocidadMaxima;
            }
           

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¡{0} HA ARRANCADO!", Apodo);
            y += 2;

            VelocidadActual = VelocidadPermitida;

            for (int i = 0; i < int.Parse(miPista.Vueltas); i++)
            {
                PorcentajeCombustible = CombustibleActual / combustibleMaximo;

                //¿CUANTO COMBUSTIBLE PARA INICIAR LA CARRERA?
                if ((PorcentajeCombustible >= 0.90))
                    VelocidadPermitida = velocidadMaxima * 0.75;

                if ((PorcentajeCombustible >= 0.65) && (PorcentajeCombustible <= 0.89))
                    VelocidadPermitida = velocidadMaxima * 0.87;

                if ((PorcentajeCombustible >= 0.40) && (PorcentajeCombustible <= 0.64))
                    VelocidadPermitida = velocidadMaxima;

                //APLICAR EL COMPUESTO SI NO SUPERA LA VELOCIDAD MAXIMA
                if ((VelocidadPermitida + VelocidadPermitida * miCompuesto.Ganancia) <= velocidadMaxima)
                {
                    VelocidadPermitida += VelocidadPermitida * miCompuesto.Ganancia;
                }
                else
                {
                    VelocidadPermitida = velocidadMaxima;
                }

                VelocidadActual = VelocidadPermitida;
                int tiempo = 4000 - int.Parse(Math.Truncate(VelocidadActual).ToString()) * 10;
                Thread.Sleep(tiempo);
                VueltasRestantes--;
                DistanciaRecorrida = (i + 1) * DistanciaPorVuelta;
                Console.SetCursorPosition(x, y); y++;
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(x, y); y++;
                Console.WriteLine("{0}", Apodo);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y); y++;
                Console.WriteLine("VUELTA                  {0}", i + 1);
                Console.SetCursorPosition(x, y); y++;
                Console.WriteLine("VELOCIDAD ACTUAL        {0} KM/H", VelocidadActual);
                Console.SetCursorPosition(x, y); y++;
                Console.WriteLine("COMBUSTIBLE RESTANTE    {0:0.00} G/{1:0.00}%", CombustibleActual, (CombustibleActual / combustibleMaximo) * 100);
                Console.SetCursorPosition(x, y); y++;
                Console.WriteLine("DISTANCIA RECORRIDA     {0:0.00} METROS", DistanciaRecorrida);
                Console.SetCursorPosition(x, y); y++;
                Console.WriteLine("COMPUESTO RESTANTE      {0} VUELTAS", miCompuesto.Duracion);
                Console.SetCursorPosition(x, y); y++;
                Console.WriteLine("VUELTAS RESTANTES       {0} VUELTAS", VueltasRestantes); 

                //¿AJUSTA EL COMPUESTO O EL COMBUSTIBLE?
                if(miCompuesto.Duracion>3)
                {
                    //SI ME AJUSTA PARA TERMIANAR CABAL LA CARRERA
                    miCompuesto.Duracion--;
                }
                else
                {
                    if (miCompuesto.Duracion >= VueltasRestantes)
                    {
                        //REBAJAR COMPUESTO
                        miCompuesto.Duracion--;
                    }
                    else
                        y = ALosPits(x, y);
                }
   
                //REBAJAR COMBUSTIBLE
                if((VelocidadActual/velocidadMaxima)>=0.91 && (VelocidadActual/velocidadMaxima) <=1 )
                {
                    ConsumoCombustiblePorVuelta = (CombustibleActual * 0.07);
                }
                if ((VelocidadActual / velocidadMaxima) >= 0.80 && (VelocidadActual / velocidadMaxima) <= 0.90)
                {
                    ConsumoCombustiblePorVuelta = (CombustibleActual * 0.05);
                }
                if ((VelocidadActual / velocidadMaxima) >= 0.75 && (VelocidadActual / velocidadMaxima) <= 0.79)
                {
                    ConsumoCombustiblePorVuelta = (CombustibleActual * 0.03);
                }

                CombustibleActual -= ConsumoCombustiblePorVuelta; 
                
                //AJUSTA EL COMBUSTIBLE?
                if (CombustibleActual < (combustibleMaximo * 0.09))
                {
                        if (CombustibleActual >= ConsumoCombustiblePorVuelta * VueltasRestantes)
                        {
                            continue;
                        }
                        else
                            y = ALosPits(x, y);
                    
                }
                else
                {
                    continue;
                }
   
            }
            Console.SetCursorPosition(x, y + 1); y += 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡{0} HA LLEGADO A LA META!", Apodo);
            
            cronometro.Stop();
            TiempoLlegada = cronometro.Elapsed.Duration();
            Console.SetCursorPosition(x, y); y++;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("TIEMPO LLEGADA => {0}", TiempoLlegada.Duration());
            Console.ForegroundColor = ConsoleColor.White;
            Llegada = true;
                return true;
        }
        /// <summary>
        /// Recarga el combustible y el compuesto del vehículo.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        public int ALosPits(int x, int y)
        {
            Random aleatorio = new Random();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(x, y); y++;
            Console.WriteLine("¡{0} HA ENTRADO A LOS PITS!", Apodo);
            Console.ForegroundColor = ConsoleColor.White;
            double cargarACombustible = 0;

            int opcion = aleatorio.Next(0, 4);

            switch(opcion)
            {
                case 1:
                    Thread.Sleep(1500);
                     cargarACombustible = combustibleMaximo * aleatorio.NextDouble();
                     miCompuesto.CambiarCompuesto("SUPER BLANDO");
                         Console.ForegroundColor = ConsoleColor.Yellow;
                         Console.SetCursorPosition(x, y); y++;
                         Console.WriteLine("SE ELEGIDO COMPONENTE {0}.", miCompuesto.Nombre);
                         Console.ForegroundColor = ConsoleColor.White;

                         if (cargarACombustible + CombustibleActual <= combustibleMaximo)
                         {
                             CombustibleActual += cargarACombustible;
                             Thread.Sleep(1500);
                             Console.ForegroundColor = ConsoleColor.DarkGreen;
                             Console.SetCursorPosition(x, y); y++;
                             Console.WriteLine("SE HAN CARGADO {0:0.0} GALONES.", cargarACombustible);
                             Console.ForegroundColor = ConsoleColor.White;
                         }
                         else
                         {
                             CombustibleActual = combustibleMaximo;
                             Thread.Sleep(1500);
                             Console.ForegroundColor = ConsoleColor.DarkGreen;
                             Console.SetCursorPosition(x, y); y++;
                             Console.WriteLine("SE HA FULEADO EL TANQUE.");
                             Console.ForegroundColor = ConsoleColor.White;
                         }
;                    break;
                case 2:
                    cargarACombustible = combustibleMaximo * aleatorio.NextDouble();
                     miCompuesto.CambiarCompuesto("BLANDOS");
                     Thread.Sleep(1500);
                         Console.ForegroundColor = ConsoleColor.Yellow;
                         Console.SetCursorPosition(x, y); y++;
                         Console.WriteLine("SE ELEGIDO COMPONENTE {0}.", miCompuesto.Nombre);
                         Console.ForegroundColor = ConsoleColor.White;

                         if (cargarACombustible + CombustibleActual <= combustibleMaximo)
                         {
                             CombustibleActual += cargarACombustible;
                             Thread.Sleep(1500);
                             Console.ForegroundColor = ConsoleColor.DarkGreen;
                             Console.SetCursorPosition(x, y); y++;
                             Console.WriteLine("SE HAN CARGADO {0:0.0} GALONES.", cargarACombustible);
                             Console.ForegroundColor = ConsoleColor.White;
                         }
                         else
                         {
                             CombustibleActual = combustibleMaximo;
                             Thread.Sleep(1500);
                             Console.ForegroundColor = ConsoleColor.DarkGreen;
                             Console.SetCursorPosition(x, y); y++;
                             Console.WriteLine("SE HA FULEADO EL TANQUE.");
                             Console.ForegroundColor = ConsoleColor.White;
                         }
                    break;
                case 3:
                    cargarACombustible = combustibleMaximo * aleatorio.NextDouble();
                     miCompuesto.CambiarCompuesto("MEDIOS");
                         Thread.Sleep(1500);
                         Console.ForegroundColor = ConsoleColor.Yellow;
                         Console.SetCursorPosition(x, y); y++;
                         Console.WriteLine("SE ELEGIDO COMPONENTE {0}.", miCompuesto.Nombre);
                         Console.ForegroundColor = ConsoleColor.White;

                         if (cargarACombustible + CombustibleActual <= combustibleMaximo)
                         {
                             CombustibleActual += cargarACombustible;
                             Thread.Sleep(1500);
                             Console.ForegroundColor = ConsoleColor.DarkGreen;
                             Console.SetCursorPosition(x, y); y++;
                             Console.WriteLine("SE HAN CARGADO {0:0.0} GALONES.", cargarACombustible);
                             Console.ForegroundColor = ConsoleColor.White;
                         }
                         else
                         {
                             CombustibleActual = combustibleMaximo;
                             Thread.Sleep(1500);
                             Console.ForegroundColor = ConsoleColor.DarkGreen;
                             Console.SetCursorPosition(x, y); y++;
                             Console.WriteLine("SE HA FULEADO EL TANQUE.", Marca, Modelo);
                             Console.ForegroundColor = ConsoleColor.White;
                         }
                    break;
                case 4:
                    cargarACombustible = combustibleMaximo * aleatorio.NextDouble();
                     miCompuesto.CambiarCompuesto("DUROS");
                     Thread.Sleep(1500);
                         Console.ForegroundColor = ConsoleColor.Yellow;
                         Console.SetCursorPosition(x, y); y++;
                         Console.WriteLine("SE ELEGIDO COMPONENTE {0}.", miCompuesto.Nombre);
                         Console.ForegroundColor = ConsoleColor.White;

                         if (cargarACombustible + CombustibleActual <= combustibleMaximo)
                         {
                             CombustibleActual += cargarACombustible;
                             Thread.Sleep(1500);
                             Console.ForegroundColor = ConsoleColor.DarkGreen;
                             Console.SetCursorPosition(x, y); y++;
                             Console.WriteLine("SE HAN CARGADO {0:0.0} GALONES.", cargarACombustible);
                             Console.ForegroundColor = ConsoleColor.White;
                         }
                         else
                         {
                             CombustibleActual = combustibleMaximo;
                             Thread.Sleep(1500);
                             Console.ForegroundColor = ConsoleColor.DarkGreen;
                             Console.SetCursorPosition(x, y); y++;
                             Console.WriteLine("SE HA FULEADO EL TANQUE.");
                             Console.ForegroundColor = ConsoleColor.White;
                         }
                    break;
                default:
                    {
                        cargarACombustible = combustibleMaximo * aleatorio.NextDouble();
                        miCompuesto.CambiarCompuesto("MEDIOS");
                        Thread.Sleep(1500);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(x, y); y++;
                        Console.WriteLine("SE ELEGIDO COMPONENTE {0}.", miCompuesto.Nombre);
                        Console.ForegroundColor = ConsoleColor.White;

                        if (cargarACombustible + CombustibleActual <= combustibleMaximo)
                        {
                            CombustibleActual += cargarACombustible;
                            Thread.Sleep(1500);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.SetCursorPosition(x, y); y++;
                            Console.WriteLine("SE HAN CARGADO {0:0.0} GALONES.", cargarACombustible);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            CombustibleActual = combustibleMaximo;
                            Thread.Sleep(1500);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.SetCursorPosition(x, y); y++;
                            Console.WriteLine("SE HA FULEADO EL TANQUE.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    break;

            }


            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(x, y); y++;
            Console.WriteLine("{0} HA SALIDO DE LOS PITS.", Apodo);
            Console.ForegroundColor = ConsoleColor.White;

            return y;
        }


    }
}
