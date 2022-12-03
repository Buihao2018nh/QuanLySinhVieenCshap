using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2.QLLop
{
    public class LopDatabase
    {
        private string path = string.Empty;
        public LopDatabase(string path)
        {
            this.path = path;
        }
        public List<Lop> ReadLopFromFileINI()
        {
            List<Lop> thongTinLop = null;
            //cau truc doc file
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string line = string.Empty;
                    Lop thongTin;
                    thongTinLop = new List<Lop>();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] vs = line.Split(',');
                            thongTin = new Lop()
                            {
                                Id = Convert.ToInt32(vs[0]),
                                MaLop = vs[1],
                                TenLop = vs[2],
                                SoSV = vs[3],

                            };
                            thongTinLop.Add(thongTin);
                        }
                    }
                }
            }
            return thongTinLop;
        }

        public bool WriterLopToFileINI(string path, List<Lop> thongTinLops)
        {
            bool result = false;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    foreach (Lop item in thongTinLops)
                    {
                        streamWriter.WriteLine(string.Format("{0},{1},{2},{3}", item.Id, item.MaLop, item.TenLop, item.SoSV));
                    }
                    result = true;
                }
            }
            return result;
        }
    }
}
