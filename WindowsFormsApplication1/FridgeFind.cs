using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FridgeFind : Form
    {
        public FridgeFind()
        {
            InitializeComponent();
        }

        public void updateFilteringResults()
        {
            bool ignoreText = false;
            Regex make = null;
            if (textBox5.Text != "")
            {
                try
                {
                    make = new Regex(textBox5.Text.ToLower());
                }
                catch
                {
                    ignoreText = true;
                }
            }
            else
            {
                ignoreText = true;
            }
            
            decimal minPrice, maxPrice, minVolume, maxVolume, minReiliability, maxReliability;
            if (textBox1.Text.Equals(""))
                minPrice = 0;
            else
            {
                try
                {
                    minPrice = Convert.ToDecimal(textBox1.Text);
                }
                catch
                {
                    minPrice = 0;
                    textBox1.Text = "";
                }
            }
                

            if (textBox2.Text.Equals(""))
                maxPrice = Decimal.MaxValue;
            else
            {
                try
                {
                    maxPrice = Convert.ToDecimal(textBox2.Text);
                }
                catch
                {
                    maxPrice = Decimal.MaxValue;
                    textBox2.Text = "";
                }

            }
                
            if (minPrice > maxPrice)
            {
                decimal t = minPrice;
                minPrice = maxPrice;
                maxPrice = t;
            }

            if (textBox4.Text.Equals(""))
                minVolume = 0;
            else
            {
                try
                {
                    minVolume = Convert.ToDecimal(textBox4.Text);
                }
                catch
                {
                    textBox4.Text = "";
                    minVolume = 0;
                }
            }
                

            if (textBox3.Text.Equals(""))
                maxVolume = Decimal.MaxValue;
            else
            {
                try
                {
                    maxVolume = Convert.ToDecimal(textBox3.Text);
                }
                catch
                {
                    textBox3.Text = "";
                    maxVolume = Decimal.MaxValue;
                }
            }
            if (minVolume > maxVolume)
            {
                decimal t = minVolume;
                minVolume = maxVolume;
                maxVolume = t;
            }

            if (textBox8.Text.Equals(""))
                minReiliability = 0;
            else
            {
                try
                {
                    minReiliability = Convert.ToDecimal(textBox8.Text);
                }
                catch
                {
                    minReiliability = 0;
                    textBox8.Text = "";
                }
            }

            if (textBox7.Text.Equals(""))
                maxReliability = Decimal.MaxValue;
            else
            {
                try
                {
                    maxReliability = Convert.ToDecimal(textBox7.Text);
                }
                catch
                {
                    textBox7.Text = "";
                    maxReliability = Decimal.MaxValue;
                }
            }
            if (minReiliability > maxReliability)
            {
                decimal t = minReiliability;
                minReiliability = maxReliability;
                maxReliability = t;
            }

            Program.filtredFridgesId = new List<int>();
            for (int i = 0; i < Program.fridges.Count; i++)
            {
                bool comfortPass = false;
                switch(Program.fridges[i].comfort)
                {
                    case Fridge.Comfort.Perfect:
                        comfortPass = perf.Checked;
                        break;
                    case Fridge.Comfort.Good:
                        comfortPass = good.Checked;
                        break;
                    case Fridge.Comfort.Passably:
                        comfortPass = pass.Checked;
                        break;
                    case Fridge.Comfort.Unset:
                        comfortPass = unset.Checked;
                        break;
                }

                if (Program.fridges[i].price >= minPrice && Program.fridges[i].price <= maxPrice &&
                    Program.fridges[i].volume >= minVolume && Program.fridges[i].volume <= maxVolume &&
                    Program.fridges[i].reliability >= minReiliability && Program.fridges[i].reliability <= maxReliability &&
                    comfortPass &&
                    (ignoreText || make.IsMatch(Program.fridges[i].make.ToLower())))
                {
                    Program.filtredFridgesId.Add(i);
                }
            }
        }

        public void updateRow(Fridge f, int index, int row)
        {
            dataGridView1[0, row].Value = f.make;
            dataGridView1[1, row].Value = f.price;
            dataGridView1[2, row].Value = f.volume;
            dataGridView1[3, row].Value = f.reliability;
            dataGridView1[5, row].Value = index;

            switch (Program.fridges[index].comfort)
            {
                case Fridge.Comfort.Perfect:
                    dataGridView1[4, row].Value = "Отличная";
                    break;
                case Fridge.Comfort.Good:
                    dataGridView1[4, row].Value = "Хорошая";
                    break;
                case Fridge.Comfort.Passably:
                    dataGridView1[4, row].Value = "Удовлетворительная";
                    break;
                case Fridge.Comfort.Unset:
                    dataGridView1[4, row].Value = "Не установлено";
                    break;
            }
        }

        public void updateActiveRowAndArray(Fridge f)
        {
            int i = dataGridView1.CurrentCellAddress.Y;
            Program.fridges[Convert.ToInt32(dataGridView1[5, i].Value)] = f;
            updateRow(f, Convert.ToInt32(dataGridView1[5, i].Value), i);    
        }

        public void highlightActive()
        {
            int row;
            if ((row = getRow()) == -1)
                return;
            highlightRow(row);
        }

        public void highlightRow(int row)
        {
            if (row == -1)
                return;
            dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Yellow;
        }

        public void deHighlightAll()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
        }

        public int getRow()
        {
            return dataGridView1.CurrentCellAddress.Y;
        }

        public int getFridgeIdAtRow(int row)
        {
            if (row == -1)
                return -1;
            return Convert.ToInt32(dataGridView1[5, row].Value);
        }

        public void update()
        {
            updateFilteringResults();
            ((Form1)MdiParent).dehighlightAllRows();
            if (Program.filtredFridgesId.Count == 0)
            {
                dataGridView1.RowCount = 1;
                for(int i = 0; i < 6; i++)
                {
                    dataGridView1[i, 0].Value = "";
                }
                ((Form1)MdiParent).disableButtons();
                return;
            }

            dataGridView1.RowCount = Program.filtredFridgesId.Count;
            for(int i = 0; i < Program.filtredFridgesId.Count; i++)
            {
                updateRow(Program.fridges[Program.filtredFridgesId[i]], Program.filtredFridgesId[i], i);
            }

            ((Form1)MdiParent).enableButtons();
            ((Form1)MdiParent).highlightActiveRow();
 
        }

        private void FridgeFind_Load(object sender, EventArgs e)
        {
            Program.filtredFridgesId = new List<int>();
            for (int i = 0; i < Program.fridges.Count; i++)
                Program.filtredFridgesId.Add(i);
            dataGridView1.ColumnCount = 6;
            dataGridView1.RowCount = 1;
            dataGridView1.CurrentCell = dataGridView1[0, 0]; 
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[0].Name = "Марка";
            dataGridView1.Columns[1].Name = "Стоимость";
            dataGridView1.Columns[2].Name = "Объем";
            dataGridView1.Columns[3].Name = "Надежность";
            dataGridView1.Columns[4].Name = "Комфортность";
            dataGridView1.Columns[5].Name = "Id";
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            update();
        }

        private void FridgeFind_FormClosing(object sender, FormClosedEventArgs e)
        {
            ((Form1)MdiParent).disableButtons();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            deHighlightAll();
            if (Program.filtredFridgesId.Count == 0)
                return;
            highlightRow(e.RowIndex);
            if (Program.fridges.Count == 0)
                return;

            ((Form1)MdiParent).updateEdit(e.RowIndex);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.')
                e.KeyChar = ',';

            int ind = ((TextBox)sender).Text.IndexOf(',');
            if (ind != -1 && e.KeyChar == ',')
                e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            perf.Checked = true;
            good.Checked = true;
            pass.Checked = true;
            unset.Checked = true;
        }

        private void perf_CheckedChanged(object sender, EventArgs e)
        {
            update();
        }

        private void FridgeFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form1)MdiParent).disableButtons();
        }
    }
}
