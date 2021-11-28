using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace B05_191121.Models
{
    public class DataContext
    {
        public string ConnectionString { get; set; }
        public DataContext(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public int sqlInsertCanHo(CanHoModel canho)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into canho values(@macanho, @tencanho)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("macanho", canho.MaCanHo);
                cmd.Parameters.AddWithValue("tencanho", canho.TenChuHo);
                return (cmd.ExecuteNonQuery());

            }
        }
        public List<NhanVienModel> sqlListNhanVien()
        {
            List<NhanVienModel> list = new List<NhanVienModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM NHANVIEN";
                SqlCommand cmd = new SqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienModel()
                        {
                            MaNhanVien = reader["manhanvien"].ToString(),
                            TenNhanVien = reader["tennhanvien"].ToString(),
                            SoDienThoai = reader["sodienthoai"].ToString(),
                            GioiTinh = Convert.ToBoolean(reader["gioitinh"])
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> sqlListByTimeNhanVien(int soLan)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select nv.manhanvien, nv.sodienthoai, count(*) AS SoLan
                                from nhanvien nv join nv_bt on nv.manhanvien = nv_bt.manhanvien 
                                group by nv.manhanvien, nv.sodienthoai
                                having count(*) >= @SoLanInput";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("SoLanInput", soLan);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            MaNV = reader["manhanvien"].ToString(),
                            SoDT = reader["sodienthoai"].ToString(),
                            SoLan = Convert.ToInt32(reader["SoLan"])
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<NVTBModel> sqlLietKeTB(string MaNhanVien)
        {
            List<NVTBModel> list = new List<NVTBModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select *
                                from nv_bt 
                                where manhanvien = @MaNhanVien";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MaNhanVien", MaNhanVien);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NVTBModel()
                        {
                            MaNhanVien = reader["manhanvien"].ToString(),
                            MaThietBi = reader["mathietbi"].ToString(),
                            MaCanHo = reader["macanho"].ToString(),
                            LanThu = Convert.ToInt32(reader["lanthu"]),
                            NgayBaoTri = Convert.ToDateTime(reader["ngaybaotri"])
                        });
                    }
                    reader.Close();
                }
                conn.Close();

            }
            return list;
        }
        public int sqlDeleteNVTB(string manv, string matb, string mach, int lt)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"delete from NV_BT
                               where MaNhanVien=@manv and MaThietBi=@matb and MaCanHo=@mach and LanThu=@lt";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("manv", manv);
                cmd.Parameters.AddWithValue("matb", matb);
                cmd.Parameters.AddWithValue("mach", mach);
                cmd.Parameters.AddWithValue("lt", lt);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int sqlUpdateNVBT(string MaNhanVien, string MaThietBi, string MaCanHo, int LanThu, DateTime NgayBaoHanh)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"update NV_BT
                               set NgayBaoTri=@nbt
                               where  MaNhanVien=@manv and MaThietBi=@matb and MaCanHo=@mach and LanThu=@lt";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("manv", MaNhanVien);
                cmd.Parameters.AddWithValue("matb", MaThietBi);
                cmd.Parameters.AddWithValue("mach", MaCanHo);
                cmd.Parameters.AddWithValue("lt", LanThu);
                cmd.Parameters.AddWithValue("nbt", NgayBaoHanh);
                return (cmd.ExecuteNonQuery());
            }
        }

    }
}
