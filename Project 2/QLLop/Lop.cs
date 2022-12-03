using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2.QLLop
{
    public class Lop
    {
        private int id;
        private string maLop;
        private string tenLop;
        private string soSV;

        public int Id { get => id; set => id = value; }
        public string MaLop { get => maLop; set => maLop = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public string SoSV { get => soSV; set => soSV = value; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", Id, MaLop, TenLop, SoSV);
        }

        public override bool Equals(object obj)
        {
            if (obj is Lop)
            {
                return ((Lop)obj).maLop.ToString().Equals(this.maLop.ToString());
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj is Lop)
            {
                return ((Lop)obj).maLop.CompareTo(this.maLop);
            }
            return -1;
        }
    }
}
