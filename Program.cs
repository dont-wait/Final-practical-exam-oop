using KT_OnTap;

static class Program
{
    static void Main(string[] args)
    {
        ChuyenVC ql = new ChuyenVC();
        ql.DocFile("Data/data.xml"); //Change directory if you use Window OS
        ql.HienThi();
        System.Console.WriteLine();
        System.Console.WriteLine(
                ql.GetInfoEmployeeHasMaxSalary());
        //BUG: System.Console.WriteLine($"Total number of so chuyen xe khach: {ql.GetTotalSoChuyenXeKhach()}");
        ql.PrintNhanVienVanPhong();

        ql.SortAscByHoTenAndDesBySalary();

        ql.GetNhanVienByMa("NV7979");
    }
}