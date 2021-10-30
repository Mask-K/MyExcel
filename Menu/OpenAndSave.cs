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
    public partial class Table
    {
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            StreamWriter streamWriter = new StreamWriter(filename);
            try
            {
                streamWriter.WriteLine(dgv.ColumnCount);
                streamWriter.WriteLine(dgv.RowCount);
                j = 0;
                i = 0;

                for (int i_ = 0; i_ < dgv.ColumnCount; ++i_)
                {
                    for (int j_ = 0; j_ < dgv.RowCount; ++j_)
                    {
                        string cellName = SetCellName(i_, j_ + 1);
                        streamWriter.WriteLine(dictionary[cellName].Value);
                        streamWriter.WriteLine(dictionary[cellName].Exp);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error happend while writing the file");
            }
            finally
            {
                streamWriter.Close();
            }
        }


        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    MessageBox.Show("Такого файлу нема");
                    return;
                }
                string filename = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(filename);
                dgv.Rows.Clear();
                dgv.Columns.Clear();
                dictionary.Clear();
                int cols = Convert.ToInt32(sr.ReadLine());
                int rows = Convert.ToInt32(sr.ReadLine());
                i = 0;
                j = 0;

                for (int j_ = 0; j_ < cols; ++j_)
                {
                    for (int i_ = 0; i_ < rows; ++i_)
                    {
                        string CellName = SetCellName(j_, i_ + 1);
                        var cell = new MyCell(CellName);
                        cell.Value = Convert.ToDouble(sr.ReadLine());
                        cell.Exp = sr.ReadLine();
                        cell.Col = j_;
                        cell.Row = i_;
                        dictionary.Add(CellName, cell);
                    }
                }
                CreateTable(rows, cols);

                for (int j_ = 0; j_ < cols; ++j_)
                {
                    for (int i_ = 0; i_ < rows; ++i_)
                    {
                        string CellName = SetCellName(j_, i_ + 1);
                        dictionary[CellName].SetIDependOn(ref dictionary);
                        if (dictionary[CellName].Exp == "0")
                        {
                            dgv[j_, i_].Value = "";
                        }
                        else
                        {
                            dgv[j_, i_].Value = dictionary[CellName].Value;
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
