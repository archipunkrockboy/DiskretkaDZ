using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DiskretkaDZ
{
    public class CombObj
    {
        private string info;
        public CombObj(string info)
        {
            this.info = info;
        }
        public string INFO
        {
            get { return info; }
            set { info = value; }
        }
    }

    //размещения с повторениями
    public class PlacementsWithRep : CombObj
    {      
        public PlacementsWithRep(string info) : base(info)
        { }
        public PlacementsWithRep Next(string alph, int k)
        {
            
            string b = this.INFO;
            for (int i = 0; i < k; i++)
            {
                if (b[b.Length - 1 - i] == alph[alph.Length - 1])
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
    }
    public class Placements
    {
        private string info;      
        public string Swap(string s, int i, int j)
        {
            string s1 = Convert.ToString(s[i]);
            string s2 = Convert.ToString(s[j]);
            s = s.Remove(j, 1);
            s = s.Insert(j, s1);
            s = s.Remove(i, 1);
            s = s.Insert(i, s2);
            return s;
        }
        public string INFO
        {
            get { return info; }
            set { info = value; }
        }
    }

    //перестановки
    public class Permutations : CombObj
    {      
        public Permutations(string info): base(info)
        { }

        public Permutations Nayarana(string alph)
        {
            int right = 0;
            int zap = 0;
            for (int i = 0; i < alph.Length; i++)
            {
                if (alph[Index(alph, this.INFO[this.INFO.Length - i - 2])] < alph[Index(alph, this.INFO[this.INFO.Length - i - 1])])
                {
                    right = Index(alph, this.INFO[alph.Length - i - 2]);
                    break;
                }
            }
            for (int i = 0; i < alph.Length; i++)
            {
                if (alph[right] < alph[Index(alph, this.INFO[alph.Length - i - 1])])
                {
                    zap = Index(alph, this.INFO[alph.Length - i - 1]);
                    break;
                }
            }
            string s = this.INFO;
            s = Swap(s, right, zap);
            Permutations a = new Permutations(Reverse(s, right+1));
            return a;
        }

        public string Reverse(string s, int i)
        {
            string s1 = s;
            s1 = s1.Remove(0, i);
            string s2 = "";
            for (int j = 0; j < s1.Length; j++)
            {
                s2 += Convert.ToString(s1[s1.Length - 1 - j]);
            }
            s = s.Remove(i, s.Length - i);
            s += s2;
            return s;
        }
        public bool HasNext(string alph)
        {
            for (int i = 0; i < alph.Length; i++) 
            {
                if (this.INFO[i] != alph[alph.Length - 1 - i]) return true;
            }
            return false;
        }
        public int Index(string alph, char a)
        {
            for (int i = 0; i < alph.Length; i++)
            {
                if (alph[i] == a)
                {
                    return i;
                }
            }
            return 0;
        }
        public string Swap(string s, int i, int j)
        {
            string s1 = Convert.ToString(s[i]);
            string s2 = Convert.ToString(s[j]);
            s = s.Remove(j, 1);
            s = s.Insert(j, s1);
            s = s.Remove(i, 1);
            s = s.Insert(i, s2);
            return s;
        }

        //public string INFO
        //{
        //    get { return info; }
        //    set { info = value; }
        //}
    }
    class Program
    {
        static void Reverse(string s, int i)
        {
            string s1 = s;
            s1 = s1.Remove(0, i);
            string s2 = "";
            for (int j = 0; j < s1.Length; j++)
            {
                s2 += Convert.ToString(s1[s1.Length - 1 - j]);
            }
            s = s.Remove(i, s.Length-i);
            s += s2;
            Console.WriteLine(s);

        }
        static void Main(string[] args)
        {

            //int k = 3;
            //string s = "";
            //for (int i = 0; i < k; i++)
            //{
            //    s += alph[0];
            //}
            //PlacementsWithRep a = new PlacementsWithRep(s);
            //StreamWriter writer = new StreamWriter("PlacementsWithRep.txt");
            //writer.WriteLine(a.INFO);
            //while (a.HasNext(alph[alph.Length - 1], k))
            //{
            //    a = a.Next(alph, k);
            //    Console.WriteLine(a.INFO);
            //    writer.WriteLine(a.INFO);
            //}
            //writer.Close();

            Console.WriteLine("Количество элементов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            char[] s = new char[n];
            Console.WriteLine("Заполните алфавит: ");
            for (int i = 0; i < n; i++)
            {
                s[i] = Convert.ToChar(Console.ReadLine());
            }
            string alph = "";
            Array.Sort(s);
            for (int i = 0; i < n; i++)
            {
                alph += s[i];
            }
            Permutations p = new Permutations(alph);
            do
            {
                Console.WriteLine(p.INFO);
                p = p.Nayarana(p.INFO);
            } while ((p.HasNext(alph)));
            Console.WriteLine(p.INFO);
           




        }
    }
}
