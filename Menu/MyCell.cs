using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public class MyCell : DataGridViewCell
    {
        double val;
        private string name;// ім'я?
        string exp; // вираз
        int row;
        int col;
        private List<string> cellsIDependOn = new List<string>();
        private List<string> cellsDependOnMe = new List<string>();

        public int[] From26Sys(string cell)
        {
            int[] colRow = { 0, 0 };
            var first_part = new StringBuilder();
            int letter_index = 0;
            foreach (var c in cell)
            {
                if (Char.IsLetter(c))
                {
                    first_part.Append(c);
                    letter_index++;
                    continue;
                }
                string first = first_part.ToString();

                char[] charArr = first.ToCharArray();
                int len = charArr.Length;
                int res = 0;
                for (int i = len - 2; i >= 0; --i)
                {
                    res += (((int)charArr[i] - (int)'A') + 1) * Convert.ToInt32(Math.Pow(26, len - i - 1));
                }
                res += ((int)charArr[len - 1] - (int)'A');
                colRow[0] = res;
                break;
            }
            colRow[1] = Convert.ToInt32(cell.Substring(letter_index)) - 1;

            return colRow;
        }

        public MyCell(string n)
        {
            name = n;
            int[] arr = From26Sys(name);
            row = arr[1];
            col = arr[0];
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Value
        {
            get { return val; }
            set { val = value; }
        }
        public string Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Col
        {
            get { return col; }
            set { col = value; }
        }
        public List<string> CellsIDependOn
        {
            get { return cellsIDependOn; }
            set { cellsIDependOn = value; }
        }
        public List<string> CellsDependOnMe
        {
            get { return cellsDependOnMe; }
            set { cellsDependOnMe = value; }
        }

        private bool AddressPresence(string text, List<string> copy)
        {
            foreach(var el in copy)
            {
                Regex regex = new Regex(el);
                MatchCollection matches = regex.Matches(text);
                if (matches.Count > 0)
                    return true;
            }
            return false;
        }

        private bool CountParen()
        {
            int counter = 0;
            foreach (var str in exp)
            {
                if (str == '(')
                {
                    ++counter;
                }
                else if (str == ')')
                {
                    --counter;
                }
                if (counter < 0)
                {
                    return false;
                }
            }
            if (counter > 0)
            {
                return false;
            }
            return true;
        }
        public string AddressesToValue(ref Dictionary<string, MyCell> dictionary)
        {
            if (!CountParen())
                throw new Exception("Wrong amount of parens");
            string sample = exp;
            CellsIDependOn.Sort((a, b) => b.CompareTo(a));
            List<string> copy = new List<string>(CellsIDependOn);
                for (int i = 0; i < copy.Count; ++i)
                {
                    List<string> temp = new List<string>(copy);
                    Regex regex = new Regex(copy[i]);
                    MatchCollection matches = regex.Matches(sample);
                    if (matches.Count > 0)
                    {
                        sample = sample.Replace(matches[0].ToString(), dictionary[matches[0].ToString()].Value.ToString());
                        copy.AddRange(dictionary[matches[0].ToString()].CellsIDependOn);
                        copy = copy.Distinct().ToList();
                        copy.Remove(matches[0].ToString());
                        copy.Sort((a, b) => b.CompareTo(a));
                        if (temp != copy) 
                        {
                            i = -1;
                        }
                        
                    }
                }
            return sample;
        }

        public void SetIDependOn(ref Dictionary<string, MyCell> dic)
        {
            ClearAllDependOnMe(ref dic);
            foreach(var cell in dic)
            {
                Regex regex = new Regex(cell.Key);
                MatchCollection matches = regex.Matches(exp);
                if(matches.Count > 0)
                {
                    CellsIDependOn.Add(cell.Key);
                }
            }
            SetDependOnMe(ref dic);
        }
        private void SetDependOnMe(ref Dictionary<string, MyCell> dic)
        {
            foreach(var n in dic[name].CellsIDependOn)
            {
                dic[n].CellsDependOnMe.Add(name);
            }
        }

        private void ClearAllDependOnMe(ref Dictionary<string, MyCell> dic)
        {
            foreach(var n in dic[name].CellsIDependOn)
            {
                dic[n].CellsDependOnMe.Remove(name);
            }
            cellsIDependOn.Clear();
        }
        private void ClearAllIDependOn(ref Dictionary<string, MyCell> dic)
        {
            foreach(var n in dic[name].CellsDependOnMe)
            {
                dic[n].CellsIDependOn.Remove(name);
            }
            cellsDependOnMe.Clear();
        }
        public void ClearDependies(ref Dictionary<string, MyCell> dic)
        {
            ClearAllDependOnMe(ref dic);
            ClearAllIDependOn(ref dic);
        }

        public void BackUpDependies(ref Dictionary<string, MyCell> dic)
        {
            foreach(var n in CellsDependOnMe)
            {
                dic[n].CellsIDependOn.Add(name);
            }
            foreach(var n in CellsIDependOn)
            {
                dic[n].cellsDependOnMe.Add(name);
            }
        }
    }
}
