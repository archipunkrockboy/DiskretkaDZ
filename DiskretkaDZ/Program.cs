using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DiskretkaDZ
{
    public class PlacementsWithRep
    {
        private string info;      
        public PlacementsWithRep(string info)
        {
            this.info = info;
        }
        public PlacementsWithRep Next(string alph, int k)
        {
            //bool perepoln = false;
            string b = this.INFO;
            for (int i = 0; i < k; i++)
            {
                if (/*!perepoln *//*&&*/ b[b.Length - 1 - i] == alph[alph.Length - 1])
                {
                    b = b.Remove(b.Length - 1 - i, 1);
                    b = b.Insert(b.Length - i, Convert.ToString(alph[0]));
                }
                else
                {
                    char t = b[b.Length - 1 - i];
                    b = b.Remove(b.Length - 1 - i, 1);
                    b = b.Insert(b.Length - i, Convert.ToString(this.NextChar(t, alph)));
                    PlacementsWithRep p = new PlacementsWithRep(b);
                    return p;
                }
            }
            PlacementsWithRep v = new PlacementsWithRep(b);
            return v;

        }
        public char NextChar(char a, string alph)
        {
            for (int i = 0; i < alph.Length; i++)
                if (a == alph[i]) return alph[i+1];
            return 'a';
        }
        public bool HasNext(char b, int k)
        {
            string c = "";
            for (int i = 0; i < k; i++)
                c += Convert.ToString(b);
            if (this.INFO == c) return false;
            else return true;
        }    
        public string INFO
        {
            get { return info; }
            set { info = value; }
        }
    }
    public class Permutations
    {
        private string info;


        public string INFO
        {
            get { return info; }
            set { info = value; }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            string alph = "abcd";
            int k = 3;
            string s = "";
            for (int i = 0;i<k;i++)
            {
                s += alph[0];
            }
            PlacementsWithRep a = new PlacementsWithRep(s);
            StreamWriter writer = new StreamWriter("PlacementsWithRep.txt");
            writer.WriteLine(a.INFO);
            while (a.HasNext(alph[alph.Length-1], k))
            {
                a = a.Next(alph, k);
                Console.WriteLine(a.INFO);
                writer.WriteLine(a.INFO);
            }
            writer.Close();
        }
    }
}
