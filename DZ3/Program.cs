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
            int[] c = new int[a.INFO.Length];
            int count2 = 0; int count3 = 0;
            for (int i = 0;i<a.INFO.Length;i++)
            {
                for (int j = 0; j < a.INFO.Length; j++) 
                {
                    if (a.INFO[i] == a.INFO[j]) c[i]++;
                }
            }
            for (int i = 0; i < a.INFO.Length; i++)
            {
                if (c[i] == 2) count2++;
                if (c[i] > 2) count3++;
            }
            if (count2 == 2 && count3 == 0)  writer1.WriteLine(a.INFO);
        }
        static void Check2(PlacementsWithRep a, StreamWriter writer2)
        {
            int[] c = new int[a.INFO.Length];
            int count2 = 0; int count3 = 0;
            for (int i = 0; i < a.INFO.Length; i++)
            {
                for (int j = 0; j < a.INFO.Length; j++)
                {
                    if (a.INFO[i] == a.INFO[j]) c[i]++;
                }
            }
            for (int i = 0; i < a.INFO.Length; i++)
            {
                if (c[i] == 2) count2++;
                if (c[i] > 2) count3++;
            }
            if (count2 == 4 && count3 == 0) writer2.WriteLine(a.INFO);
        }    
        static void Main(string[] args)
        {
            string alph = "abcdef";
            int k1 = 5;
            string s1 = "";
            for (int i = 0; i < k1; i++)
            {
                s1 += alph[0];
            }           
            PlacementsWithRep a1 = new PlacementsWithRep(s1);
            StreamWriter writer1 = new StreamWriter("result1.txt");
            StreamWriter writer2 = new StreamWriter("result2.txt");
            while (a1.HasNext(alph[alph.Length - 1], k1))
            {
                Check1(a1, writer1);
                Check2(a1, writer2);
                a1 = a1.Next(alph, k1);
            }
            writer1.Close();
            writer2.Close();
        }
    }
}
