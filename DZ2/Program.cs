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
        static void Check(PlacementsWithRep a, StreamWriter writer1, StreamWriter writer2)
        {
            int count = 0;
            int[] c = new int[a.INFO.Length];
            for (int i = 0; i < a.INFO.Length; i++) 
            {
                if (a.INFO[i] == 'a') count++;              
            }
            for (int i = 0; i < a.INFO.Length; i++)
            {
                if (a.INFO[i] != 'a') 
                {
                    for (int j = 0; j < a.INFO.Length; j++)
                    {
                        if (a.INFO[i] == a.INFO[j]) c[i]++;
                    }
                }
            }
            if (count == 2)
            {
                writer1.WriteLine(a.INFO);
                bool f = true;
                for (int i = 0; i < a.INFO.Length; i++)
                {
                    if (c[i] > 1) f = false;
                }
                if (f) writer2.WriteLine(a.INFO);
            }

        }
        static void Main(string[] args)
        {
            string alph = "abcdef";
            int k = 5;
            string s = "";
            for (int i = 0; i < k; i++)
            {
                s += alph[0];
            }
            PlacementsWithRep a1 = new PlacementsWithRep(s);
            StreamWriter writer1 = new StreamWriter("result1.txt");
            StreamWriter writer2 = new StreamWriter("result2.txt");
            while (a1.HasNext(alph[alph.Length - 1], k))
            {
                Check(a1, writer1, writer2);
                a1 = a1.Next(alph, k);
            }
            writer1.Close();
            writer2.Close();
        }
    }
}
