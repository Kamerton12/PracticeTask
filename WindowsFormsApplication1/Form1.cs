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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public void relocateWindows()
        {
            FridgeEdit edit = null;
            FridgeFind find = null;

            foreach (Form f in MdiChildren)
            {
                if (f is FridgeFind)
                {
                    find = (FridgeFind)f;
                }
                if(f is FridgeEdit)
                {
                    edit = (FridgeEdit)f;
                }
            }
            if (edit == null && find == null)
                return;
            else
            if(edit != null && find == null)
            {
                edit.Location = new Point(0, 0);
            }
            else
            if(edit == null && find != null)
            {
                find.Location = new Point(0, 0);
            }
            else
            {
                edit.Location = new Point(0, 0);
                find.Location = new Point(edit.Width, 0);
                find.Width = Width - edit.Width - 20;
                //Width = edit.Width + find.Width + 20;
                find.Height = Height - 67;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void добавлениеХолодильникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int add = 0;
            for(int i = 0; i < MdiChildren.Length; i++)
            {
                if (MdiChildren[i] is FridgeEdit)
                    add++;
            }
            if (add > 0)
                return;
            FridgeEdit f = new FridgeEdit();
            f.MdiParent = this;
            f.Show();
            relocateWindows();
        }

        private void поискХолодильникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int find = 0;
            for (int i = 0; i < MdiChildren.Length; i++)
            {
                if (MdiChildren[i] is FridgeFind)
                    find++;
            }
            if (find > 0)
                return;
            FridgeFind f = new FridgeFind();
            f.MdiParent = this;
            f.Show();
            relocateWindows();
        }

        public void updateTable()
        {
            foreach(Form f in MdiChildren)
            {
                if(f is FridgeFind)
                {
                    ((FridgeFind)f).update();
                    break;
                }
            }
        }

        public void updateFilteringResults()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is FridgeFind)
                {
                    ((FridgeFind)f).updateFilteringResults();
                    break;
                }
            }
        }

        public void updateEdit(int row)
        {
            foreach (Form fr in MdiChildren)
            {
                if (fr is FridgeEdit)
                {
                    ((FridgeEdit)fr).update(row);
                    break;
                }
            }
        }

        public void disableButtons()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is FridgeEdit)
                {
                    ((FridgeEdit)f).disableEditAndDeleteButton();
                    break;
                }
            }
        }

        public void highlightActiveRow()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is FridgeFind)
                {
                    ((FridgeFind)f).highlightActive();
                    break;
                }
            }
        }

        public void dehighlightAllRows()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is FridgeFind)
                {
                    ((FridgeFind)f).deHighlightAll();
                    break;
                }
            }
        }

        public int getFrigdeIdAtRow(int row)
        {
            foreach (Form f in MdiChildren)
            {
                if (f is FridgeFind)
                {
                    int id;
                    if ((id = ((FridgeFind)f).getFridgeIdAtRow(row)) == -1)
                        return -1;
                    return id;
                }
            }
            return -1;
        }

        public void enableButtons()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is FridgeEdit)
                {
                    ((FridgeEdit)f).enableEditAndDeleteButton();
                    foreach (Form fo in MdiChildren)
                    {
                        if (fo is FridgeFind)
                        {
                            int row;
                            if (((row = ((FridgeFind)fo).getRow()) < 0) || (row > Program.fridges.Count - 1))
                                return;

                            //((FridgeEdit)f).update(Program.fridges[row]);
                            ((FridgeEdit)f).update(row);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public int getTableRow()
        {
            foreach (Form fo in MdiChildren)
            {
                if (fo is FridgeFind)
                {
                    return ((FridgeFind)fo).getRow();
                }
            }
            return -1;
            
        }

        public void updateTableActiveRowAndArray(Fridge f)
        {
            foreach (Form fr in MdiChildren)
            {
                if (fr is FridgeFind)
                {
                    ((FridgeFind)fr).updateActiveRowAndArray(f);
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.fridges = new List<Fridge>();
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "JSON files(*.json)|*.json|All files(*.*)|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string name = of.FileName;
                Program.fileName = name;
                this.Text = "Fridges: " + name;
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Fridge>));
                FileStream fs = new FileStream(name, FileMode.Open);
                Program.fridges = (List<Fridge>)json.ReadObject(fs);
                fs.Close();
                updateTable();
            }
            else
                this.Text = "Fridges";
        }

        private void сохранитьКакToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "JSON files(*.json)|*.json|All files(*.*)|*.*";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string name = sf.FileName;
                Program.fileName = name;
                this.Text = "Fridges: " + name;
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Fridge>));
                FileStream fs = new FileStream(name, FileMode.Create);
                json.WriteObject(fs, Program.fridges);
                fs.Close();
            }
            else
                this.Text = "Fridges";
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Program.fileName == null)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "JSON files(*.json)|*.json|All files(*.*)|*.*";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Program.fileName = sf.FileName;
                }
            }
            if (Program.fileName != null)
            {
                this.Text = "Fridges: " + Program.fileName;
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Fridge>));
                FileStream fs = new FileStream(Program.fileName, FileMode.Create);
                json.WriteObject(fs, Program.fridges);
                fs.Close();
            }
            else
            {
                this.Text = "Fridges";
            }
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.fileName = null;
            this.Text = "Fridges";
            Program.fridges = new List<Fridge>();
            updateTable();
            foreach (Form f in MdiChildren)
            {
                if (f is FridgeEdit)
                {
                    ((FridgeEdit)f).disableEditAndDeleteButton();
                    ((FridgeEdit)f).clearFields();
                    break;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            relocateWindows();
        }

        //string name = "test.json";
        //List<Fridge> frid = new List<Fridge>();
        //frid.Add(new Fridge());
        //frid.Add(new Fridge("Атлант", 1000, 20, 5, Fridge.Comfort.Passably));
        //frid.Add(new Fridge("Атлант2", 360, 1, 3, Fridge.Comfort.Good));
        //frid.Add(new Fridge("Атлант3", 720, 200, 1, Fridge.Comfort.Perfect));
        //DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Fridge>));
        //FileStream fs = new FileStream(name, FileMode.Create);
        //json.WriteObject(fs, frid);
        //fs.Close();
    }
}
