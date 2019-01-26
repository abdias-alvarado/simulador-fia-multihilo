using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;

namespace SimuladorFIA
{
    sealed class Simulador
    {
        protected int cantidadVehiculos;
        protected string prueba;
        protected Pista miPista = new Pista();
        private string CantidadVehiculos 
        {
            get { return cantidadVehiculos.ToString(); }
            set
            {
                try 
                {
                    cantidadVehiculos = int.Parse(value);

                    if (cantidadVehiculos < 1)
                    {
                        Posicion(30, 40);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("¡ERROR! EL DATO INGRESADO NO ES UNA CANTIDAD. SE HA SETEADO 4 VEHICULOS.");
                        Thread.Sleep(2000);
                        Posicion(30, 40);
                        Console.WriteLine("                                                                                           ");
                        cantidadVehiculos = 4;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                }
                catch(Exception e)
                {
                    
                    Posicion(30, 40);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("¡ERROR! EL DATO INGRESADO NO ES UNA CANTIDAD. SE HA SETEADO 4 VEHICULOS.");
                    Thread.Sleep(2000);
                    Posicion(30, 40);
                    Console.WriteLine("                                                                                           ");
                    cantidadVehiculos = 4;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
        }

        //CANCIONES/SONIDOS UTILIZADOS EN EL SIMULADOR
        SoundPlayer Llantas = new SoundPlayer();
        SoundPlayer RealGone = new SoundPlayer();
        SoundPlayer YouMightThink = new SoundPlayer();
        SoundPlayer Click = new SoundPlayer();
        SoundPlayer CarStart = new SoundPlayer();
        SoundPlayer LifeIs = new SoundPlayer();
        SoundPlayer Champions = new SoundPlayer();
        
               
        //LISTAS
        List<Vehiculo> Vehiculos = new List<Vehiculo>();
        

        List<Compuesto> Compuestos = new List<Compuesto>()
            {
                new Compuesto { Nombre = "Super Blando", Color = "Rojo", Abreviatura = "SB", Duracion = 10, Ganancia = 0.10 },
                new Compuesto { Nombre = "Blandos", Color = "Amarillo", Abreviatura = "S", Duracion = 15, Ganancia = 0.07 },
                new Compuesto { Nombre = "Medios", Color = "Blanco", Abreviatura = "M", Duracion = 25, Ganancia = 0.02 },
                new Compuesto { Nombre = "Duros", Color = "Marrón", Abreviatura = "H", Duracion = 40, Ganancia = 0 }
            };

        List<Equipo> Equipos = new List<Equipo>()
            {
                new Equipo { Nombre = "Castrol's Pilots", FechaCreacion = DateTime.Parse("25/07/1998"), CompuestoUtilizado = "Super Blando", CantidadMiembros = 0 },
                new Equipo { Nombre = "Dynoco's Team", FechaCreacion = DateTime.Parse("13/02/1995"), CompuestoUtilizado = "Blandos", CantidadMiembros = 0 },
                new Equipo { Nombre = "Kenny's Racing Team", FechaCreacion = DateTime.Parse("2/09/2009"), CompuestoUtilizado = "Medios", CantidadMiembros = 0 },
                new Equipo { Nombre = "Sigua Motors", FechaCreacion = DateTime.Parse("20/05/2013"), CompuestoUtilizado = "Super Blando", CantidadMiembros = 0 },
                new Equipo { Nombre = "Toretto's Team", FechaCreacion = DateTime.Parse("8/10/2013"),CompuestoUtilizado = "Duros", CantidadMiembros = 0 },
                new Equipo { Nombre = "G-Force FIA", FechaCreacion = DateTime.Parse("7/01/2015"), CompuestoUtilizado = "Medios", CantidadMiembros = 0 }

            };


        //METODOS
        /// <summary>
        /// Éste método despliega el menú incial que permite seleccionar entre las posibles opciones
        /// para tratar los datos que utilizará el simulador. 
        /// 
        /// MODO MANUAL:        Permite a los usuarios ingresar los datos de forma manual.
        /// 
        /// MODO AUTOMÁTICO:    Asigna los datos al simulador de manera automática, con valores por 
        ///                     defecto.
        /// </summary>
        /// <returns></returns>
        private bool MenuPrincipal()
        {
            char cursor = (char)62;
            Console.WriteLine("");


            string TeclaPresionada = "cualquiera";
            int posicionDelCursor = 2;

            Posicion(60, 36);
            Console.Write(" ");
            Posicion(28, 36);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("MODO MANUAL");
            Posicion(27, 36);
            Console.Write("{0}", cursor);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Posicion(61, 36);
            Console.Write("MODO AUTOMATICO");
            posicionDelCursor = 27;

            do
            {
                if (Console.KeyAvailable)
                {
                    TeclaPresionada = Console.ReadKey().Key.ToString();
                    switch (TeclaPresionada)
                    {
                        //DERECHA
                        case "RightArrow":
                            {

                                
                                    try
                                    {
                                      Click.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\Click.wav";
                                      Click.Load();
                                      Click.Play(); 
                                    }
                                    catch (Exception) { }
                                    
                               
                               
                                Posicion(27, 36);
                                Console.Write(" ");
                                Posicion(28, 36);
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("MODO MANUAL");
                                Posicion(60, 36);
                                Console.Write("{0}", cursor);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Posicion(61, 36);
                                Console.Write("MODO AUTOMATICO");
                                posicionDelCursor = 60;
                                

                            }
                            break;

                        //IZQUIERDA
                        case "LeftArrow":
                            {
                                try
                                {
                                    Click.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\Click.wav";
                                    Click.Load();
                                    Click.Play();
                                }
                                catch(Exception)
                                { }
                                
                                Posicion(60, 36);
                                Console.Write(" ");
                                Posicion(28, 36);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("MODO MANUAL");
                                Posicion(27, 36);
                                Console.Write("{0}", cursor);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Posicion(61, 36);
                                Console.Write("MODO AUTOMATICO");
                                posicionDelCursor = 27;
                               

                            }
                            break;

                        //ENTER
                        case "Enter":
                            {
                                if (posicionDelCursor == 27)
                                {

                                    try
                                    { 
                                    Llantas.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\Llantas.wav";
                                    Llantas.Load();
                                    Llantas.Play(); 
                                    }
                                    catch (Exception) { }
                                    

                                    Thread.Sleep(2000);
                                    Llantas.Dispose();
                                    Console.Clear();
                                    DatosModoManual();
 
                                }
                                else if (posicionDelCursor == 60)
                                {
                                    try
                                    {
                                    Llantas.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\Llantas.wav";
                                    Llantas.Load();
                                    Llantas.Play();
                                    }
                                    catch (Exception)
                                    {

                                    }
                                    
                                    
                                    Thread.Sleep(2000);
                           
                                    Console.Clear();
                                    Console.SetCursorPosition(60, 50);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("¡TODOS LOS DATOS SERAN ASIGNADOS POR EL SIMULADOR!");
                                    Thread.Sleep(2500);
                                    DatosModoAutomatico();
                                    
                                    
                                }
                            }
                            break;
                        default:
                            Posicion(10, 40);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("¡MOVIMIENTO NO VÁLIDO!");                           
                            Thread.Sleep(500);
                            Posicion(10, 40);
                            Console.Write("                      ");       
                            break;
                            
                    }
                    
                }
                

            } while (TeclaPresionada != "Enter");

            return true;
        }
        /// <summary>
        /// Ingresa los detalles de pista, vehículos, equipos y demás datos de forma autónoma.
        /// </summary>
        private void DatosModoAutomatico()
        {
            try
            {
            YouMightThink.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\YouMightThink.wav";
            YouMightThink.Load();
            YouMightThink.Play();
            }
            catch(Exception)
            {

            }
            

            miPista.Nombre = "West Road";
            miPista.Localidad = "Los Angeles, California";
            miPista.Longitud = "15";
            miPista.Tipo = "Abierta/Ciudad";
            miPista.Vueltas = "5";

            
                Vehiculo v1 = new Vehiculo {Marca = "Dodge", Modelo ="Charger", Equipo = "Toretto's Team", VelocidadMaxima = "195", CombustibleMaximo="25", CombustibleInicial="20", Compuesto="Duros", Apodo="Toretto", PosicionSalida=0, PosicionY=11};
                Vehiculo v2 = new Vehiculo { Marca = "Nissan", Modelo = "Skyline GT-R34", Equipo = "Dynoco's Team", VelocidadMaxima = "215", CombustibleMaximo = "20", CombustibleInicial = "20", Compuesto = "Super Blando", Apodo = "Bryan O'Conner", PosicionSalida = 42, PosicionY = 11 };
                Vehiculo v3 = new Vehiculo { Marca = "Mitsubishi", Modelo = "Lancer Evolution III", Equipo = "Kenny's Racing Team", VelocidadMaxima = "210", CombustibleMaximo = "20", CombustibleInicial = "19", Compuesto = "Medios", Apodo = "Abdias Alvarado", PosicionSalida = 84, PosicionY = 11 };
                Vehiculo v4 = new Vehiculo { Marca = "Acura", Modelo = "Integra", Equipo = "Sigua Motors", VelocidadMaxima = "205", CombustibleMaximo = "15", CombustibleInicial = "14", Compuesto = "Blandos", Apodo = "Héctor S.", PosicionSalida = 126, PosicionY = 11 };

            Vehiculos.Add(v1);
            Vehiculos.Add(v2);
            Vehiculos.Add(v3);
            Vehiculos.Add(v4);

            MenuDetalles(5, 18);

        }
        /// <summary>
        /// Es el método que nos permite garantizar la integridad del simulador, siendo
        /// éste el único método accesible por otras clases.
        /// Llama a los métodos principales del simulador.
        /// </summary>
        /// <returns></returns>
        public bool Iniciar()
        {
            Bienvenida();
            MenuPrincipal();
            return true;
        }
        /// <summary>
        /// Solicita al usuario cambiar la resolución de la ventana y luego llama
        /// a los métodos responsables de mostrar la animación de inicio y un en-
        /// cabezado con fecha, autor y título del proyecto.
        /// </summary>
        /// <returns></returns>
        private bool Bienvenida()
        { 
            Posicion(5, 25);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("¡SE RECOMIENDA PASAR A PANTALLA COMPLETA! PRESIONE: (ALT+ENTER)");
            Console.Read();
            Console.Clear();
            Posicion(-8, 15);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¡SI DESEA EJECUTAR EL SIMULADOR CON AUDIO DEBE COPIAR LA CARPETA CONTENEDORA AL DISCO C:\\ DE LO CONTRARIO ÉSTE NO TENDRÁ SONIDO!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(5000);
            Console.Read();
           
                SoundPlayer RealGone = new SoundPlayer();
                try
                {
                    RealGone.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\Introduccion.wav";
                    RealGone.Load();
                    RealGone.PlayLooping();
                }
                catch(Exception)
                { }
            
            
            Console.Clear();      

            MostrarEncabezado(5,0);
            Thread.Sleep(2500);
            MostrarDibujoCarro(5,6);
            Thread.Sleep(2000);
            Console.Clear();
            DesplazarCarro();

            for (int i = 0; i < 4; i++)
            {                
                MostrarDibujoFIA(5,17);
                Thread.Sleep(700);
                Console.Clear();
                Thread.Sleep(700);
                
            }
            MostrarEncabezado(5,0);
            MostrarDibujoCarro(5,6);
            MostrarDibujoFIA(5,17);
            
            return true;
        }
        /// <summary>
        /// Asigna una posición personalizada en la pantalla como SetCursorPosicion()
        /// pero le suma a las coordenadas deseadas lo necesario para centrar el cursor
        /// en la pantalla.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool Posicion(int x, int y)
        {
            Console.SetCursorPosition(x+30, y);
            return true;
        }
        /// <summary>
        /// Permite al usuario ingresar los detalles de pista, vehículos, equipos y 
        /// demás datos de forma manual.
        /// </summary>
        /// <returns></returns>
        private bool DatosModoManual()
        {
            try
            {
                YouMightThink.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\YouMightThink.wav";
                YouMightThink.Load();
                YouMightThink.Play();
            }
            catch (Exception) { }
            LimpiarPantalla();

            Console.ReadLine();
            miPista.InsertarDatos(5, 18);

            LimpiarPantalla();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(5, 18);
            Console.Write("¿CUANTOS VEHÍCULOS PONDRÁ EN EL SIMULADOR?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Posicion(5, 19);
            Console.Write("R=> ");
            CantidadVehiculos = Console.ReadLine();
            
            LimpiarPantalla();
            //QUEREMOS MOSTRAR LOS NOMBRES DE LOS EQUIPOS EXISTENTES.
            MostrarEquipos(5, 18, "Nombres");
            RegistrarVehiculos(5, 32, cantidadVehiculos);                   

            return true;
        }
        /// <summary>
        /// Imprime el dibujo del vehículo con símbolos en las coordenadas específicas.
        /// </summary>
        /// <param name="x">Coordenada inicial en el eje X.</param>
        /// <param name="y">Coordenada inicial en el eje Y.</param>
        /// <returns></returns>
        private bool MostrarDibujoCarro(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Posicion(x, y);
            Console.WriteLine("                                       _._                                              ");
            Posicion(x, y+1);
            Console.WriteLine("                                  _.-=`_-         _                                     ");
            Posicion(x, y + 2);
            Console.WriteLine("                            _.-=`   _-          | ||````````---._______     __..        ");
            Posicion(x, y + 3);
            Console.WriteLine("                ___.===````-.______-,,,,,,,,,,,,`-''----` ``````       `````  __`       ");
            Posicion(x, y + 4);
            Console.WriteLine("          __.--``     __        ,'                   o \\           __        [__|      ");
            Posicion(x, y + 5);
            Console.WriteLine("     __-``=======.--``  ``--.=================================.--``  ``--.=======:      ");
            Posicion(x, y + 6);
            Console.WriteLine("    ]       [w] : /        \\ : |========================|    : /        \\ :  [w] :    ");
            Posicion(x, y + 7);
            Console.WriteLine("    V___________:|          |: |========================|    :|          |:   _-`       ");
            Posicion(x, y + 8);
            Console.WriteLine("     V__________: \\        / :_|=======================/_____: \\        / :__-`       ");
            Posicion(x, y + 9);
            Console.WriteLine("     -----------`  ``____``  `-------------------------------'  ``____``                ");
            Posicion(x, y + 10);
            Console.WriteLine("                                                                                        ");
           
            

            return true;
        }
        /// <summary>
        /// Simula una animación imprimiendo el vehículo en distintas posiciones
        /// durante un tiempo específico. 
        /// </summary>
        /// <returns></returns>
        private bool DesplazarCarro()
        {

            int yInicial = 0;

            for (int i = 50; i >=0; i--)
            {
                Posicion(i, yInicial);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                       _._                                              ");
                    Posicion(i, yInicial+1);
                    Console.WriteLine("                                  _.-=`_-         _                                     ");
                    Posicion(i, yInicial+2);
                    Console.WriteLine("                            _.-=`   _-          | ||````````---._______     __..        ");
                    Posicion(i, yInicial+3);
                    Console.WriteLine("                ___.===````-.______-,,,,,,,,,,,,`-''----` ``````       `````  __`       ");
                    Posicion(i, yInicial+4);
                    Console.WriteLine("          __.--``     __        ,'                   o \\           __        [__|      ");
                    Posicion(i, yInicial+5);
                    Console.WriteLine("     __-``=======.--``  ``--.=================================.--``  ``--.=======:      ");
                    Posicion(i, yInicial+6);
                    Console.WriteLine("    ]       [w] : /        \\ : |========================|    : /        \\ :  [w] :    ");
                    Posicion(i, yInicial+7);
                    Console.WriteLine("    V___________:|          |: |========================|    :|          |:   _-`       ");
                    Posicion(i, yInicial+8);
                    Console.WriteLine("     V__________: \\        / :_|=======================/_____: \\        / :__-`       ");
                    Posicion(i, yInicial+9);
                    Console.WriteLine("     -----------`  ``____``  `-------------------------------'  ``____``                ");

                    if (i <= 30)
                    {
                        Thread.Sleep(8);
                        Console.Clear();
                    }
                    else
                    {
                        Thread.Sleep(50);
                        Console.Clear();
                    }
                
            }

            return true;
        }
        /// <summary>
        /// Imprime el encabezado en las coordenadas especificadas.
        /// </summary>
        /// <param name="x">Coordenada inicial en eje X.</param>
        /// <param name="y">Coordenada inicial en eje Y.</param>
        /// <returns></returns>
        private bool MostrarEncabezado(int x, int y)
        {
            Posicion(x, y+1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                      BIENVENIDO AL SIMULADOR DE CARRERAS PARA LA FIA                     ");
            Posicion(x, y+2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Posicion(x, y+3);
            Console.WriteLine("          AUTOR => ABDIAS ALVARADO                                                       ");
            Posicion(x, y+4);
            Console.WriteLine("          FECHA => {0}                                                    ", DateTime.Now);
            
            return true;
        }
        /// <summary>
        /// Imprime el dibujo de las letras FIA con símbolos en las coordenadas específicas.
        /// </summary>
        /// <param name="x">Coordenada inicial en el eje X.</param>
        /// <param name="y">Coordenada inicial en el eje Y.</param>
        /// <returns></returns>
        private bool MostrarDibujoFIA(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(x, y);
            Console.WriteLine("******************************************************************************************");
            Posicion(x, y+1);
            Console.WriteLine("*       ___________________         _________________           __________________       *");
            Posicion(x, y + 2);
            Console.WriteLine("*      |+ + + + + + + + + /        |0 0 0 0 0 0 0 0 0|         | * * * * * * * * *|      *");
            Posicion(x, y + 3);
            Console.WriteLine("*      |+ + + ___________/         |_____ 0 0 0 _____|         |* * * ______* * * |      *");
            Posicion(x, y + 4); 
            Console.WriteLine("*      |+ + +|                           |0 0 0|               | * * |      |* * *|      *");
            Posicion(x, y + 5);
            Console.WriteLine("*      |+ + +|                           |0 0 0|               |* * *|      | * * |      *");
            Posicion(x, y + 6);
            Console.WriteLine("*      |+ + +|_________                  |0 0 0|               | * * |______|* * *|      *");
            Posicion(x, y + 7);
            Console.WriteLine("*      |+ + + + + + + +|                 |0 0 0|               |* * * * * * * * * |      *");
            Posicion(x, y + 8);
            Console.WriteLine("*      |+ + + _________|                 |0 0 0|               | * *  ______ * * *|      *");
            Posicion(x, y + 9);
            Console.WriteLine("*      |+ + +|                           |0 0 0|               |* * *|      | * * |      *");
            Posicion(x, y + 10);
            Console.WriteLine("*      |+ + +|                           |0 0 0|               | * * |      |* * *|      *");
            Posicion(x, y + 11);
            Console.WriteLine("*      |+ + +|                      _____|0 0 0|_____          |* * *|      | * * |      *");
            Posicion(x, y + 12);
            Console.WriteLine("*      |+ + +|                     |0 0 0 0 0 0 0 0 0|         | * * |      |* * *|      *");
            Posicion(x, y + 13);
            Console.WriteLine("*      |_____|                     |_________________|         |_____|      |_____|      *");
            Posicion(x, y + 14);
            Console.WriteLine("*                                                                                        *");
            Posicion(x, y + 15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine("*                                                                         SIMULADOR      *");
            Posicion(x, y + 16);
            Console.WriteLine("******************************************************************************************\n");

            return true;
        }
        /// <summary>
        /// Despliega la lista de los equipos registrados en el simulador.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <param name="informacion">"Nombres": Muestra solo los nombres de los equipos. "Completo": Muestra un detalle completo de los equipos.</param>
        /// <returns></returns>
        private bool MostrarEquipos(int x, int y, string informacion)
        {
            int yCoordenada = y;

            if (informacion == "Completo")
            {
                foreach (Equipo E in Equipos)
                {
                    E.MostrarDetalles(x, yCoordenada);
                    yCoordenada += 7;
                }
            }
            else if (informacion == "Nombres")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Posicion(x, y);
                Console.Write("================================= EQUIPOS REGISTRADOS ====================================");
                yCoordenada++;

                foreach (Equipo E in Equipos)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Posicion(x, yCoordenada);
                    Console.Write(E.Nombre);
                    yCoordenada++;
                }

                Posicion(x, yCoordenada+1);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("¿DESEA AGREGAR UN NUEVO EQUIPO? [SI/NO]");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Posicion(x, yCoordenada+2);
                Console.Write("R=> ");
                string respuesta = Console.ReadLine();
                if(respuesta.ToUpper() == "SI")
                {
                    Equipo nuevo = new Equipo();
                    nuevo.NuevoEquipo(x, yCoordenada+3);
                    Equipos.Add(nuevo);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Posicion(30, 40);
                    Console.Write("¡AGREGADO CORRECTAMENTE!");
                    Thread.Sleep(2000);
                    LimpiarPantalla();
                    MostrarEquipos(5, 18, "Nombres");
                   
                }
                else if(respuesta.ToUpper() == "NO")
                {
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Posicion(30, 40);
                    Console.Write("¡OPCIÓN NO VÁLIDA!");
                    Thread.Sleep(2000);
                    LimpiarPantalla();
                    MostrarEquipos(5, 18, "Nombres");
                }

            }

            return true;
        }
        /// <summary>
        /// Despliega la lista de los vehículos registrados en el simulador.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        private bool MostrarVehiculos(int x, int y)
        {
            int yCoordenada = y;

                Posicion(x, y);
                Console.Write("================================ VEHICULOS REGISTRADOS ===================================");
                yCoordenada++;
           
                foreach (Vehiculo V in Vehiculos)
                {
                    V.MostrarDetalles(x, yCoordenada, Equipos, Compuestos);
                    yCoordenada += 9;
                }

            return true;
        }
        /// <summary>
        /// Despliega la lista de los compuestos registrados en el simulador.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        private bool MostrarCompuestos(int x, int y)
        {
            int yCoordenada = y;

            Posicion(x, y);
            Console.Write("=============================== COMPUESTOS REGISTRADOS ===================================");
            yCoordenada++;

            foreach (Compuesto C in Compuestos)
            {
                C.MostrarDetalles(x, yCoordenada);
                yCoordenada += 7;
            }

            return true;
        }
        /// <summary>
        /// Toma la cantidad de vehículos a registrar y los agrega en la lista
        /// de vehículos registrados.
        /// </summary>
        /// <param name="x">Coordenada en X.</param>
        /// <param name="y">Coordenada en Y.</param>
        /// <param name="cantidad">Cantidad de vehículos a registrar.</param>
        /// <returns></returns>
        private bool RegistrarVehiculos(int x, int y, int cantidad)
        {

            int posicion = 0, posY=11;
            for (int i = 0; i<cantidad; i++ )
            {
                //IMPRIMIR EL NUMERO DE VEHICULO Y SUS DATOS
                Vehiculo AutoTemporal = new Vehiculo();
                AutoTemporal.PosicionSalida = posicion;
                AutoTemporal.PosicionY = posY;
                Posicion(x, y - 1);
                Console.WriteLine("VEHÍCULO {0}", i + 1);
                AutoTemporal.InsertarDatos(x, y, Equipos);
                Vehiculos.Add(AutoTemporal);
                LimpiarPantalla();
                MostrarEquipos(5,18, "Nombres");
                posicion += 42;
            }
            LimpiarPantalla();
            MenuDetalles(5, 18);
                return true;
        }
        /// <summary>
        /// Limpia la pantalla y vuelve a imprimir los encabezados propios 
        /// del simulador.
        /// </summary>
        /// <returns></returns>
        private bool LimpiarPantalla()
       {
           Console.Clear();
           MostrarDibujoFIA(5, 0);
           return true;
       }
        /// <summary>
        /// Es un menú secundario que es llamado una vez que los los datos han sido 
        /// ingresados en el modo manual, o una vez que se ingresan automáticamente
        /// los datos.
        /// Su función es mostrar las opciones disponibles para consultar los deta-
        /// lles de la carrera.
        /// </summary>
        /// <param name="x">Coordenada en eje X.</param>
        /// <param name="y">Coordenada en eje Y.</param>
        /// <returns></returns>
        private bool MenuDetalles(int x, int y)
        {
            
            LimpiarPantalla();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Posicion(x, y);
            Console.Write("1) DETALLES DE PISTA");
            Posicion(x, y+1);
            Console.Write("2) DETALLES DE EQUIPOS");
            Posicion(x, y+2);
            Console.Write("3) DETALLES DE VEHÍCULOS");
            Posicion(x, y+3);
            Console.Write("4) DETALLES DE COMPUESTOS");
            Posicion(x, y+4);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("5) INICIAR LA CARRERA");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Posicion(x, y+6);
            Console.Write("R=> ");
            string Respuesta = Console.ReadLine();

            switch(Respuesta)
            {
                case "1":
                    LimpiarPantalla();
                    miPista.MostrarDetalles(5, 18);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.Write("\n\n\n\t\t\t\t\t<= REGRESAR");
                    Console.ReadLine();
                    MenuDetalles(5, 18);
                    break;
                case "2":
                    LimpiarPantalla();
                    MostrarEquipos(5, 18, "Completo");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.Write("\n\n\n\t\t\t\t\t<= REGRESAR");
                    Console.ReadLine();
                    MenuDetalles(5, 18);
                    break;
                case "3":
                    LimpiarPantalla();
                    MostrarVehiculos(5, 18);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.Write("\n\n\n\t\t\t\t\t<= REGRESAR");
                    Console.ReadLine();
                    MenuDetalles(5, 18);
                    break;
                case "4":
                    LimpiarPantalla();
                    MostrarCompuestos(5, 18);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.Write("\n\n\n\t\t\t\t\t<= REGRESAR");
                    Console.ReadLine();
                    MenuDetalles(5, 18);
                    break;
                case "5":
                    try
                    {
                        CarStart.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\CarStart.wav";
                        LifeIs.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\LifeIs.wav";
                        CarStart.Load();
                        LifeIs.Load();
                        CarStart.Play();
                    }
                    catch (Exception) { }
                    Thread.Sleep(2000);
                   
                    LimpiarPantalla();
                    //INICIANDO CARRERA
                    IniciarCarrera(miPista);

                    break;
                default:
                    Console.ForegroundColor =ConsoleColor.Red;
                    Posicion(30, 40);
                    Console.Write("¡ERROR! OPCIÓN NO VÁLIDA.");
                    Thread.Sleep(1000);
                    LimpiarPantalla();
                    MenuDetalles(5, 18);
                    break;
            }

            return true;
        }
        /// <summary>
        /// Pone a en marcha el simulador.
        /// </summary>
        /// <param name="miPista">Objeto Pista que el usuario o el sistema a registrado.</param>
        public void IniciarCarrera(Pista miPista)
        {
            try
            {
                Champions.SoundLocation = @"C:\SimuladorFIA\SimuladorFIA\Resources\Champions.wav";
                LifeIs.PlayLooping();
            }
            catch (Exception) { }

            Console.Clear();

            foreach(Vehiculo V in Vehiculos)
            {
                Console.WriteLine("\t\t\t\t\t\t\t{0} {1} COLOCADO EN LINEA DE SALIDA.", V.Marca, V.Modelo);
                Thread.Sleep(1500);
            }

            Thread.Sleep(3000);
            SimularSemaforo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t¡LA CARRERA HA INICIADO!");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            

            foreach (Vehiculo V in Vehiculos)
            {
                Thread miHilo = new Thread(delegate()
                {
                    V.IniciarCarrera(miPista, V.PosicionSalida, V.PosicionY);
                   
                });
               
                miHilo.Start();
                
                               
            }

            int contador = 0;
            bool bandera = false;
            do
            {
                for (int i = 0; i < Vehiculos.Count; i++)
                {
                    if (Vehiculos[i].Llegada)
                        contador++; 
                }

                if (contador == Vehiculos.Count)
                {
                    bandera = true;
                }
                else
                {
                    bandera = false;
                    contador = 0;
                }
            }
            while (bandera != true);

            //VALIDAR QUE TODOS ESTEN EN META
            Vehiculo ganador = new Vehiculo();
            ganador = Vehiculos[0];
            for (int i = 0; i < Vehiculos.Count; i++)
            {
                if (ganador.TiempoLlegada > Vehiculos[i].TiempoLlegada)
                {
                    ganador = Vehiculos[i];
                }
                
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t\tANALIZANDO LOS RESULTADOS...");
            Thread.Sleep(4000);
            try
            {
                Champions.Load();
                Champions.Play();
            }
            catch (Exception) { }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n\n\n\t\t\t\t\tEL GANADOR HA SIDO {0} DEL EQUIPO {1} CON UN {2} {3}", ganador.Apodo, ganador.Equipo, ganador.Marca, ganador.Modelo);

	    }
        /// <summary>
        /// Simula un semáforo de carreras.
        /// </summary>
        /// <returns></returns>
        private bool SimularSemaforo()
        {
            Console.Write("\n\t\t\t\t\t\t\t\t\t\t");
            for (int i = 0; i <= 3; i++)
            {
                Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.Red;
                if (i == 3) 
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("*");
            }

                return true;
        }

      

    }
}
