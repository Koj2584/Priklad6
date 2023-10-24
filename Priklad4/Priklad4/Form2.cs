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
            button1.Left = (ClientSize.Width - button1.Width) / 2;
            button1.Top = (ClientSize.Height - button1.Height) / 2;
        }
        int h = 20, w = 50;
        Font f = null;
        Color back = Color.White;
        Color fore = Color.Black;
        System.Drawing.ContentAlignment al = System.Drawing.ContentAlignment.MiddleCenter;
        string textBtn = "Button";
        Button test = new Button();
        Panel panel;

        private void button1_Click(object sender, EventArgs e)
        {
            Form f2 = new Form();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Size = new Size(400, 530);
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
            num2.ValueChanged += Num_ValueChanged1;
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
                    button.Tag = Math.Pow(16,y)*Math.Pow(2,x);
                    button.Size = new Size(50, 50);
                    button.Location = new Point(185+x*60,35+y*60);
                    button.Click += Button_Click;
                    f2.Controls.Add (button);
                }
            }

            panel = new Panel();
            panel.Location = new Point(10, 220);
            panel.Size = new Size(365, 230);
            panel.BackColor = Color.WhiteSmoke;
            panel.BorderStyle = BorderStyle.FixedSingle;
            f2.Controls.Add(panel);
            test.Size = new Size(w, h);
            test.Text = textBtn;
            test.BackColor = back;
            test.ForeColor = fore;
            test.TextAlign = al;
            test.Left = (panel.ClientSize.Width - test.Width) / 2;
            test.Top = (panel.ClientSize.Height - test.Height) / 2;
            panel.Controls.Add(test);

            Button ok = new Button();
            ok.Location = new Point(300, 460);
            ok. Text = "OK";
            ok.DialogResult = DialogResult.OK;
            f2.Controls.Add(ok);

            Button zrus = new Button();
            zrus.Location = new Point(10, 460);
            zrus.Text = "Zrušit";
            zrus.DialogResult = DialogResult.Cancel;
            f2.Controls.Add(zrus);


            if(f2.ShowDialog() == DialogResult.OK)
            {
                button1.Size = new Size(w, h);
                button1.ForeColor = fore;
                button1.BackColor = back;
                button1.Font = f;
                button1.TextAlign = al;
                button1.Text = textBtn;
                button1.Left = (ClientSize.Width - button1.Width) / 2;
                button1.Top = (ClientSize.Height - button1.Height) / 2;
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            textBtn = ((TextBox)sender).Text;
            test.Text = textBtn;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            al = (System.Drawing.ContentAlignment)int.Parse(((Button)sender).Tag.ToString());
            test.TextAlign = al;
        }

        private void Num_ValueChanged1(object sender, EventArgs e)
        {
            h = (int)((NumericUpDown)sender).Value;
            test.Size = new Size(w, h);
            test.Top = (panel.ClientSize.Height - test.Height) / 2;
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            w = (int)((NumericUpDown)sender).Value;
            test.Size = new Size(w, h);
            test.Left = (panel.ClientSize.Width - test.Width) / 2;
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                fore = cd.Color;
                test.ForeColor = fore;
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                back = cd.Color;
                test.BackColor = back;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                f = fontDialog.Font;
                test.Font = f;
            }
        }
    }
}
