using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.IO;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace FileWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\Curso\Desktop\test");
            //watcher.EnableRaisingEvents = true;
            //watcher.IncludeSubdirectories = true;
            FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\Curso\Desktop\test")
            {
                EnableRaisingEvents = true,
                IncludeSubdirectories = true
            };

            //add Event Handlers
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;

            Console.Read();
        }

        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            //Console.WriteLine("File: {0} renamed to {1} at time: {2}", e.OldName, e.Name, DateTime.Now.ToLocalTime());
        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("File: {0} at time: {1}", e.Name, DateTime.Now.ToLocalTime());
            XDocument Doc = XDocument.Load(@"C:\Users\Curso\Desktop\test\" + e.Name);

            string Name = Doc.Elements().Elements().Elements().ElementAt(0).Value;
            string Surname = Doc.Elements().Elements().Elements().ElementAt(1).Value;

            //Borrar registro de la base de datos

        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("File: {0} created at time: {1}", e.Name, DateTime.Now.ToLocalTime());
            XDocument Doc = XDocument.Load(@"C:\Users\Curso\Desktop\test\" + e.Name);
            
            string Name = Doc.Elements().Elements().Elements().ElementAt(0).Value;
            string Surname = Doc.Elements().Elements().Elements().ElementAt(1).Value;

            //Insertar Name y Surname en la base de datos
            CConexion conexion = new CConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Students VALUES('" + Name + "', '" + Surname + "')";
            comando.ExecuteNonQuery();
            Console.WriteLine("Se realizó un registro");
            conexion.CerrarConexion();
            
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("File: {0} changed at time: {1}", e.Name, DateTime.Now.ToLocalTime());
            XDocument Doc = XDocument.Load(@"C:\Users\Curso\Desktop\test\" + e.Name);

            string Name = Doc.Elements().Elements().Elements().ElementAt(0).Value;
            string Surname = Doc.Elements().Elements().Elements().ElementAt(1).Value;

            //Actualizar Name y Surname en la base de datos
            CConexion conexion = new CConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UPDATE Students SET Surname = '" + Surname + "' WHERE Name = '" + Name + "'";
            comando.ExecuteNonQuery();
            Console.WriteLine("Se realizó una actualización");
            conexion.CerrarConexion();
        }
    }
}
