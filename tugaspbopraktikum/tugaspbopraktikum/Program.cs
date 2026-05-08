using System;
using System.Collections.Generic;

class Produk
{
    public string Nama { get; set; }
    public double Harga { get; set; }

    public Produk(string nama, double harga)
    {
        Nama = nama;
        Harga = harga;
    }

    public virtual void InfoProduk()
    {
        Console.WriteLine($"Nama     : {Nama}");
        Console.WriteLine($"Harga    : Rp {Harga:N0}");
        Console.WriteLine($"Kategori : {Kategori()}");
    }

    public virtual string Kategori()
    {
        return "Produk Umum";
    }
}

class Elektronik : Produk
{
    public int Garansi { get; set; }

    public Elektronik(string nama, double harga, int garansi)
        : base(nama, harga)
    {
        Garansi = garansi;
    }

    public void CekGaransi()
    {
        Console.WriteLine($"Garansi {Nama}: {Garansi} bulan");
    }

    public override string Kategori()
    {
        return "Elektronik";
    }

    public override void InfoProduk()
    {
        base.InfoProduk();
        Console.WriteLine($"Garansi  : {Garansi} bulan");
    }
}

class Makanan : Produk
{
    public DateTime TanggalKadaluarsa { get; set; }

    public Makanan(string nama, double harga, DateTime tanggalKadaluarsa)
        : base(nama, harga)
    {
        TanggalKadaluarsa = tanggalKadaluarsa;
    }

    public void CekKadaluarsa()
    {
        if (TanggalKadaluarsa >= DateTime.Today)
            Console.WriteLine($"{Nama} masih layak dikonsumsi. Kadaluarsa: {TanggalKadaluarsa:dd/MM/yyyy}");
        else
            Console.WriteLine($"{Nama} sudah KADALUARSA sejak {TanggalKadaluarsa:dd/MM/yyyy}!");
    }

    public override string Kategori()
    {
        return "Makanan";
    }

    public override void InfoProduk()
    {
        base.InfoProduk();
        Console.WriteLine($"Kadaluarsa: {TanggalKadaluarsa:dd/MM/yyyy}");
    }
}

class Laptop : Elektronik
{
    public Laptop(string nama, double harga, int garansi)
        : base(nama, harga, garansi) { }

    public void InstallSoftware(string namaSoftware)
    {
        Console.WriteLine($"Menginstall {namaSoftware} di {Nama}...");
        Console.WriteLine("Instalasi selesai!");
    }

    public override string Kategori()
    {
        return "Laptop";
    }
}

class HP : Elektronik
{
    public HP(string nama, double harga, int garansi)
        : base(nama, harga, garansi) { }

    public void Telepon(string nomorTujuan)
    {
        Console.WriteLine($"Menelepon {nomorTujuan} menggunakan {Nama}...");
        Console.WriteLine("Panggilan tersambung!");
    }

    public override string Kategori()
    {
        return "HP";
    }
}

class Snack : Makanan
{
    public Snack(string nama, double harga, DateTime kadaluarsa)
        : base(nama, harga, kadaluarsa) { }

    public void Makan()
    {
        Console.WriteLine($"Sedang makan {Nama}... Yummy!");
    }

    public override string Kategori()
    {
        return "Snack";
    }
}

class Minuman : Makanan
{
    public Minuman(string nama, double harga, DateTime kadaluarsa)
        : base(nama, harga, kadaluarsa) { }

    public void Dinginkan()
    {
        Console.WriteLine($"Mendinginkan {Nama} di kulkas...");
        Console.WriteLine($"{Nama} siap disajikan dingin!");
    }

    public override string Kategori()
    {
        return "Minuman";
    }
}

class Toko
{
    public string NamaToko { get; set; }
    private List<Produk> daftarProduk = new List<Produk>();

    public Toko(string namaToko)
    {
        NamaToko = namaToko;
    }

    public void TambahProduk(Produk produk)
    {
        daftarProduk.Add(produk);
    }

    public void DaftarProduk()
    {
        Console.WriteLine($"\n===== DAFTAR PRODUK TOKO {NamaToko} =====");
        int no = 1;
        foreach (Produk p in daftarProduk)
        {
            Console.WriteLine($"\n[{no++}]");
            p.InfoProduk();
        }
        Console.WriteLine($"\nTotal Produk: {daftarProduk.Count}");
        Console.WriteLine("==========================================");
    }

