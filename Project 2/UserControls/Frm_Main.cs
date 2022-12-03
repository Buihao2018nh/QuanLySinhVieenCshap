using Project_2.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    public partial class Frm_Main : Form
    {
        
        public Frm_Main()
        {
            InitializeComponent();
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            {
                if (pnlHeThong.Height == 209)
                {
                    pnlHeThong.Height = 37;

                }
                else
                {
                    pnlHeThong.Height = 209;
                   

                }
            }
        }

        private void btnTacVu_Click(object sender, EventArgs e)
        {
            if (pnlTacVu.Height == 127)
            {
                pnlTacVu.Height = 37;

            }
            else
            {
                pnlTacVu.Height = 127;
                pnlHeThong.Height = 37;

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

      //  private void Frm_Main_Load(object sender, EventArgs e)
      //  {
      //      HienThiFormLogin();
            
      //  }

        //private void HienThiFormLogin()
      //  {
       //     frm_login frmLogin = new frm_login();
       //     frmLogin.ShowDialog();
      //  }

       

       

       
      
        private void addUserControl(UserControl userControls)
        {
            userControls.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(userControls);
            userControls.BringToFront();
        }
        private void Home_Click(object sender, EventArgs e)
        {
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_QuanLySinhVienn uc = new UC_QuanLySinhVienn();
            addUserControl(uc);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_QuanLyNguoiDung uc = new UC_QuanLyNguoiDung();
            addUserControl(uc);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC_QuanLyLop uc = new UC_QuanLyLop();
            addUserControl(uc);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
