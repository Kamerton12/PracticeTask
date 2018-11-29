using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FridgeEdit : Form
    {
        public void update(int row)
        {
            int id;
            if ((id = ((Form1)MdiParent).getFrigdeIdAtRow(row)) == -1)
                return;
            Fridge f = Program.fridges[id];
            textBox5.Text = f.make;
            textBox6.Text = f.price.ToString();
            textBox8.Text = f.volume.ToString();
            textBox7.Text = f.reliability.ToString();
            string s = "Не установлено";
            switch(f.comfort)
            {
                case Fridge.Comfort.Good:
                    s = "Хорошая";
                    break;
                case Fridge.Comfort.Perfect:
                    s = "Отличная";
                    break;
                case Fridge.Comfort.Passably:
                    s = "Удовлетворительная";
                    break;
            }
            comboBox2.SelectedIndex = comboBox2.FindStringExact(s);
        }

        public FridgeEdit()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.')
                e.KeyChar = ',';

            int ind = ((TextBox)sender).Text.IndexOf(',');
            if (ind != -1 && e.KeyChar == ',')
            {
                e.Handled = true;
                return;
            }

            try
            {
                if(e.KeyChar != (char)Keys.Back)
                    Convert.ToDecimal(((TextBox)sender).Text + e.KeyChar);
                else
                    Convert.ToDecimal(((TextBox)sender).Text);
            }
            catch
            {
                ((TextBox)sender).Text = "";
            }
        }

        private void FridgeAdd_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Не установлено");
            disableEditAndDeleteButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fridge.Comfort comf = (Fridge.Comfort)comboBox1.SelectedIndex;
            string name = textBox1.Text;
            decimal price = Convert.ToDecimal("0" + textBox2.Text);
            decimal volume = Convert.ToDecimal("0" + textBox3.Text);
            decimal reliability = Convert.ToDecimal("0" + textBox4.Text);
            if(Program.fridges != null)
                Program.fridges.Add(new Fridge(name,price, volume, reliability, comf));
            ((Form1)MdiParent).updateTable();
            //((Form1)MdiParent).updateFilteringResults();
        }

        private void FridgeAdd_FormClosing(object sender, FormClosedEventArgs e)
        {
        }

        public void disableEditAndDeleteButton()
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }
        public void enableEditAndDeleteButton()
        {
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fridge.Comfort comf = (Fridge.Comfort)comboBox2.SelectedIndex;
            string name = textBox5.Text;
            decimal price = Convert.ToDecimal("0" + textBox6.Text);
            decimal volume = Convert.ToDecimal("0" + textBox8.Text);
            decimal reliability = Convert.ToDecimal("0" + textBox7.Text);
            Fridge f = new Fridge(name, price, volume, reliability, comf);
            ((Form1)MdiParent).updateTableActiveRowAndArray(f);
            ((Form1)MdiParent).updateTable();
        }

        public void clearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Не установлено");
            comboBox2.SelectedIndex = comboBox2.FindStringExact("Не установлено");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int row;
            if ((row = ((Form1)MdiParent).getTableRow()) == -1)
                return;
            int id;
            if ((id = ((Form1)MdiParent).getFrigdeIdAtRow(row)) == -1)
                return;
            Program.fridges.RemoveAt(id);
            ((Form1)MdiParent).updateTable();
            if (Program.filtredFridgesId.Count == 0)
                ((Form1)MdiParent).dehighlightAllRows();
        }
    }
}