    public List<Produk> GetDaftarProduk()
    {
        return daftarProduk;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Toko toko = new Toko("valen_kece");

        Laptop l1 = new Laptop("ASUS VivoBook 15", 8500000, 24);
        Laptop l2 = new Laptop("Lenovo IdeaPad Slim 3", 7200000, 24);
        Laptop l3 = new Laptop("Acer Aspire 5", 6800000, 12);
        Laptop l4 = new Laptop("HP Pavilion 14", 9100000, 24);

        HP h1 = new HP("Samsung Galaxy A54", 4200000, 12);
        HP h2 = new HP("Xiaomi Redmi Note 13", 2800000, 12);
        HP h3 = new HP("Oppo A78", 3100000, 12);
        HP h4 = new HP("iPhone 14", 14000000, 12);

        Snack s1 = new Snack("Chitato Original", 15000, new DateTime(2026, 6, 30));
        Snack s2 = new Snack("Lays Rumput Laut", 12000, new DateTime(2026, 3, 15));
        Snack s3 = new Snack("Oreo Vanilla", 8000, new DateTime(2026, 8, 20));

        Minuman m1 = new Minuman("Aqua 600ml", 5000, new DateTime(2027, 1, 1));
        Minuman m2 = new Minuman("Teh Botol Sosro", 7000, new DateTime(2026, 5, 10));
        Minuman m3 = new Minuman("Pocari Sweat", 10000, new DateTime(2026, 9, 25));
        Minuman m4 = new Minuman("Coca Cola 330ml", 8000, new DateTime(2026, 7, 14));

        toko.TambahProduk(l1); toko.TambahProduk(l2);
        toko.TambahProduk(l3); toko.TambahProduk(l4);
        toko.TambahProduk(h1); toko.TambahProduk(h2);
        toko.TambahProduk(h3); toko.TambahProduk(h4);
        toko.TambahProduk(s1); toko.TambahProduk(s2);
        toko.TambahProduk(s3);
        toko.TambahProduk(m1); toko.TambahProduk(m2);
        toko.TambahProduk(m3); toko.TambahProduk(m4);

        toko.DaftarProduk();

        Console.WriteLine("\n===== DEMO POLYMORPHISM =====");
        Console.WriteLine("Memanggil Kategori() pada setiap produk via tipe Produk:");
        foreach (Produk p in toko.GetDaftarProduk())
        {
            Console.WriteLine($"  {p.Nama} => {p.Kategori()}");
        }

        Console.WriteLine("\n[Pertanyaan 1] Kategori() pada Laptop dan Snack:");
        Console.WriteLine($"  l1.Kategori() => {l1.Kategori()}");
        Console.WriteLine($"  s1.Kategori() => {s1.Kategori()}");

        Console.WriteLine("\n[Pertanyaan 5] Variabel bertipe Produk diisi objek HP:");
        Produk produkBaru = new HP("Vivo Y36", 2500000, 12);
        Console.WriteLine($"  Produk p = new HP(Vivo Y36)");
        Console.WriteLine($"  p.Kategori() => {produkBaru.Kategori()}");

        Console.WriteLine("\n[Pertanyaan 2] InstallSoftware() pada Laptop:");
        l1.InstallSoftware("Microsoft Office 2024");

        Console.WriteLine("\n[Pertanyaan 3] InfoProduk() pada Laptop:");
        l1.InfoProduk();

        Console.WriteLine("\n[Pertanyaan 4] Dinginkan() pada Minuman:");
        m1.Dinginkan();

        Console.WriteLine("\n[Telepon()] pada HP:");
        h1.Telepon("081234567890");

        Console.WriteLine("\n[CekGaransi()] pada Elektronik:");
        l1.CekGaransi();
        h1.CekGaransi();

        Console.WriteLine("\n[Makan()] pada Snack:");
        s1.Makan();

        Console.WriteLine("\n[CekKadaluarsa()] pada Makanan:");
        s1.CekKadaluarsa();
        m1.CekKadaluarsa();
    }
}