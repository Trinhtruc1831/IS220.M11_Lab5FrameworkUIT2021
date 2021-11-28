using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B05_191121.Models
{
    public class NVTBModel
    {
        private string manhanvien;
        private string mathietbi;
        private string macanho;
        private int lanthu;
        private DateTime ngaybaotri;

        public string MaNhanVien
        {
            get { return manhanvien; }
            set { manhanvien = value; }
        }

        public string MaThietBi
        {
            get { return mathietbi; }
            set { mathietbi = value; }
        }

        public string MaCanHo
        {
            get
            {
                return macanho;
            }
            set { macanho = value; }
        }

        public int LanThu
        {
            get { return lanthu; }
            set { lanthu = value; }
        }
        public DateTime NgayBaoTri
        {
            get { return ngaybaotri; }
            set { ngaybaotri = value; }
        }
    }
}
