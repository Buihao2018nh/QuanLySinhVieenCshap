using Microsoft.Office.Interop.Excel;
using Project_2.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2.BusinessLayer
{
   public class BLLUser
    {
        UserDao userDao;
        public BLLUser()
        {
            userDao = new UserDao();
        }
        public BLLUser(string path)
        {
            userDao = new UserDao(path);
        }


        public List<User> GetUsers()
        {
            return userDao.GetUsers();
        }

        public bool GhiUser(string path, List<User> users)
        {
            return userDao.GhiUser(path, users);
        }


    }
}
