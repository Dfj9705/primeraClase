using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace primeraClase
{
    internal class Program
    {
        static void MostrarMenu()
        {
            Console.WriteLine("Menu de Ejercicio no. 1");
            Console.WriteLine("1. Crear y grabar un archivo");
            Console.WriteLine("2. Leer un archivo");
            Console.WriteLine("3. Agregar Linea");
            Console.WriteLine("4. Modificar Linea");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Seleccione una opción");
        }

        static void CrearArchivo()
        {
            StreamWriter fichero;
            fichero = File.CreateText(@"c:\temp\prueba.txt");
            fichero.Close();
        }

        static void LeerArchivo()
        {
            StreamReader fichero;
            fichero = File.OpenText(@"c:\temp\prueba.txt");
            string linea;

            do
            {
                linea = fichero.ReadLine();
                Console.WriteLine(linea);
            } while (linea != null);
            fichero.Close();
        }

        static void AgregarLinea(string linea)
        {
            StreamWriter fichero;
            fichero = File.AppendText(@"c:\temp\prueba.txt");
            fichero.WriteLine(linea);
            fichero.Close();
        }

        static void ModificarLinea(string anterior, string nueva)
        {
            StreamReader ficheroExistente;
            StreamWriter ficheroTemporal;

            ficheroExistente = File.OpenText(@"c:\temp\prueba.txt");
            ficheroTemporal = File.CreateText(@"c:\temp\temporal.txt");

            string lineaExistente;
            string lineaNueva;


            do
            {
                lineaExistente = ficheroExistente.ReadLine();

                if(lineaExistente == anterior)
                {
                    lineaNueva = nueva;
                }
                else
                {
                    lineaNueva = lineaExistente;
                }

                ficheroTemporal.WriteLine(lineaNueva);


            } while (lineaExistente != null);

            ficheroExistente.Close();
            ficheroTemporal.Close();

            File.Delete(@"c:\temp\prueba.txt");
            File.Copy(@"c:\temp\temporal.txt", @"c:\temp\prueba.txt");
            File.Delete(@"c:\temp\temporal.txt");
        }
        
        static void Main(string[] args)
        {
            string opcion;
            string cadena;
            string nueva;

            do
            {
                Console.Clear();
                MostrarMenu();
                opcion = Console.ReadLine().ToString();

                switch (opcion)
                {
                    case "1":
                        CrearArchivo();
                        Console.Write("Archivo creado!");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("El archivo tiene lo siguiente: ");
                        LeerArchivo();
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Ingrese la linea a agregar");
                        cadena = Console.ReadLine().ToString();
                        AgregarLinea(cadena);
                        Console.Write("Linea agregada!");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("Ingrese la linea a modificar");
                        cadena = Console.ReadLine().ToString();
                        Console.WriteLine("Ingrese la linea nueva");
                        nueva = Console.ReadLine().ToString();

                        ModificarLinea(cadena, nueva);

                        Console.WriteLine("Linea modificada!");
                        Console.ReadKey();

                        break;

                    case "5":
                        Console.WriteLine("Programa finalizado");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "5");
        }
    }
}
