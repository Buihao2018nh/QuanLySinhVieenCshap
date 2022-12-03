using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2.DataLayer
{
    public class UserDao
    {
        private List<User> listUser;
        public List<User> ListUser { get { return listUser; } set { listUser = value; } }

        DocGhiFile docGhi;

        public UserDao()
        {
            listUser = new List<User>()
            {
                new User(){ID=1,MaSV="123456",Tensv="admin",Diem="10",Lop ="20ct114",NgaySinh ="15/03/2002",Diachi = "ninh thuan"},
                   new User(){ID=2,MaSV="123456",Tensv="admin",Diem="10",Lop ="20ct114",NgaySinh ="15/03/2002",Diachi = "ninh thuan"},
            };
        }
        public UserDao(string path)
        {
            listUser = new List<User>();
            docGhi = new DocGhiFile(path);
            listUser = docGhi.DocUser();
        }

        //Thuc hiện các phương thức
        //Lấy danh sách User 
        public List<User> GetUsers()
        {
            return docGhi.DocUser();
        }
        //Ghi file
        public bool GhiUser(string path, List<User> users)
        {
            return docGhi.GhiFile(path, users);
        }
        //Thêm

        //Sửa

        //Xóa

    }
}
