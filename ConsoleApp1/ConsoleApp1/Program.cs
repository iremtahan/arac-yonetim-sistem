using System;
using System.Collections.Generic;

class Arac
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double Fiyat { get; set; }
    public bool Kiralanabilir { get; set; } 

    public Arac(string marka, string model, double fiyat, bool kiralanabilir)
    {
        Marka = marka;
        Model = model;
        Fiyat = fiyat;
        Kiralanabilir = kiralanabilir;
    }

    public void BilgileriGoster()
    {
        Console.WriteLine($"Marka: {Marka}, Model: {Model}, Fiyat: {Fiyat}, Kiralanabilir: {Kiralanabilir}");
    }
}

class AracYonetimSistemi
{
    List<Arac> araclar = new List<Arac>();

    public void AracEkle(Arac arac)
    {
        araclar.Add(arac);
        Console.WriteLine("Araç başarıyla eklendi.");
    }

    public void AracSil(string marka, string model)
    {
        araclar.RemoveAll(arac => arac.Marka == marka && arac.Model == model);
        Console.WriteLine("Araç başarıyla silindi.");
    }

    public void AracListele()
    {
        foreach (var arac in araclar)
        {
            arac.BilgileriGoster();
        }
    }

    public void AracSat(string marka, string model, int indirimIndex)
    {
        Arac satilanArac = araclar.Find(arac => arac.Marka == marka && arac.Model == model && !arac.Kiralanabilir);

        if (satilanArac != null)
        {
            double[] indirimler = { 0.05, 0.10, 0.15 }; 
            double indirim = satilanArac.Fiyat * indirimler[indirimIndex];
            double satisTutari = satilanArac.Fiyat - indirim;

            Console.WriteLine($"Araç Satıldı. Satış Fiyatı: {satilanArac.Fiyat}, İndirim: {indirim}, Ödenecek Tutar: {satisTutari}");
            araclar.Remove(satilanArac);
        }
        else
        {
            Console.WriteLine("Bu araç satın alınamıyor.");
        }
    }

    public void AracKirala(string marka, string model, int gunSayisi, int indirimIndex)
    {
        Arac kiralananArac = araclar.Find(arac => arac.Marka == marka && arac.Model == model && arac.Kiralanabilir);

        if (kiralananArac != null)
        {
            double[] indirimler = { 0.05, 0.10 }; 
            double gunlukKiralamaFiyati = kiralananArac.Fiyat / 30; 
            double toplamTutar = gunlukKiralamaFiyati * gunSayisi;
            double indirim = toplamTutar * indirimler[indirimIndex];
            double kiralamaTutari = toplamTutar - indirim;

            Console.WriteLine($"Araç Kiralandı. Toplam Tutar: {toplamTutar}, İndirim: {indirim}, Ödenecek Tutar: {kiralamaTutari}");
        }
        else
        {
            Console.WriteLine("Bu araç kiralanamıyor.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        AracYonetimSistemi aracYonetimi = new AracYonetimSistemi();

        aracYonetimi.AracEkle(new Arac("Toyota", "Corolla", 300000, false));
        aracYonetimi.AracEkle(new Arac("Ford", "Transit", 200000, true));   

        Console.WriteLine("Tüm Araçlar:");
        aracYonetimi.AracListele();

        Console.WriteLine("\nAraç Satın Alma:");
        aracYonetimi.AracSat("Toyota", "Corolla", 1); 

        Console.WriteLine("\nAraç Kiralama:");
        aracYonetimi.AracKirala("Ford", "Transit", 10, 0); 

        Console.WriteLine("\nGüncel Araç Listesi:");
        aracYonetimi.AracListele();
    }
}

