using System.Text;

namespace ejercicio5Ficheros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fecha = DateTime.Today.ToString("ddMMyyyy");
            string rutaArchivo = "C:\\Users\\Profesor\\source\\repos\\ejercicio5Ficheros\\" + fecha + ".txt";

            using (StreamWriter sw = new StreamWriter(rutaArchivo))
            {
                Console.WriteLine("Añada contenido al archivo");
                string contenido = Console.ReadLine();
                sw.Write(contenido + "\n");
            }
            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
            {
                Console.WriteLine("Introduzca nuevo cotenido");
                string masContenido = Console.ReadLine();
                sw.WriteLine(masContenido + "\n");
            }

            Console.WriteLine("Indica 'L' si deseas modificar una linea o 'P' si desees añadir una modificacion a partir de una posicion");
                char modificacion = Convert.ToChar(Console.ReadLine());

                if (modificacion == 'L')
                {
                    Console.WriteLine("Introduce el numero de la linea en la que deseas añadir el texto");
                    int numeroLinea = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Introduce el texto que deseas añadir");
                    string textoNuevo = Console.ReadLine();

                    try
                    {
                        // Leer todas las líneas del archivo
                        string[] lineas = File.ReadAllLines(

                        rutaArchivo);

                        // Verificar si el número de línea deseado está dentro del rango del archivo
                        if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
                        {
                            // Reemplazar el contenido de la línea específica
                            lineas[numeroLinea - 1] = textoNuevo;

                            // Sobrescribir el archivo con las líneas actualizadas
                            File.WriteAllLines(

                         rutaArchivo, lineas);

                            Console.WriteLine("El texto se ha escrito correctamente en la línea especificada.");
                        }
                        else
                        {
                            Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Introduce la posicion en la que deseas añadir el texto");
                    int posicion = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Introduce el texto que deseas añadir");
                    string textoNuevo = Console.ReadLine();

                    try
                    {
                        // Leer todo el contenido del archivo
                        string contenidoOriginal = File.ReadAllText(rutaArchivo);

                        // Verificar si la posición deseada está dentro del rango del archivo
                        if (posicion >= 0 && posicion <= contenidoOriginal.Length)
                        {
                            // Insertar el nuevo texto en la posición deseada
                            string nuevoContenido = contenidoOriginal.Insert(posicion, textoNuevo);

                            // Sobrescribir el archivo con el nuevo contenido
                            File.WriteAllText(rutaArchivo, nuevoContenido);

                            Console.WriteLine("El texto se ha escrito correctamente en la posición especificada.");
                        }
                        else
                        {
                            Console.WriteLine("La posición especificada está fuera del rango del archivo.");
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);

                    }

                }

        }
    }
}