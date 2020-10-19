using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sider;
using pruebas.Util;

namespace pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            bool requirePass = true;
            string serverHost = "\t\t\t\t<Valve alwaysBatch=\"true\" batchSize=\"50\""
            + "\n\t\t\t\tclassName=\"com.openintl.security.valve.RedisLogValve\" expiration=\"259200\""
            + "\n\t\t\t\tflushInterval=\"30000\" queueSize=\"50\""
            + "\n\t\t\t\tredisHost=\"&HOST&\" redisPort=\"&PORT&\" />";
          

            Console.WriteLine(serverHost);
            string serverHot = "hola";
            try
            {
                Console.WriteLine("Inicio");
                // Conexión con la base de datos
                var client = new RedisClient("tmpsao445674", 6379);
                //Console.WriteLine("1");
                // Contraseña (si fue ingresada por el instalador)   
                //client.Auth("qwerty");
                Console.WriteLine(client.Ping());
                // Selección de la base de datos
                client.Select(0);

                // Registra una llave con un valor cualquiera
                client.Set("Installed", "RedisInstalledSFBH0708");

                // Obtiene el valor de la llave
                //Console.WriteLine(client.Get("Installed"));
                //Console.WriteLine(client.Get("index0"));

                //string comm = "mkdir /home/tomcat/new";//Console.WriteLine(Conect.EjecutarSSH("tmpsao445674", "tomcat", "XXXsrivera445674", comm));

                //Console.WriteLine(Conect.test());

                Console.WriteLine(Conect.validateUrl("1234567890"));
                Console.WriteLine(Console.ReadKey());
                Console.WriteLine("Fin");
            }
            catch (System.Net.Sockets.SocketException e)
            {
                if (e.Message.Contains("No such host is known"))
                {
                    Console.WriteLine("No se puede comprobar el host");
                }
            }
            catch (ResponseException e)
            {
                if (e.Message.Contains("NOAUTH"))
                {
                    requirePass = false;
                    Console.WriteLine("Necesita password");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
