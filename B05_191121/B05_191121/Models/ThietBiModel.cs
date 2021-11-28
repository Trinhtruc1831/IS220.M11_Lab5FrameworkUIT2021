using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B05_191121.Models
{
    public class ThietBiModel
    {
        private string mathietbi;
        private string tenthietbi;

        public string TenThietBi
        {
            get { return tenthietbi; }
            set { tenthietbi = value; }
        }

        public string MaThietBi
        {
            get { return mathietbi; }
            set { mathietbi = value; }
        }
    }
}
