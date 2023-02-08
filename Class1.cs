using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PROVODNIC_2._0._1
{
    internal class Class1
    {
        public static string put = "";
        //public static string dop_put = "";
        public static int columns = 0;
        //public static List<string> dop_list = new List<string>();
        public static List<string> list = new List<string>();
        //public static List<int> num = new List<int>();
        public static int coun = 0;
        public static void show()
        {
            //List<string> list = new List<string>();
            List<string> i = new List<string>();
            string[] Drives = new string[] {};
            string[] Failel = new string[] { };
            //int windows = 0;
            if (Class1.put != "")
            {
                Drives = Directory.GetDirectories(Class1.put);  //Environment.GetLogicalDrives();
                Failel = Directory.GetFiles(Class1.put);
                foreach (string n in Drives)
                {
                    i.Add(n);
                }
                foreach (string j in Failel)
                {
                    i.Add(j);
                }
                foreach (string file in i)
                {
                    Console.WriteLine("  " + file + "  Дата и время создания - " + File.GetCreationTime(file));
                    list.Add(file);
                    if (Class1.coun == 0)
                    {
                        Class1.columns++;
                    }
                }
            }
            else if (Class1.put == "")
            {
                Drives = Environment.GetLogicalDrives();
                foreach (string n in Drives)
                {
                    list.Add(n);
                }
                foreach (var file in DriveInfo.GetDrives())
                {
                    try
                    {
                        Console.WriteLine("  "+ file.Name + "  " + (file.TotalSize / 1073741824) + " Гб");
                        //list.Add(file);
                    }
                    catch { }
                    if (Class1.coun != 0)
                    {
                        Class1.columns++;
                    }
                }
            }

            /*foreach (string n in Drives)
            {
                i.Add(n);
            } 
            foreach (string j in Failel)
            {
                i.Add(j);
            }*/
        }
    }


    public class str
    {
        bool isListenning = true;
        public int posicion = 1;
        Class1 cllass = new Class1();
        void Cursor(ConsoleKeyInfo key)
        {
            //int posicion = 1;
            if (key.Key == ConsoleKey.UpArrow & posicion != 0)
            {
                posicion--;
                Class1.coun = 1;
                //Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.DownArrow & posicion < (Class1.columns - 1))
            {
                posicion++;
                Class1.coun = 1;
                //Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (Path.GetExtension(Class1.list[posicion]) == "")
                {
                    Class1.put = Class1.list[posicion];
                    //Class1.dop_list.Add(Class1.put);
                    posicion = 0;
                    Class1.coun = 0;
                    Class1.columns = 0;
                    
                }
                else if (Path.GetExtension(Class1.list[posicion]) != "")
                {
                    Process.Start(new ProcessStartInfo { FileName = Class1.list[posicion], UseShellExecute = true });

                }
                Class1.list.Clear();
            }
            else if (key.Key == ConsoleKey.F1)
            {
                posicion = 0;
                Class1.coun = 1;
                Class1.put = "";
                Class1.list.Clear();
            }
            else if (key.Key == ConsoleKey.Delete)
            {
                try
                {
                    File.Delete(Class1.list[posicion]);
                }
                catch { }
                Directory.Delete(Class1.list[posicion], true);
               
            }
            else if (key.Key == ConsoleKey.F5)
            {
                Class1.coun = 0;
                //Class1.columns = 0;
                Console.SetCursorPosition(2, Class1.columns);
                Console.WriteLine("Введите название директории");
                Console.SetCursorPosition(2, Class1.columns + 1);
                string dirn = Console.ReadLine();
                Class1.list.Clear();
                Directory.CreateDirectory(Class1.put + "\\" + dirn);
                Class1.columns = 0;

            }
            else if (key.Key == ConsoleKey.F6)
            {
                Class1.coun = 0;
                //Class1.columns = 0;
                Console.SetCursorPosition(2, Class1.columns);
                Console.WriteLine("Введите название файла");
                Console.SetCursorPosition(2, Class1.columns + 1);
                string dirn = Console.ReadLine();
                Console.SetCursorPosition(2, Class1.columns + 2);
                Console.WriteLine("Введите расширение файла");
                Console.SetCursorPosition(2, Class1.columns + 3);
                string rash = Console.ReadLine();
                Class1.list.Clear();
                File.Create(Class1.put + "\\" + dirn + "." + rash).Close(); 
                Class1.columns = 0;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                isListenning = false;
            }
            Console.Clear();
        }

        public void star()
        {
            Class1.show();
            while (isListenning == true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Cursor(key);
                Class1.show();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine();
                Console.SetCursorPosition(0, posicion);
                Console.WriteLine("->");
            }
        }
    }
}
