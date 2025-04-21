namespace KT_OnTap;

public class TaiXeXeKhach : NhanVien, IThuongThem
{
    private long _luongCanBan;
    private int _soChuyen;
    private long _phuCap;

    public TaiXeXeKhach(string maNhanVien, string hoTen, string gioiTinh, long luongCanBan, int soChuyen, long phuCap) : base(maNhanVien, hoTen, gioiTinh)
    {
        _luongCanBan = luongCanBan;
        _soChuyen = soChuyen;
        _phuCap = phuCap;
    }

    public TaiXeXeKhach() {}

    public long LuongCanBan
    {
        get { return _luongCanBan; }
        set { _luongCanBan = value; }
    }
    public int SoChuyen
    {
        get { return _soChuyen; }
        set { _soChuyen = value; }
    }
    public long PhuCap
    {
        get { return _phuCap; }
        set { _phuCap = value; }
    }

    public override long TinhLuong()
    {
        return _luongCanBan + SoChuyen * 600000 + PhuCap + TinhThuongThem();
    }
    public override string ToString()
    {
        return base.ToString() + $"Basic Salary{_luongCanBan, 10}|So Chuyen:{SoChuyen, 5}|Phu cap: {PhuCap, 5}| Luong: {TinhThuongThem(), 5}\n";
    }
    public long TinhThuongThem() => SoChuyen > 10 ? 1000000 : 0;
}
