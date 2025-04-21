namespace KT_OnTap;
using System;
public abstract class NhanVien
{
    protected string _maNhanVien;
    protected string _hoTen;
    protected string _gioiTinh;

    public string MaNhanVien {
        get {return _maNhanVien;}
        set {
            if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new Exception("Mã nhân viên không được để trống");
            _maNhanVien = value;}
    }
    public string HoTen {
        get {return _hoTen;}
        set {
            if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new Exception("Họ tên không được để trống");
            _hoTen = value;
            }
    }

    public string GioiTinh {
        get {return _gioiTinh;}
        set {
            if(value.Equals("Nam") || value.Equals("Nu"))
                _gioiTinh = value;
            else
                throw new Exception("Giới tính không được để trống");
            }
    }


    public NhanVien(string maNhanVien, string hoTen, string gioiTinh)
    {
        MaNhanVien = maNhanVien;
        HoTen = hoTen;
        GioiTinh = gioiTinh;
    }

    public NhanVien()
    {
        MaNhanVien = "";
        HoTen = "";
        GioiTinh = "";
    }

    public override string ToString() => $"ID: {_maNhanVien, -10}|Name:{_hoTen, 30}|Sex: {_gioiTinh, 3}| Salary: {TinhLuong(), 5}|";

    public abstract long TinhLuong();
}
