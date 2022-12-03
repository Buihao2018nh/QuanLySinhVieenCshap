using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2.UserControls
{
    public partial class UC_Random : UserControl
    {
        public UC_Random()
        {
            InitializeComponent();
        }


        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chương trình sẽ được thoát.\n Hãy xác định việc này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void btnTaoMaTran_Click(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
            Button btn;
            for (int i = 0; i < 60; i++)
            {
                btn = new Button();
                btn.BackColor = System.Drawing.Color.Blue;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

                btn.Name = "btn" + (i + 1).ToString();
                btn.Size = new System.Drawing.Size(50, 50);
                btn.TabIndex = i;
                btn.Text = new Random().Next(1, 100).ToString();
                btn.UseVisualStyleBackColor = false;
                btn.Click += btnTaoMaTran_Click;
                pnlContainer.Controls.Add(btn);
            }
            if (sender is Button)
            {
                MessageBox.Show(((Button)sender).Text);
            }
        }

       
    }
}
