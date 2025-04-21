using KT_OnTap;

static class Program
{
    static void Main(string[] args)
    {
        ChuyenVC ql = new ChuyenVC();
        ql.DocFile("Data/data.xml");
        ql.HienThi();
    }
}