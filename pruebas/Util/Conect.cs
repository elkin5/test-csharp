using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;
using System.Text.RegularExpressions;

namespace pruebas.Util
{
    class Conect
    {
        public static string EjecutarSSH(string pServidor, string pUsuario, string pPassword, string pComando)
        {
            SshStream SSH = null;
            try
            {
                // instancia del objeto SSHShell
                SSH = new SshStream(pServidor, pUsuario, pPassword);
                // ejecutar el comando
                SSH.Write(pComando);

                string ret = SSH.ReadResponse();
                // confirmar
                SSH.Flush();

                return ret;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                //cerrar conexion SSH
                SSH.Close();
            }  // end try
        } // end EjecutarSHH

        public static string test()
        {
             
            //Establecemos la conexión SSH
            const string host = "tmpsao445674";
            SshExec sshExec = new SshExec(host, "tomcat", "XXXsrivera445674");
            sshExec.Connect();

            string result = sshExec.RunCommand(@"cat /etc/redis.conf");

            return result;           
        }

        public static void BajarSCP(string pServidor, string pUsuario, string pPassword, string pFileRemoto, string pFileLocal)
        {
            // instancia del objeto SCP
            Scp SCP = new Scp(pServidor, pUsuario, pPassword);
            try
            {
                // crear conexion SSH
                SCP.Connect();
                // Bajar el archivo
                SCP.From(pFileRemoto, pFileLocal, false);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                //cerrar conexion SCP
                SCP.Close();
            }  // end try
        } // end BajarSCP

        public static void SubirSCP(string pServidor, string pUsuario, string pPassword, string pFileRemoto, string pFileLocal)
        {
            // instancia del objeto SCP
            Scp SCP = new Scp(pServidor, pUsuario, pPassword);
            try
            {
                // crear conexion SSH
                SCP.Connect();
                // Subir el archivo
                SCP.To(pFileLocal, pFileRemoto, false);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                //cerrar conexion SCP
                SCP.Close();
            }  // end try
        } // end SubirSCP

        public static bool validateUrl(string value)
        {
            int i;
            if (!int.TryParse(value, out i))
            {
                //no numérico
                Console.WriteLine(i);
                return false;
            }
            else
            {
                Console.WriteLine(i);
                return true;
            }

            
        }
    }
}
