
using Project_2.BusinessLayer;
using Project_2.DataLayer;
using Project_2.QLLop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    public class ClsMain
    {
    // in của quản lý sinh viên
        public static string pathUserFile = string.Format(@"{0}\Users.ini", Application.StartupPath);
        //khai bao danh sach user (toan cu)
        public static List<User> users = null;
        // in của quản lý lớp
        public static string pathLops = string.Format(@"{0}\DanhSachLop.ini", Application.StartupPath);
        //in dl
       

        public static List<Lop> Lops = null;
        public static void CapNhatData(string path, List<User> users)
        {
            BLLUser bd = new BLLUser(path);
        }
    }
}
