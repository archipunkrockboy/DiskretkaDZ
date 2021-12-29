using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DiskretkaDZ
{
    class Program
    {
        static void Check1(PlacementsWithRep a, StreamWriter writer1)
        {
            int count = 0;
            for (int i = 0; i < a.INFO.Length; i++)
            {
                if (a.INFO[i] == 'a') count++;  
            }
            if (count > 2) writer1.WriteLine(a.INFO);
        }
        static void Check2(PlacementsWithRep a, StreamWriter writer2)
        {
            int count = 0;
            for (int i = 0; i < a.INFO.Length; i++)
            {
                if (a.INFO[i] == 'a') count++;
            }
            if (count > 2) writer2.WriteLine(a.INFO);
        }
        static void Main(string[] args)
        {
            string alph = "abcdef";
            int k1 = 4; int k2 = 7;
            string s1 = ""; string s2 = "";
            for (int i = 0; i < k1; i++)
            {
                s1 += alph[0];
            }
            for (int i = 0;i<k2;i++)
            {
                s2 += alph[0];
            }
            PlacementsWithRep a1 = new PlacementsWithRep(s1);
            PlacementsWithRep a2 = new PlacementsWithRep(s2);
            StreamWriter writer1 = new StreamWriter("result1.txt");
            StreamWriter writer2 = new StreamWriter("result2.txt");
            while (a1.HasNext(alph[alph.Length - 1], k1))
            {
                Check1(a1, writer1);
                a1 = a1.Next(alph, k1);
            }
            while (a2.HasNext(alph[alph.Length - 1], k2))
            {
                Check1(a2, writer2);
                a2 = a2.Next(alph, k2);
            }
            writer1.Close();
            writer2.Close();
        }
    }
}