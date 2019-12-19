using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Base.Enums;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace SqlDependecy
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = "Data Source=LSTK231278\\SQLEXPRESS;Initial Catalog=Practica; Integrated Security=True";
            using (var tableDependency = new SqlTableDependency<Student>(connectionString, "Students"))
            {
                tableDependency.OnChanged += TableDependency_Changed;
                //tableDependency.OnError += TableDependency_OnError;

                tableDependency.Start();
                Console.WriteLine("Waiting for receiving notifications...");
                Console.WriteLine("Press a key to stop");
                Console.ReadKey();
                tableDependency.Stop();
            }
            
        }


        static void TableDependency_Changed(object sender, RecordChangedEventArgs<Student> e)
        {
            
            Console.WriteLine(Environment.NewLine);

            //Si hubo un cambio en la tabla
            if (e.ChangeType != ChangeType.None)
            {
                var changedEntity = e.Entity;
                Console.WriteLine("DML operation: " + e.ChangeType);
                Console.WriteLine("Id: " + changedEntity.Id);
                Console.WriteLine("Name: " + changedEntity.Name);
                Console.WriteLine("Surname: " + changedEntity.Surname);
                Console.WriteLine(Environment.NewLine);

                //Si es INSERT
                if (e.ChangeType.ToString() == "Insert")
                {

                    List<Student> ListaStudents = new List<Student>();
                    if (File.Exists(@"C:\Users\Curso\source\repos\FilesLocal\xml\archivo.xml"))
                    {
                        XmlDocument Doc = new XmlDocument();
                        Doc.Load(@"C:\Users\Curso\source\repos\FilesLocal\xml\archivo.xml");
                        ListaStudents.AddRange(DeserializeFromXml<List<Student>>(Doc.OuterXml));
                    }

                    Student st = new Student
                    {
                        Id = changedEntity.Id,
                        Name = changedEntity.Name,
                        Surname = changedEntity.Surname
                    };
                    
                    ListaStudents.Add(st);
                    SerializeToXml<List<Student>>(ListaStudents, @"C:\Users\Curso\source\repos\FilesLocal\xml\archivo.xml");
                    
                }

                //Si es Delete
                if (e.ChangeType.ToString() == "Delete")
                {
                    XElement Doc = XElement.Load(@"C:\Users\Curso\source\repos\FilesLocal\xml\archivo.xml");
                    
                    foreach (XNode item in Doc.Nodes())
                    {
                        var idAttribute = ((XElement)item).Attributes("Id").FirstOrDefault().Value;
                        //string idAttribute = item.FirstAttribute.Value;
                        if (idAttribute == changedEntity.Id.ToString())
                        {
                            //Console.WriteLine(item);
                            item.Remove();
                            Doc.Save(@"C:\Users\Curso\source\repos\FilesLocal\xml\archivo.xml");
                        }
                    }
                }


                //Si es Update
                if(e.ChangeType.ToString() == "Update")
                {
                    XElement Doc = XElement.Load(@"C:\Users\Curso\source\repos\FilesLocal\xml\archivo.xml");

                    foreach (XElement item in Doc.Nodes())
                    {
                        var idAttribute = item.Attributes("Id").FirstOrDefault().Value;
                        //string idAttribute = item.FirstAttribute.Value;
                        if (idAttribute == changedEntity.Id.ToString())
                        {
                            item.SetElementValue("Name", changedEntity.Name.ToString());
                            item.SetElementValue("Surname", changedEntity.Surname.ToString());
                            //item.ReplaceWith(changedEntity.Name, changedEntity.Surname);
                            
                            Doc.Save(@"C:\Users\Curso\source\repos\FilesLocal\xml\archivo.xml");
                        }
                    }
                }



            }
        }


        //static void TableDependency_OnError(object sender, ErrorEventArgs e)
        //{
        //    Exception ex = e.Error;
        //    throw ex;
        //}





        //public static T DeserializeFromXml<T>(string xml)
        //{
        //    T result;
        //    XmlSerializer ser = new XmlSerializer(typeof(T));
        //    using (TextReader tr = new StringReader(xml))
        //    {
        //        result = (T)ser.Deserialize(tr);
        //    }
        //    return result;
        //}


        //public void SerializeToXml<T>(T obj, string fileName)
        //{
        //    XmlSerializer ser = new XmlSerializer(typeof(T));

        //    //Create a FileStream object connected to the target file 

        //    FileStream fileStream = new FileStream(fileName, FileMode.Create);

        //    ser.Serialize(fileStream, obj);

        //    fileStream.Close();

        //    //MessageBox.Show(this, "Archivo creado correctamente", "Mensaje");

        //}


        public static T DeserializeFromXml<T>(string xml)
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }

        public static void SerializeToXml<T>(T obj, string fileName)

        {

            XmlSerializer ser = new XmlSerializer(typeof(T));

            //Create a FileStream object connected to the target file 

            FileStream fileStream = new FileStream(fileName, FileMode.Create);

            ser.Serialize(fileStream, obj);

            fileStream.Close();

            //MessageBox.Show(this, "Archivo creado correctamente", "Mensaje");

        }


    }
}
