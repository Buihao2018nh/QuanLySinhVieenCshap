using Project_2.BusinessLayer;
using Project_2.QLLop;
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
    public partial class UC_QuanLyLop : UserControl
    {
        public UC_QuanLyLop()
        {
            InitializeComponent();
        }

        BLLLop bd;
        Lop thongTinLop = null;
        int index = -1;
        private void FrmQuanLyNguoiDung_Main_Load(object sender, EventArgs e)
        {
            bd = new BLLLop(ClsMain.pathLops);
            HienThiDanhSachLop();
        }

        private void HienThiDanhSachLop()
        {
            ClsMain.Lops = bd.GetLop();
            var bindingList = new BindingList<Lop>(ClsMain.Lops);
            var source = new BindingSource(bindingList, null);
            dsLop.DataSource = source;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
          FrmQuanLyLop_Modified frm_QuanLyNguoiDung_Modified = new FrmQuanLyLop_Modified();
            frm_QuanLyNguoiDung_Modified.isAdd = true;
            frm_QuanLyNguoiDung_Modified.ShowDialog();
            HienThiDanhSachLop();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (thongTinLop != null)
            {
                FrmQuanLyLop_Modified frm_QuanLyNguoiDung_Modified = new FrmQuanLyLop_Modified();
                frm_QuanLyNguoiDung_Modified.isAdd = false;
                frm_QuanLyNguoiDung_Modified.thongTinLop = thongTinLop;
                frm_QuanLyNguoiDung_Modified.ShowDialog();
                HienThiDanhSachLop();
                thongTinLop = null;
            }
        }
        private void dgvUsers_Click(object sender, EventArgs e)
        {
            if (dsLop.Rows.Count > 0)
            {
                thongTinLop = new Lop()
                {
                    Id = Convert.ToInt32(dsLop.CurrentRow.Cells["colId"].Value.ToString()),
                    MaLop = dsLop.CurrentRow.Cells["colMaLop"].Value.ToString(),
                    TenLop = dsLop.CurrentRow.Cells["colTenLop"].Value.ToString(),
                    SoSV = dsLop.CurrentRow.Cells["colSoSV"].Value.ToString(),
                };
                index = dsLop.CurrentRow.Index;
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            if (thongTinLop != null)
            {
                if (MessageBox.Show("Bạn muốn xóa lớp này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClsMain.Lops.RemoveAt(index);
                    bd.CapNhatDuLieuLop(ClsMain.pathLops, ClsMain.Lops);
                    HienThiDanhSachLop();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn lớp");
            }
        }

        private void btnNapLai_Click(object sender, EventArgs e)
        {
            HienThiDanhSachLop();
        }

       
    }
}
