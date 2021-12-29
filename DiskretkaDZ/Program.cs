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
    //размещения
    public class Placements : CombObj
    {
        private string alph;
        public Placements(string info) : base(info)
        {}
        public Placements(string info, string alph) : base(info)
        {
            this.alph = alph;
        }
        public Placements Next(string t, int k)
        {
            this.alph = t;
            string s = Convert.ToString(alph[k - 1]);
            string min = "element not found";
            int imin = -1;
            for (int i = k; i < alph.Length; i++) 
            {
                if (alph[i] > alph[k - 1])
                {
                    if (min == "element not found")
                    {
                        min = Convert.ToString(alph[i]);
                        imin = i;
                    }
                    else if (alph[i]<Convert.ToChar(min))
                    {
                        min = Convert.ToString(alph[i]);
                        imin = i;
                    }
                }
            }
            if (min != "element not found")
            {
                alph = Swap(alph, k - 1, imin);
                return new Placements(alph.Remove(k), alph);
            }
            else
            {
                alph = Reverse(alph, k);
                int right = -1;
                for (int i = 0; i < k-1; i++)
                {                
                    if (alph[k - 2 - i] < alph[k - 1 - i])
                    {
                        min = Convert.ToString(alph[k - 2 - i]);
                        right = k - 2 - i;
                        break;
                    }
                }
                if (min != "element not found")
                {
                    string min1 = "element not found";
                    int imin1 = -1;
                    int j = -1;
                    for (int i = right; i < alph.Length; i++)
                    {
                        if (alph[i] > alph[right])
                        {
                            if (min1 == "element not found")
                            {
                                min1 = Convert.ToString(alph[i]);
                                imin1 = i;
                            }
                            else if (alph[i] < Convert.ToChar(min1))
                            {
                                min1 = Convert.ToString(alph[i]);
                                imin1 = i;
                            }
                        }
                    }
                    alph = Swap(alph, imin1, right);
                    alph = Reverse(alph, right + 1);
                    return new Placements(alph.Remove(k), alph);
                }
                else return new Placements("element not found", alph);
            }
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
        public string ALPH
        {
            get { return alph; }
            set { alph = value; }
        }
    }

    //перестановки
    public class Permutations : CombObj
    {      
        public Permutations(string info): base(info)
        { }

        //алгоритм Найараны
        public Permutations Next(string alph)
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
    }
    public class Subsets: CombObj
    {      
        public Subsets(string info) : base(info)
        { }
        public Subsets Next(int i, string s)
        {
            List<int> a = Index(i, s);
            string s1 = "";
            for (int j = 0; j < s.Length; j++) 
            {
                if (a[j] == 1) s1 += s[j];
            }
            return new Subsets(s1);
        }
        public bool HasNext(string s)
        {
            if (this.INFO == Last(s).INFO) return false;
            else return true;
        }
        public Subsets Last(string s)
        {
            string s1 = "";
            for (int i = 0; i < s.Length; i++) s1 += s[s.Length - 1];
            return new Subsets(s1);
        }
        public List<int> Index(int x, string s)
        {
            List<int> a = new List<int>();
            while (x != 0) 
            {
                if (x % 2 == 1) a.Add(1);
                else a.Add(0);
                x /= 2;
            }
            while(a.Count!=Last(s).INFO.Length)
            {
                a.Add(0);
            }
            a.Reverse();
            return a;
        }
    }
    public class Combinations
    {
        int[] info;
        int[] a;
        public Combinations()
        { }
        public Combinations(int[] info)
        {
            this.info = info;
        }
        public Combinations Next(int[]a, int n, int k)
        {
            int[] b = new int[k+2];
            for (int i = 0; i < k; i++) b[i] = a[i];
            b[k] = n; b[k + 1] = 0;
            for (int i = 0;i<b.Length;i++)
            {
                if(b[i]+1 == b[i+1])
                {
                    b[i] = i;
                }
                else
                {
                    if (i < k)
                    {
                        b[i]++;
                        int[] c = new int[k];
                        for (int j = 0; j < c.Length; j++) c[j] = b[j];
                        Combinations t = new Combinations(c);
                        t.a = b;
                        return t;
                    }
                    else return new Combinations();
                }
            }
            return new Combinations(b);
        }
        public bool HasNext(int k, int n)
        {
            for (int i = 0; i < k; i++)
            {
                if (info[i] + k - i != n) return true;
            }
            return false;
        }
        public void Print(int k)
        {
            for (int i = 0; i < k; i++)
                Console.Write("{0} ", info[i]);
        }
        public int[]INFO
        { 
            get { return info; }
            set { info = value; }
        }
        public int[]A
        {
            get { return a; }
            set { a = value; }
        }

    }

    class Program
    {      
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

            //Console.WriteLine("Количество элементов: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //char[] s = new char[n];
            //Console.WriteLine("Заполните алфавит: ");
            //for (int i = 0; i < n; i++)
            //{
            //    s[i] = Convert.ToChar(Console.ReadLine());
            //}
            //string alph = "";
            //Array.Sort(s);
            //for (int i = 0; i < n; i++)
            //{
            //    alph += s[i];
            //}
            //Permutations p = new Permutations(alph);
            //do
            //{
            //    Console.WriteLine(p.INFO);
            //    p = p.Next(p.INFO);
            //} while ((p.HasNext(alph)));
            //Console.WriteLine(p.INFO);

            //string alph = "01234";
            //Placements a = new Placements("012");
            //a.ALPH = alph;
            //for (int i = 0; i < 50; i++)
            //{
            //    Console.WriteLine(a.INFO);
            //    a = a.Next(a.ALPH, 3);
            //}

            //string s = "abcd";
            //Subsets a = new Subsets(s);
            //int j = 0;
            //while(a.HasNext(s))
            //{
            //    a = a.Next(j, s);
            //    Console.WriteLine(a.INFO);
            //    j++;
            //}

            //Console.WriteLine("n: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("k: ");
            //int k = Convert.ToInt32(Console.ReadLine());
            //int[] b = new int[n];
            //for (int i = 0; i < n; i++) b[i] = i;
            //Combinations a = new Combinations(b);
            //a.A = b;
            //Console.WriteLine();         
            //do
            //{
            //    a.Print(k);
            //    a = a.Next(a.A, n, k);
            //    Console.WriteLine();
            //} while (a.HasNext(k, n));
            //a.Print(k);         
        }
    }
}
