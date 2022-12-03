using Project_2.LoGin;
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
    public partial class Frm_DangNhap : Form
    {
        public Frm_DangNhap()
        {
            InitializeComponent();
        }


        

        private void Frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát đăng nhập ?", "Xác nhận", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (NguoiDungDAO.Instance.checkDangNhap(tbTaiKhoan.Text, tbMatKhau.Text) == true)
            {

               
                Frm_Main f = new Frm_Main();
                this.Hide();
                f.ShowDialog();
                return;
            }
            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!\nXin vui lòng chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
