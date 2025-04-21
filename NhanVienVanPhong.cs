using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KT_OnTap
{
    public class NhanVienVanPhong : NhanVien
    {

        private int _soNgayLamViec;

        public NhanVienVanPhong(string maNhanVien, string hoTen, string gioiTinh, int soNgayLamViec) : base(maNhanVien, hoTen, gioiTinh)
        {
            _soNgayLamViec = soNgayLamViec;
        }
        public NhanVienVanPhong() { }
        public int SoNgayLamViec
        {
            get { return _soNgayLamViec; }
            set { _soNgayLamViec = value; }
        }

        public override long TinhLuong()
        {
            return _soNgayLamViec * 350000;
        }

        override public string ToString()
        {
            return base.ToString() + $" - {_soNgayLamViec, 5}\n";
        }
    }
}