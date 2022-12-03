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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Project_2.UserControls
{
    public partial class UC_QuanLySinhVienn : UserControl
    {
        public UC_QuanLySinhVienn()
        {
            InitializeComponent();
        }
        BLLUser bd;

        User user;
        int index = -1;

        private void UC_QuanLyLop_Load(object sender, EventArgs e)
        {
            bd = new BLLUser(ClsMain.pathUserFile);
            HienThiDanhSachUsers();
        }
        private void HienThiDanhSachUsers()
        {
            //users = new List<User>();
            ClsMain.users = bd.GetUsers();
            //dua du lieu vao luoi (datagridview)
            var bindingList = new BindingList<User>(ClsMain.users.Where(n => n.MaSV.Contains(txtSearch.Text) || n.Lop.Contains(txtSearch.Text) == true).ToList());

            var source = new BindingSource(bindingList, null);

            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.DataSource = source;
        }
        private void dgvSinhVien_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.Rows.Count > 0)
            {
                user = new User()
                {
                    ID = Convert.ToInt32(dgvSinhVien.CurrentRow.Cells["colID"].Value.ToString()),
                    MaSV = dgvSinhVien.CurrentRow.Cells["colMa"].Value.ToString(),
                    Tensv = dgvSinhVien.CurrentRow.Cells["ColTen"].Value.ToString(),
                    Diem = dgvSinhVien.CurrentRow.Cells["ColDiem"].Value.ToString(),
                    Lop = dgvSinhVien.CurrentRow.Cells["ColLop"].Value.ToString(),
                    NgaySinh = dgvSinhVien.CurrentRow.Cells["ColNgaysinh"].Value.ToString(),
                    Diachi = dgvSinhVien.CurrentRow.Cells["ColDiachi"].Value.ToString(),
                };
                index = dgvSinhVien.CurrentRow.Index;
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmQuanLySinhVien_Modifies frmQuanLySinhVien_Modifies = new FrmQuanLySinhVien_Modifies();
            frmQuanLySinhVien_Modifies.isAdd = true;
            frmQuanLySinhVien_Modifies.ShowDialog();
            HienThiDanhSachUsers();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                FrmQuanLySinhVien_Modifies frmQuanLySinhVien_Modifies = new FrmQuanLySinhVien_Modifies();
                frmQuanLySinhVien_Modifies.user = user;
                frmQuanLySinhVien_Modifies.isAdd = false;
                frmQuanLySinhVien_Modifies.ShowDialog();
                HienThiDanhSachUsers();
              
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                if (MessageBox.Show("Bạn chắc muốn Xoá Sinh viên này không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ClsMain.users.RemoveAt(index);
                    bd.GhiUser(ClsMain.pathUserFile, ClsMain.users);
                    HienThiDanhSachUsers();
                }
            }
            else
            {
                MessageBox.Show("Bạn Chưa chọn Sinh viên cần xóa!\nXin vui lòng chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
       
       
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
          
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
           
                //  BindingSource bs = new BindingSource();
                //  bs.DataSource = dgvSinhVien.DataSource;
                //  bs.Filter = colID + " like '%" + txtSearch.Text + "%'";
                // dgvSinhVien.DataSource = bs;
                  HienThiDanhSachUsers();
            
           
        }

        //dung để in danh sách ra excel
        //khởi tao file excel

       
        private void button2_Click(object sender, EventArgs e)
        {
           
            int soThuTU = 0;
            int  row = 3;
            string fontName = "Times New Roman";
            int fontSizeTieuDe = 20;
            int fontSizeTenTruong = 16;
            int fontSizeNoiDung = 20;
            string saveExcelFile = @"D:\excel_QLSV.xlsx";

            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Lỗi không thể sử dụng được thư viện EXCEL");
                return;
            }
            xlApp.Visible = false;

            object misValue = System.Reflection.Missing.Value;

            Workbook wb = xlApp.Workbooks.Add(misValue);
            //Tạo Ô Tiêu đề
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            Range row1_TieuDe_QuanLySinhVien = ws.get_Range("A1", "G1");
            row1_TieuDe_QuanLySinhVien.Merge();
            row1_TieuDe_QuanLySinhVien.Font.Size = fontSizeTieuDe;
            row1_TieuDe_QuanLySinhVien.Font.Name = fontName;
            row1_TieuDe_QuanLySinhVien.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            row1_TieuDe_QuanLySinhVien.Value2 = "Quản Lý sinh Viên";

            //Tạo Ô Số Thứ Tự (STT)
            Range row23_STT = ws.get_Range("A2", "A3");//Cột A dòng 2 và dòng 3
            row23_STT.Merge();
            row23_STT.Font.Size = fontSizeTenTruong;
            row23_STT.Font.Name = fontName;
            row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row23_STT.Value2 = "STT";

            //Tạo Ô Mã sinh viên
            Range row23_MaSV = ws.get_Range("B2", "B3");//Cột B dòng 2 và dòng 3
            row23_MaSV.Merge();
            row23_MaSV.Font.Size = fontSizeTenTruong;
            row23_MaSV.Font.Name = fontName;
            row23_MaSV.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row23_MaSV.Value2 = "Mã Sinh Viên";
            row23_MaSV.ColumnWidth = 20;

            //Tạo Ô Tên Sinh viên:
            Range row23_TenSV = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
            row23_TenSV.Merge();
            row23_TenSV.Font.Size = fontSizeTenTruong;
            row23_TenSV.Font.Name = fontName;
            row23_TenSV.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row23_TenSV.ColumnWidth = 20;
            row23_TenSV.Value2 = "Tên Sinh Viên";
            //Tạo Ô Điểm
            Range row23_DIEM = ws.get_Range("D2", "D3");//Cột B dòng 2 và dòng 3
            row23_DIEM.Merge();
            row23_DIEM.Font.Size = fontSizeTenTruong;
            row23_DIEM.Font.Name = fontName;
            row23_DIEM.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row23_DIEM.Value2 = "Điểm";
            row23_DIEM.ColumnWidth = 20;

            //Tạo Ô Lớp:
            Range row23_Lop = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
            row23_Lop.Merge();
            row23_Lop.Font.Size = fontSizeTenTruong;
            row23_Lop.Font.Name = fontName;
            row23_Lop.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row23_Lop.ColumnWidth = 20;
            row23_Lop.Value2 = "Lớp";
            //Tạo Ô Ngày sinh:
            Range row23_Ngaysinh = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
            row23_Ngaysinh.Merge();
            row23_Ngaysinh.Font.Size = fontSizeTenTruong;
            row23_Ngaysinh.Font.Name = fontName;
            row23_Ngaysinh.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row23_Ngaysinh.ColumnWidth = 20;
            row23_Ngaysinh.Value2 = "Ngày Sinh";
            //Tạo Ô ĐỊA CHỈ:
            Range row23_Diachi = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
            row23_Diachi.Merge();
            row23_Diachi.Font.Size = fontSizeTenTruong;
            row23_Diachi.Font.Name = fontName;
            row23_Diachi.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row23_Diachi.ColumnWidth = 20;
            row23_Diachi.Value2 = "Địa chỉ";

            //Tô nền blue các cột tiêu đề:
            Range row23_CotTieuDe = ws.get_Range("A2", "E3");
            //nền vàng
            row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Blue);
            //in đậm
            row23_CotTieuDe.Font.Bold = true;
            //chữ đen
            row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

            if (ws == null)
            {
                MessageBox.Show("Không thể tạo được WorkSheet");
                return;

            }
            foreach (User us in ClsMain.users)
            {
                soThuTU++;
                row++;
                dynamic[] arr = { soThuTU, us.MaSV, us.Tensv, us.Diem, us.Lop, us.NgaySinh, us.Diachi };
                Range rowData = ws.get_Range("A" + row, "G" + row); //lấy dữ liêu từ row a -> i
                rowData.Font.Size = fontSizeNoiDung;
                rowData.Font.Name = fontName;
                rowData.Value2 = arr;
            }
            //ke khung all
            BorderAround(ws.get_Range("A2", "G" + row));
            //Mở File excel sau khi Xuất thành công
            //Lưu file excel xuống Ổ cứng
            wb.SaveAs(saveExcelFile);
            wb.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(ws);
            releaseObject(wb);
            releaseObject(xlApp);
            //đóng file để hoàn tất quá trình lưu trữ

            System.Diagnostics.Process.Start(saveExcelFile);
        }

        //ham kẻ khung cho excel
        private void BorderAround(Range range)
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

            borders.Color = Color.Black;
            borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }

    }
}
