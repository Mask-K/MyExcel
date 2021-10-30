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
    partial class Table
    {
        public void AddRow()
        {
            dgv.RowCount++;
            if (i > 0)
            {
                dgv.Rows[i - 1].HeaderCell.Value = string.Format((i).ToString(), "0");
            }
            dgv.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");

            for (int j_ = 0; j_ < j; ++j_)
            {
                string cellname = SetCellName(j_, i + 1);
                MyCell cell = new MyCell(cellname);
                cell.Value = 0;
                cell.Exp = "0";
                cell.Col = j_;
                cell.Row = i;
                dictionary.Add(cellname, cell);
            }
            ++i;
        }

        public void AddCol()
        {
            string val = To26Sys(j);
            dgv.Columns.Add(val, val);
            for (int i_ = 0; i_ < i; ++i_)
            {
                string cellname = SetCellName(j, i_ + 1);
                MyCell cell = new MyCell(cellname);
                cell.Value = 0;
                cell.Exp = "0";
                cell.Col = j;
                cell.Row = i_;
                dictionary.Add(cellname, cell);
            }
            ++j;
        }
        public void DelRow()
        {
            if (i > 1 && j > 0)
            {
                if (i.Equals(1) && j <= 1)
                {
                    MessageBox.Show("Не можна зменшити кількість рядків", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for (int j_ = 0; j_ < j; ++j_)
                    {
                        string cellname = SetCellName(j_, i);
                        if (dictionary[cellname].CellsDependOnMe.Count != 0)
                        {
                            MessageBox.Show("Деякі ячейки мають значення або від них залежать.'\n'" +
                                "Не можна видалити рядок", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    for (int j_ = 0; j_ < j; ++j_)
                    {
                        string cellname = SetCellName(j_, i);
                        foreach (var n in dictionary[cellname].CellsIDependOn)
                        {
                            dictionary[n].CellsDependOnMe.Remove(cellname);
                        }
                        dictionary.Remove(cellname);
                    }
                    i--;
                    dgv.Rows.RemoveAt(i);
                }
            }
            else
            {
                MessageBox.Show("Не можна зменшити кількість рядків", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DelCol()
        {
            if (j > 0)
            {
                if (j.Equals(1) && i <= 1)
                {
                    MessageBox.Show("Не можна зменшити кількість стовпчиків", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for (int i_ = 0; i_ < i; ++i_)
                    {
                        string cellname = SetCellName(j - 1, i_ + 1);
                        if (dictionary[cellname].CellsDependOnMe.Count != 0)
                        {
                            MessageBox.Show("Деякі ячейки мають значення або від них залежать.'\n'" +
                                "Не можна видалити стовпчик", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    for (int i_ = 0; i_ < i; ++i_)
                    {
                        string cellname = SetCellName(j - 1, i_ + 1);
                        foreach (var n in dictionary[cellname].CellsIDependOn)
                        {
                            dictionary[n].CellsDependOnMe.Remove(cellname);
                        }
                        dictionary.Remove(cellname);
                    }
                    j--;
                    dgv.Columns.RemoveAt(j);
                }
            }
            else
            {
                MessageBox.Show("Не можна зменшити кількість стовпчиків", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string SetCellName(int col, int row)
        {
            return To26Sys(col) + Convert.ToString(row);
        }
        public string To26Sys(int j_)
        {
            if (j_ <= 25)
            {
                return Convert.ToString(Convert.ToChar(65 + j_));
            }
            int first = j_ / 25;
            int second = j_ % 25;
            string val = Convert.ToString(Convert.ToChar(64 + first));
            val += Convert.ToString(Convert.ToChar(64 + second));

            return val;
        }

    }
}
