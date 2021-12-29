using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DZ8
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader("graph1.txt");
            string s1 = reader1.ReadToEnd();
            reader1.Close();
            StreamReader reader2 = new StreamReader("graph2.txt");
            string s2 = reader2.ReadToEnd();
            reader2.Close();
            StreamWriter writer = new StreamWriter("result.txt");
            if (s1 == s2) writer.WriteLine("Преобразование из графа 1 в граф 2 ЯВЛЯЕТСЯ автоморфизмом");
            else writer.WriteLine("Преобразование из графа 1 в граф 2 НЕ ЯВЛЯЕТСЯ автоморфизмом");
            writer.Close();
        }
    }
}
