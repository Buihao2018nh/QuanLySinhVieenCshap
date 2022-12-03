using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2.QLLop
{
    public class LopDao
    {
        LopDatabase database;
        public LopDao(string path)
        {
            database = new LopDatabase(path);
        }
        public List<Lop> GetLop()
        {
            return database.ReadLopFromFileINI();
        }
        public bool CapNhatDuLieuLop(string path, List<Lop> thongTinLops)
        {
            return database.WriterLopToFileINI(path, thongTinLops);
        }
    }
}
