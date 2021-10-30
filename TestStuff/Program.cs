using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestStuff
{
    class Program
    {

        static public bool AddressPresence(string text, List<string> s)
        {
            foreach (var el in s)
            {
                Regex regex = new Regex(el);
                MatchCollection matches = regex.Matches(text);
                if (matches.Count > 0)
                    return true;
            }
            return false;
        }



        static public string AddressToValue(Dictionary<string, string> dictionary, ref string m, List<string> s)
        {
            
            s.Sort((a, b) => b.CompareTo(a));
            List<string> f = new List<string>(s);
            while (AddressPresence(m, f))
            {
                for(int i = 0; i < f.Count; ++i)
                {
                    Regex regex = new Regex(f[i]);
                    MatchCollection matches = regex.Matches(m);
                    if (matches.Count > 0)
                    {
                        m = m.Replace(matches[0].ToString(), dictionary[matches[0].ToString()]);
                        List<string> b2 = new List<string>();
                        if(matches[0].ToString() == "B3")
                        {
                            b2.Add("AA1");
                        }
                        if(matches[0].ToString() == "B2")
                        {
                            b2.Add("B3");
                        }
                        f.AddRange(b2);
                        f = f.Distinct().ToList();
                        f.Remove(matches[0].ToString());
                        f.Sort((a, b) => (b.CompareTo(a)));
                        if (b2.Count > 0)
                        {
                            i = -1;
                        }
                    }
                }
            }
            return m;
        }
        static void Main(string[] args)
        {
            //List<string> s = new List<string> { "A1", "B2", "B3"};
            //Dictionary<string, string> dummy = new Dictionary<string, string>() { { "A1", "2" }, { "B2", "B3" }, 
            //    { "AA1", "44" } , {"B3", "AA1 + 2" }, };
            //string m = "A1 + B3 + B2";
            //Console.WriteLine(AddressToValue(dummy, ref m, s));

            string s = "1,5";
            double m = double.Parse(s);
            
            Console.WriteLine(m);
            






            //Console.WriteLine("AB2".CompareTo("B2"));

        }
    }
}
