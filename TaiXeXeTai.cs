using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KT_OnTap
{
    public class TaiXeXeTai : TaiXeXeKhach, IThuongThem
    {

        public TaiXeXeTai(string maNhanVien, string hoTen, string gioiTinh, long luongCanBan, int soChuyen, long phuCap) : base(maNhanVien, hoTen, gioiTinh, luongCanBan, soChuyen, phuCap)
        {
            
        }

        public TaiXeXeTai() { }

        public override long TinhLuong()
        {
            return LuongCanBan + SoChuyen * 700000 + PhuCap + TinhThuongThem();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public long TinhThuongThem() => 1200000;
    }
}