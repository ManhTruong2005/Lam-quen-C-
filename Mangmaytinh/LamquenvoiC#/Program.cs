using System;
using System.Collections.Generic;

abstract class KhachHang
{
    public string MaKh { get; set; }
    public string HoTen { get; set; }
    public string DiaChi { get; set; }
    public double SoLuong { get; set; }
    public double DonGia { get; set; }

    public abstract double ThanhTien();
}

class KhachHangVietNam : KhachHang
{
    public double DinhMuc { get; set; }

    public override double ThanhTien()
    {
        if (SoLuong <= DinhMuc)
        {
            return SoLuong * DonGia;
        }
        else
        {
            return (DinhMuc * DonGia) + ((SoLuong - DinhMuc) * DonGia * 2.5);
        }
    }
}

class KhachHangNuocNgoai : KhachHang
{
    public string QuocTich { get; set; }

    public override double ThanhTien()
    {
        return SoLuong * DonGia;
    }
}

class DanhSachKhachHang
{
    private List<KhachHang> khachHangList = new List<KhachHang>();

    public void ThemKhachHang(KhachHang khachHang)
    {
        khachHangList.Add(khachHang);
    }

    public double TongSoLuongKhachHangVN()
    {
        double tongSoLuong = 0;
        foreach (var kh in khachHangList)
        {
            if (kh is KhachHangVietNam)
            {
                tongSoLuong += kh.SoLuong;
            }
        }
        return tongSoLuong;
    }

    public double TrungBinhThanhTienKhachHangNN()
    {
        double tongThanhTien = 0;
        int count = 0;

        foreach (var kh in khachHangList)
        {
            if (kh is KhachHangNuocNgoai)
            {
                tongThanhTien += kh.ThanhTien();
                count++;
            }
        }
        return count > 0 ? tongThanhTien / count : 0;
    }

    public void HienThiDanhSach()
    {
        foreach (var kh in khachHangList)
        {
            Console.WriteLine($"Ma: {kh.MaKh}, Ho ten: {kh.HoTen}, Dia chi: {kh.DiaChi}, Thanh tien: {kh.ThanhTien()}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DanhSachKhachHang danhSach = new DanhSachKhachHang();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Them khach hang Viet Nam");
            Console.WriteLine("2. Them khach hang nuoc ngoai");
            Console.WriteLine("3. Hien thi danh sach khach hang");
            Console.WriteLine("4. Tinh tong so lưuong KW tieu thu cua khach hang Viet Nam");
            Console.WriteLine("5. Tinh trung binh thanh tien cua khach hang nuoc ngoai");
            Console.WriteLine("6. Thoat");
            Console.Write("Moi ban chon: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Nhap ma khach hang: ");
                    string maKhVN = Console.ReadLine();
                    Console.Write("Nhap ho ten: ");
                    string hoTenVN = Console.ReadLine();
                    Console.Write("Nhap dia chi: ");
                    string diaChiVN = Console.ReadLine();
                    Console.Write("Nhap so luong KW tieu thu: ");
                    double soLuongVN = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Nhap don gia: ");
                    double donGiaVN = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Nhap dinh muc: ");
                    double dinhMucVN = Convert.ToDouble(Console.ReadLine());

                    danhSach.ThemKhachHang(new KhachHangVietNam
                    {
                        MaKh = maKhVN,
                        HoTen = hoTenVN,
                        DiaChi = diaChiVN,
                        SoLuong = soLuongVN,
                        DonGia = donGiaVN,
                        DinhMuc = dinhMucVN
                    });
                    Console.WriteLine("Them khach hang thanh cong!");
                    break;

                case "2":
                    Console.Write("Nhap ma khach hang: ");
                    string maKhNN = Console.ReadLine();
                    Console.Write("Nhap ho ten: ");
                    string hoTenNN = Console.ReadLine();
                    Console.Write("Nhap dia chi: ");
                    string diaChiNN = Console.ReadLine();
                    Console.Write("Nhap quoc tich: ");
                    string quocTichNN = Console.ReadLine();
                    Console.Write("Nhap so luong KW tieu thu: ");
                    double soLuongNN = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Nhap don gia: ");
                    double donGiaNN = Convert.ToDouble(Console.ReadLine());

                    danhSach.ThemKhachHang(new KhachHangNuocNgoai
                    {
                        MaKh = maKhNN,
                        HoTen = hoTenNN,
                        DiaChi = diaChiNN,
                        QuocTich = quocTichNN,
                        SoLuong = soLuongNN,
                        DonGia = donGiaNN
                    });
                    Console.WriteLine("Them khach hang nuoc ngoai thanh cong!");
                    break;

                case "3":
                    Console.WriteLine("--- Danh sach khach hang ---");
                    danhSach.HienThiDanhSach();
                    break;

                case "4":
                    double tongSoLuongVN = danhSach.TongSoLuongKhachHangVN();
                    Console.WriteLine($"Tong so luong KW tieu thu cua khach hang Viet Nam: {tongSoLuongVN}");
                    break;

                case "5":
                    double trungBinhNN = danhSach.TrungBinhThanhTienKhachHangNN();
                    Console.WriteLine($"Trung binh thanh tien cua khach hang nuoc ngoai: {trungBinhNN}");
                    break;

                case "6":
                    isRunning = false;
                    Console.WriteLine("Da thoat khoi chuong trinh.");
                    break;

                default:
                    Console.WriteLine("Tuy chon khong hop le. Vui long chon lai.");
                    break;
            }
        }
    }
}
