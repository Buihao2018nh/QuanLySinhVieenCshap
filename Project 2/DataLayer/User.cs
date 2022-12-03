using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2.DataLayer
{
   public class User
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string maSV;

        public string MaSV
        {
            get { return maSV; }
            set { maSV = value; }
        }
        private string tensv;

        public string Tensv
        {
            get { return tensv; }
            set { tensv = value; }
        }
        private string diem;

        public string Diem
        {
            get { return diem; }
            set { diem = value; }
        }
        private string lop;

        public string Lop
        {
            get { return lop; }
            set { lop = value; }
        }
        private string ngaySinh;

        public string NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        //Properties



        public User DocUser(string line)
        {
            User user = new User();//khoi tao mot user
            string[] mang = line.Split(',');
            user.ID = Convert.ToInt32(mang[0]);
            user.MaSV = mang[1];
            user.Tensv = mang[2];
            user.Diem = mang[3];
            user.Lop = mang[4];
            user.NgaySinh = mang[5];
            user.Diachi = mang[6];

            return user;
        }
        public void GhiUser(StreamWriter streamWriter)
        {
            streamWriter.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", ID, MaSV, Tensv, Diem, Lop, NgaySinh, Diachi));
        }
    }
}
