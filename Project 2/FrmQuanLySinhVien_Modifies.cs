using Project_2.BusinessLayer;
using Project_2.DataLayer;
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
    public partial class FrmQuanLySinhVien_Modifies : Form
    {
        public FrmQuanLySinhVien_Modifies()
        {
            InitializeComponent();
        }

        public User user;
        public bool isAdd = false;
        private void FrmQuanLyUser_Modifies_Load(object sender, EventArgs e)
        {
            bd = new BLLUser(ClsMain.pathUserFile);
            if (isAdd == true)
            {
                //tao id tu dong
                txtID.Text = HamTangID().ToString();
                txtID.Enabled = false;
            }
            else
            {
                txtID.Enabled = false;
                txtID.Text = user.ID.ToString();
                txtMaSV.Text = user.MaSV;
                txtTenSV.Text = user.Tensv;
                txtDiem.Text = user.Diem;
                txtLop.Text = user.Lop;
                txtNgaysinh.Text = user.NgaySinh;
                txtDiachi.Text = user.Diachi;
            }
        }

        private int HamTangID()
        {
            int max = 0;
            foreach (User item in ClsMain.users)
            {
                if (item.ID >= max)
                    max = item.ID;
            }
            return max + 1;
        }

        BLLUser bd;
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (!string.IsNullOrEmpty(txtMaSV.Text))
                {
                    if (!string.IsNullOrEmpty(txtTenSV.Text))
                    {
                        if (!string.IsNullOrEmpty(txtDiem.Text))
                        {
                            if (!string.IsNullOrEmpty(txtLop.Text))
                            {
                                if (!string.IsNullOrEmpty(txtNgaysinh.Text))
                                {
                                    if (!string.IsNullOrEmpty(txtDiachi.Text))
                                    {
                                        user = new User()
                                        {
                                            ID = Convert.ToInt32(txtID.Text),
                                            MaSV = txtMaSV.Text,
                                            Tensv = txtTenSV.Text,
                                            Diem = txtDiem.Text,
                                            Lop = txtLop.Text,
                                            NgaySinh = txtNgaysinh.Text,
                                            Diachi = txtDiachi.Text,
                                        };
                                        if (isAdd)
                                        {
                                            ClsMain.users.Add(user);
                                        }
                                        else
                                        {
                                            //sua
                                            UpdateUser();
                                        }

                                        //Ghi file
                                        bd.GhiUser(ClsMain.pathUserFile, ClsMain.users);
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void UpdateUser()
        {
            foreach (User item in ClsMain.users)
            {
                if (item.ID == user.ID)
                {
                    item.MaSV = user.MaSV;
                    item.Tensv = user.Tensv;
                    item.Diem = user.Diem;
                    item.Lop = user.Lop;
                    item.NgaySinh = user.NgaySinh;
                    item.Diachi = user.Diachi;
                }
            }
        }


        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            txtID.ResetText();
            txtMaSV.ResetText();
            txtTenSV.ResetText();
            txtDiem.ResetText();
            txtLop.ResetText();
            txtNgaysinh.ResetText();
            txtDiachi.ResetText();
        }
    }
}
