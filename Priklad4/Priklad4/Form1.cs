using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Priklad4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form form2, form3;

        private void button1_Click(object sender, EventArgs e)
        {
            form2 = new Form();
            
            ListBox lb = new ListBox();
            foreach(string s in textBox1.Lines)
                lb.Items.Add(s);
            lb.Dock = DockStyle.Fill;
            form2.Controls.Add(lb);

            Button btn = new Button();
            btn.Dock = DockStyle.Bottom;
            btn.Text = "Button";
            btn.Click += Btn_Click;
            form2.Controls.Add(btn);

            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (Object control in form2.Controls)
            {
                if (control.GetType() == new ListBox().GetType())
                {
                    ((ListBox)control).Items.Clear();
                    foreach (string s in textBox1.Lines)
                        ((ListBox)control).Items.Add(s);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            form3 = new Form();

            Button btn1 = new Button();
            btn1.Text = "Vymaz";
            btn1.Location = new Point(0, 0);
            btn1.Click += Btn1_Click; ;
            form3.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Text = "Zapiš";
            btn2.Location = new Point(0, 30);
            btn2.Click += Btn2_Click; ;
            form3.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Text = "Zavři";
            btn3.Location = new Point(0, 60);
            btn3.Click += Btn3_Click;
            btn3.DialogResult = DialogResult.OK;
            form3.Controls.Add(btn3);

            if (form3.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Špatně zavřeno");
                Application.Exit();
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            form3.Close();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("listbox.txt");
            foreach (Object control in form2.Controls)
            {
                if (control.GetType() == new ListBox().GetType())
                {
                    foreach (string s in ((ListBox)control).Items)
                        sw.WriteLine(s);
                }
            }
            sw.Close();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            foreach (Object control in form2.Controls)
            {
                if (control.GetType() == new ListBox().GetType())
                {
                    ((ListBox)control).Items.Clear();
                }
            }
        }
    }
}
