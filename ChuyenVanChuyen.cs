using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace KT_OnTap
{
    public class ChuyenVC
    {
        private string tenChuyenVC;
        private string noiDen;
        private List<NhanVien> _nhanViens = new List<NhanVien>();

        public ChuyenVC(string tenChuyenVC, string noiDen, List<NhanVien> nhanViens)
        {
            this.tenChuyenVC = tenChuyenVC;
            this.noiDen = noiDen;
            _nhanViens = nhanViens;
        }
        public ChuyenVC()
        {
        }

        public void DocFile(string fileName) {
            XmlDocument read = new XmlDocument();
            read.Load(fileName);
            
            string tenChuyenVC = read.SelectSingleNode("/ChuyenVC/TenCVC").InnerText;
            string noiDen = read.SelectSingleNode("/ChuyenVC/NoiDen").InnerText;
            XmlNodeList employees = read.SelectNodes("/ChuyenVC/DS/NV");
            foreach (XmlNode employee in employees)
            {
                NhanVien nv = null;
                string loaiNV = employee.Attributes["Loai"].Value;
                string maNhanVien = employee["MA"]?.InnerText;
                string hoTen = employee["TEN"]?.InnerText;
                string gioiTinh = employee["GT"].InnerText;
                if(loaiNV.Equals("VP")) {
                    int soNgayLamViec = int.Parse(employee["SoNgayLV"].InnerText);
                    nv = new NhanVienVanPhong(maNhanVien, hoTen, gioiTinh, soNgayLamViec);
                    _nhanViens.Add(nv);
                }
                else if(loaiNV.Equals("TXXK")) {
                    long luongCanBan = long.Parse(employee["LCBXK"].InnerText);
                    int soChuyen = int.Parse(employee["SOC"].InnerText);
                    long phuCap = long.Parse(employee["PCC"].InnerText);
                    nv = new TaiXeXeKhach(maNhanVien, hoTen, gioiTinh, luongCanBan, soChuyen, phuCap);
                    _nhanViens.Add(nv);
                }
                else if(loaiNV.Equals("TXXT")) {
                    long luongCanBan = long.Parse(employee["LCBXT"].InnerText);
                    int soChuyen = int.Parse(employee["SOC"].InnerText);
                    long phuCap = long.Parse(employee["PCTD"].InnerText);
                    nv = new TaiXeXeTai(maNhanVien, hoTen, gioiTinh, luongCanBan, soChuyen, phuCap);
                    _nhanViens.Add(nv);
                }

            }
            this.tenChuyenVC = tenChuyenVC;
            this.noiDen = noiDen;
            ChuyenVC cvc = new ChuyenVC(tenChuyenVC, noiDen, _nhanViens);
            System.Console.WriteLine("Đọc file thành công");
        }
        public void HienThi()
        {
            Console.WriteLine($"Chuyến vận chuyển: {tenChuyenVC} - Đến: {noiDen}");
            foreach (var nhanVien in _nhanViens)
            {
                Console.WriteLine(nhanVien.ToString());
            }
        }

        public long TinhTongLuong() {
            long tongLuong = 0;
            foreach (NhanVien nv in _nhanViens)
            {
                tongLuong += nv.TinhLuong();
            }
            return tongLuong;
        }

        //Chua hay - lay ra danh sach ms hay...
        public NhanVien? GetInfoEmployeeHasMaxSalary() => _nhanViens.FirstOrDefault(nv => nv.TinhLuong() == 
                                                                                    _nhanViens.Max(nv => nv.TinhLuong()));

        public int GetTotalSoChuyenXeKhach() {
            int count = 0;
            foreach(var nv in _nhanViens)
                if(nv is TaiXeXeKhach taiXeXeKhach) //Pattern matching Nga^`u va~i
                    count += taiXeXeKhach.SoChuyen;
            return count;
        }

        public void PrintNhanVienVanPhong() {
            Console.WriteLine("Danh sach nhan vien van phong: ");
            foreach (var nv in _nhanViens)
            {
                if (nv is NhanVienVanPhong nhanVienVanPhong)
                {
                    Console.WriteLine(nhanVienVanPhong.ToString());
                }
            }
        }

        public void SortAscByHoTenAndDesBySalary() {
            _nhanViens = _nhanViens.OrderBy(nv => nv.HoTen).ThenByDescending(nv => nv.TinhLuong()).ToList();
            Console.WriteLine("Danh sach nhan vien sap xep tang dan theo ho ten va giam dan theo luong: ");
            HienThi();
        }

        private NhanVien? FindNhanVienByMa(string X) {
            foreach (var nv in _nhanViens)
            {
                if (nv.MaNhanVien.Equals(X))
                    return nv;
            }
            return null;
        }
        public void GetNhanVienByMa(string maNV) {
            NhanVien? nv = FindNhanVienByMa(maNV);
            System.Console.WriteLine($"Thong tin nhan vien co ma {maNV}:");
            if (nv != null)
                Console.WriteLine(nv.ToString());
            else
                Console.WriteLine("Nhan vien moi");
        }
    }
}