using Project_2.QLLop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2.BusinessLayer
{
    public class BLLLop
    {
        private LopDao lopDao;

        public BLLLop(string path)
        {
            lopDao = new LopDao(path);
        }
        public List<Lop> GetLop()
        {
            return lopDao.GetLop();
        }

        public bool CapNhatDuLieuLop(string path, List<Lop> thongTinLops)
        {
            return lopDao.CapNhatDuLieuLop(path, thongTinLops);
        }
    }
}
