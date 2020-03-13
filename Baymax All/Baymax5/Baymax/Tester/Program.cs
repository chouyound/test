using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Baymax;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //2020/3/12 11:16:49
            DateTime dt = Convert.ToDateTime("2020/3/12 8:16:49");
            Console.WriteLine(dt.ToString());

            TimeSpan ts = DateTime.Now - dt;
            Console.WriteLine(ts.Hours.ToString()); 

            //Demo.dll
            //LeidianSimulator.dll

            //Controller controller = Controller.Create("雷电模拟器-1");
            //controller.AllowStart = true;
            //controller.ContentlibName = "TestContent.dll";
            //controller.SimulatorlibName = "LeidianSimulator.dll";
            //Controller.SaveConfig();

            //List<Product> list = new List<Product>();
            //list.Add(new Product(1, "name1", 1.1));
            //list.Add(new Product(1, "name2", 1.2));
            //list.Add(new Product(4, "name4", 1.4));

            ////序列化
            //IFormatter serializer = new BinaryFormatter();
            //FileStream saveFile = new FileStream("Products.bin",FileMode.Create, FileAccess.Write);
            //serializer.Serialize(saveFile, list);
            //saveFile.Close();

            ////反序列化
            //FileStream loadFile = new FileStream("Products.bin", FileMode.Open, FileAccess.Read);
            //List<Product> savedProducts = serializer.Deserialize(loadFile) as List<Product>;
            //loadFile.Close();

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}


        }




        static string getRegCode(string cpuNo,int useMinute,int targetMinute)
        {
            return "";
            //string str = string.Format("{0}-{1}-{2}", cpuNo, useMinute, targetMinute);
            //string pwd = StringEncryptor.Encrypt(str);
            //dm.SetClipboard(pwd);
            //return pwd;
        }
    }
}
