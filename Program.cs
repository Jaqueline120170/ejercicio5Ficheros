using System.Text;

namespace ejercicio5Ficheros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fecha = DateTime.Today.ToString("ddMMyyyy");
            string rutaArchivo = "C:\\Users\\Profesor\\source\\repos\\ejercicio5Ficheros\\" + fecha + ".txt";


            string nombreDeudor = "Nombre del Deudor";
            string ibanDeudor = "ES0123456789012345678901";
            decimal monto = 100.50m;

            // Generar el contenido del archivo SEPA
            string contenidoSEPA = GenerarContenidoSEPA(nombreDeudor, ibanDeudor, monto);

            // Escribir el contenido en el archivo
            using (StreamWriter writer = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
            {
                writer.Write(contenidoSEPA);
            }

            Console.WriteLine("Archivo SEPA generado correctamente en: " + rutaArchivo);


            static string GenerarContenidoSEPA(string nombreDeudor, string ibanDeudor, decimal monto)
            {
                // Puedes personalizar esta función según las especificaciones SEPA
                // Aquí se proporciona un ejemplo simple de contenido XML

                StringBuilder contenido = new StringBuilder();

                contenido.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                contenido.AppendLine("<Documento>");
                contenido.AppendLine("  <DatosDeudor>");
                contenido.AppendLine($"    <Nombre>{nombreDeudor}</Nombre>");
                contenido.AppendLine($"    <IBAN>{ibanDeudor}</IBAN>");
                contenido.AppendLine("  </DatosDeudor>");
                contenido.AppendLine($"  <Monto>{monto}</Monto>");
                contenido.AppendLine("</Documento>");

                return contenido.ToString();
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