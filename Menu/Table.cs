using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Table : Form
    {
        public int i = 0;
        public int j = 0;
        private Dictionary<string, MyCell> dictionary = new Dictionary<string, MyCell>();

        public Table()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            CreateTable(14, 12);
            for(int j_ = 0; j_ < j; ++j_)
            {
                for(int i_ = 0; i_ < i; ++i_)
                {
                    string cellname = SetCellName(j_, i_ + 1);
                    MyCell cell = new MyCell(cellname);
                    cell.Value = 0;
                    cell.Exp = "0";
                    cell.Col = j_;
                    cell.Row = i_;
                    dictionary.Add(cellname, cell);
                }
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string cellName = SetCellName(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex + 1);
            if(dictionary[cellName].Exp != "0")
            {
                textBoxFunctions.Text = dictionary[cellName].Exp;
            }
            else
            {
                textBoxFunctions.Text = "";
            }
        }
        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int i_ = e.RowIndex;
            int j_ = e.ColumnIndex;
            string cellName = SetCellName(j_, i_ + 1);
            if (dictionary[cellName] != null)
            {
                dgv.Rows[i_].Cells[j_].Value = dictionary[cellName].Exp;
            }
        }

        public bool ReccurenseCheck(MyCell Current, MyCell Initial)
        {
            if (Current.CellsIDependOn.Contains(Initial.Name))
                return true;
            foreach (string cellName in Current.CellsIDependOn)
            {
                if (ReccurenseCheck(dictionary[cellName], Initial))
                    return true;
            }
            return false;
        }
        private void CopyList(ref List<string> s1, List<string> s2)
        {
            foreach(var m in s2)
            {
                s1.Add(m);
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int i_ = e.RowIndex;
            int j_ = e.ColumnIndex;
            if (dgv[e.ColumnIndex, e.RowIndex].Value != null)
            {
                string cellName = SetCellName(j_, i_ + 1);
                double cValue = dictionary[cellName].Value;
                string cExp = dictionary[cellName].Exp;
                int cRow = dictionary[cellName].Row;
                int cCol = dictionary[cellName].Col;
                List<string> cCellsDependOnMe = new List<string>();
                CopyList(ref cCellsDependOnMe, dictionary[cellName].CellsDependOnMe);
                List<string> cCellsIDependOn = new List<string>();
                CopyList(ref cCellsIDependOn, dictionary[cellName].CellsIDependOn);
                try
                {
                    if (i_ >= 0 && j_ >= 0)
                    {
                        dictionary[cellName].Exp = dgv[j_, i_].Value.ToString();
                        dictionary[cellName].SetIDependOn(ref dictionary);

                        string input = dictionary[cellName].AddressesToValue(ref dictionary);
                        if (ReccurenseCheck(dictionary[cellName], dictionary[cellName]))
                        {
                            throw new Exception("Reccurense is present\n The cell will be returned to its form");
                        }
                        else
                        {
                            double res = Calculator.Evaluate(input);
                            string s = Convert.ToString(res);
                            dgv.Rows[i_].Cells[j_].Value = s;
                            dictionary[cellName].Value = res;
                            RefreshCells(SetCellName(e.ColumnIndex, e.RowIndex + 1));
                        }
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(
                        a.Message,
                        "Помилка у виразі",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dictionary[cellName].Exp = cExp;
                    dictionary[cellName].Value = cValue;
                    dictionary[cellName].ClearDependies(ref dictionary);
                    dictionary[cellName].CellsDependOnMe = cCellsDependOnMe;
                    dictionary[cellName].CellsIDependOn = cCellsIDependOn;
                    dictionary[cellName].BackUpDependies(ref dictionary);
                    if (dictionary[cellName].Exp == "0" && dictionary[cellName].CellsIDependOn.Count.Equals(0) 
                        && dictionary[cellName].CellsDependOnMe.Count.Equals(0))
                    {
                        dgv[j_, i_].Value = "";
                    }
                    else
                    {
                        dgv[j_, i_].Value = dictionary[cellName].Value;
                    }
                }
            }
        }

        private void RefreshCells(string initialCell)
        {
                foreach (var item in dictionary[initialCell].CellsDependOnMe)
                {
                    dictionary[item].Value = Calculator.Evaluate(dictionary[item].AddressesToValue(ref dictionary));
                    if (dictionary[item].Value.ToString() == "0" && dictionary[item].CellsDependOnMe.Count.Equals(0) 
                    && dictionary[item].CellsIDependOn.Count.Equals(0))
                    {
                        dgv[dictionary[item].Col, dictionary[item].Row].Value = null;
                    }
                    else
                    {
                        dgv[dictionary[item].Col, dictionary[item].Row].Value = dictionary[item].Value;
                    }
                    RefreshCells(item);
                }
        }

        public void CreateTable(int row, int col)
        {
            dgv.RowCount = row;
            dgv.ColumnCount = col;
            
            for (; j < col; ++j)
            {
                string val = To26Sys(j);
                dgv.Columns[j].Name = val;
                dgv.Columns[j].HeaderText = val;
            }
            for (; i <= dgv.Rows.Count - 1; i++)
            {
                dgv.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");
            }
            
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void buttonAddCol_Click(object sender, EventArgs e)
        {
            AddCol();
        }

        private void buttonDelRow_Click(object sender, EventArgs e)
        {
            DelRow();
        }

        private void buttonDelCol_Click(object sender, EventArgs e)
        {
            DelCol();
        }

        private void buttonWho_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Клименко Максим К26, варіант 11", "Автор, варіант");
        }

        private void buttonConditions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1.+,-,*,/ (бінарні операції)\n" + "2.^(піднесення до степеню)\n" + "3.inc, dec\n" + "4.max,min (з двох комірок)\n", "Які операції " +
               "мають підтримуватись", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonWarn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Розмір таблиці не може перевищувати 100 на 100", "Застереження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }
    }
}
