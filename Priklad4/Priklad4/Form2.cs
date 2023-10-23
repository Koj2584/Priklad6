using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Priklad4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int h = 20, w = 50;
        Font f = null;
        Color back = Color.White;
        Color fore = Color.Black;
        HorizontalAlignment ha = HorizontalAlignment.Center;
        VerticalAlignment va = VerticalAlignment.Center;
        string textBtn = "Button";
        Button test = new Button();

        private void button1_Click(object sender, EventArgs e)
        {
            Form f2 = new Form();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Size = new Size(400, 500);
            f2.FormBorderStyle = FormBorderStyle.FixedSingle;


            NumericUpDown num = new NumericUpDown();
            Label lbl = new Label();
            lbl.Text = "Width:";
            lbl.Location = new Point(10, 10);
            num.Value = 50;
            num.Minimum = 50; 
            num.Maximum = 200;
            num.Location = new Point(50, 10);
            num.ValueChanged += Num_ValueChanged;
            f2.Controls.Add(num);
            f2.Controls.Add(lbl);

            NumericUpDown num2 = new NumericUpDown();
            Label lbl2 = new Label();
            lbl2.Text = "Hight:";
            lbl2.Location = new Point(10, 50);
            num2.Value = 20;
            num2.Minimum = 20;
            num2.Maximum = 150;
            num2.Location = new Point(50, 50);
            num.ValueChanged += Num_ValueChanged1;
            f2.Controls.Add(num2);
            f2.Controls.Add(lbl2);

            Button btn = new Button();
            btn.Text = "Font";
            btn.Location = new Point(10, 85);
            btn.Click += Btn_Click;
            f2.Controls.Add(btn);

            Button btn2 = new Button();
            btn2.Text = "BackColor";
            btn2.Location = new Point(10, 110);
            btn2.Click += Btn2_Click;
            f2.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Text = "ForeColor";
            btn3.Location = new Point(90, 110);
            btn3.Click += Btn3_Click; ;
            f2.Controls.Add(btn3);

            TextBox txt = new TextBox();
            Label lbl3 = new Label();
            lbl3.Text = "Text:";
            lbl3.Location = new Point(10, 140);
            txt.Location = new Point(50, 140);
            txt.TextChanged += Txt_TextChanged;
            f2.Controls.Add(txt);
            f2.Controls.Add(lbl3);

            Label lbl4 = new Label();
            lbl4.Text = "Text align:";
            lbl4.Location = new Point(185, 10);
            f2.Controls.Add(lbl4);

            for(int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Button button = new Button();
                    button.MinimumSize = new Size(x, y);
                    button.Size = new Size(50, 50);
                    button.Location = new Point(185+x*60,35+y*60);
                    button.Click += Button_Click;
                    f2.Controls.Add (button);
                }
            }

            Panel panel = new Panel();
            panel.Location = new Point(10, 220);
            panel.Size = new Size(365, 230);
            panel.BackColor = Color.WhiteSmoke;
            panel.BorderStyle = BorderStyle.FixedSingle;
            f2.Controls.Add(panel);


            f2.ShowDialog();
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            textBtn = ((TextBox)sender).Text;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            va = (VerticalAlignment)MinimumSize.Height;
            ha = (HorizontalAlignment)MinimumSize.Width;
        }

        private void Num_ValueChanged1(object sender, EventArgs e)
        {
            h = (int)((NumericUpDown)sender).Value;
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            w = (int)((NumericUpDown)sender).Value;
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                fore = cd.Color;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                back = cd.Color;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if(fontDialog.ShowDialog() == DialogResult.OK)
                f = fontDialog.Font;
        }
    }
}
