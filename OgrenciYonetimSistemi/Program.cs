namespace OgrenciYonetimSistemi
{
    internal class Program
    {
        static string Sor(string soru)
        {
            Console.Write(soru);
            return Console.ReadLine();
        }

        class Ogrenci
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Cinsiyet { get; set; }
            public int Numara { get; set; }
            public DateTime DogumTarihi { get; set; }
        }

        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        static Random random = new Random();

        static Ogrenci? OgrenciBul(string arananAd, int arananNumara, string arananCinsiyet)
        {
            Ogrenci? bulunanOgrenci = null;

            foreach (var ogrenci in ogrenciler)
            {
                if (arananAd == ogrenci.Ad || arananNumara == ogrenci.Numara || arananCinsiyet == ogrenci.Cinsiyet ) 
                {
                    bulunanOgrenci = ogrenci;
                    break;
                }
            }
            return bulunanOgrenci;
        }
            static void Main(string[] args)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Öğrenci Yönetim Sistemi");

                    Console.WriteLine("1 - Öğrenci Bul");
                    Console.WriteLine("2 - Öğrenci Ekle");
                    Console.WriteLine("3 - Öğrenci Listele");
                    Console.WriteLine("4 - Öğrenci Düzenle");
                    Console.WriteLine("5 - Öğrenci Kayıt Sil");
                    Console.WriteLine("6 - Çıkış");

                    int inputSecim = int.Parse(Sor("Seçiminiz: "));

                //Öğrenci Bul
                if (inputSecim == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Öğrenci Ara");
                    Console.WriteLine("1 - İsimle Ara");
                    Console.WriteLine("2 - Numarayla Ara");

                    int aramaSecim = int.Parse(Sor("Seçiminiz: "));

                    if (aramaSecim == 1)
                    {
                        string inputArananOgrenci = Sor("Adı: ");
                        Ogrenci? arananOgrenci = OgrenciBul(inputArananOgrenci, -1, "");
                        //sırasına göre eğer int ise -1, string ise "" ekliyoruz.

                        if (arananOgrenci != null)
                        {
                            Console.WriteLine("Öğrenciyi buldum!");
                            Console.WriteLine($"{arananOgrenci.Ad} {arananOgrenci.Soyad} - Numara: {arananOgrenci.Numara}");
                        }
                        else
                        {
                            Console.WriteLine("Böyle bir öğrenci yok!");
                        }
                    }
                    else if (aramaSecim == 2)
                    {
                        int arananNumara = int.Parse(Sor("Numara: "));
                        Ogrenci? arananOgrenci = OgrenciBul("", arananNumara, "");

                        if (arananOgrenci != null)
                        {
                            Console.WriteLine("Öğrenciyi buldum!");
                            Console.WriteLine($"{arananOgrenci.Ad} {arananOgrenci.Soyad} - Numara: {arananOgrenci.Numara}");
                        }
                        else
                        {
                            Console.WriteLine("Böyle bir öğrenci yok!");
                        }
                    }
                }
                //Öğrenci Ekle
                else if (inputSecim == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Öğrenci Ekle");
                    Ogrenci ogrenci = new Ogrenci();
                    ogrenci.Ad = Sor("Ad: ");
                    ogrenci.Soyad = Sor("Soyad: ");
                    ogrenci.Cinsiyet = Sor("Cinsiyet: ");
                    ogrenci.DogumTarihi = DateTime.Parse(Sor("Doğum Tarihi: "));
                    ogrenci.Numara = random.Next(1000, 10000); // 1000 ile 9999 arasında rastgele bir numara atama

                    ogrenciler.Add(ogrenci);
                }
                //Öğrenci Listele
                else if (inputSecim == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Öğrenci Listesi");
                    foreach (Ogrenci ogrenci in ogrenciler)
                    {
                        Console.WriteLine($"{ogrenci.Numara} - {ogrenci.Cinsiyet} - {ogrenci.DogumTarihi.ToShortDateString()} - {ogrenci.Ad} {ogrenci.Soyad}");
                    }
                    Console.WriteLine("\nDevam etmek için bir tuşa basın");
                    Console.ReadKey();
                    Console.WriteLine("Öğrenciyi Filtreleme");
                    int filtre = int.Parse(Sor("1- Ad ile ara; "));
                    int filtre2 = int.Parse(Sor("2 - Cinsiyet ile ara: "));
                    if(inputSecim == 1)
                    {
                        string inputArananOgrenci = Sor(("Öğrenci adını giriniz: "));
                        if(inputArananOgrenci != null)
                        {
                            foreach (Ogrenci ogrenci in ogrenciler)
                            {
                                Console.WriteLine($"{ogrenci.Numara} - {ogrenci.Cinsiyet} - {ogrenci.DogumTarihi.ToShortDateString()} - {ogrenci.Ad} {ogrenci.Soyad}");
                            }
                        }
                    }


                }
                //Öğrenci Düzenle
                else if (inputSecim == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Öğrenci Düzenle");

                    string inputArananOgrenci = Sor("Düzenlemek istediğiniz öğrencinin adı: ");

                    Ogrenci? arananOgrenci = OgrenciBul(inputArananOgrenci, -1, "");

                    if (arananOgrenci != null)
                    {
                        // Öğrencinin mevcut bilgilerini göster
                        Console.WriteLine("Mevcut Bilgiler:");
                        Console.WriteLine($"Ad: {arananOgrenci.Ad}");
                        Console.WriteLine($"Soyad: {arananOgrenci.Soyad}");
                        Console.WriteLine($"Cinsiyet: {arananOgrenci.Cinsiyet}");
                        Console.WriteLine($"Numara: {arananOgrenci.Numara}");
                        Console.WriteLine($"Doğum Tarihi: {arananOgrenci.DogumTarihi.ToString()}");

                        // Hangi bilgiyi değiştirmek istediğini sor
                        Console.WriteLine("\nDeğiştirmek istediğiniz bilgiyi seçin:");
                        Console.WriteLine("1 - Ad");
                        Console.WriteLine("2 - Soyad");
                        Console.WriteLine("3 - Cinsiyet");
                        Console.WriteLine("4 - Numara");
                        Console.WriteLine("5 - Doğum Tarihi");

                        int degisimSecim = int.Parse(Sor("Seçiminiz: "));

                        // İlgili bilgiyi güncelle
                        if (degisimSecim == 1)
                        {
                            arananOgrenci.Ad = Sor("Yeni Ad: ");
                            Console.WriteLine("Öğrenci Adı başarıyla güncellendi.");
                        }
                        else if (degisimSecim == 2)
                        {
                            arananOgrenci.Soyad = Sor("Yeni Soyad: ");
                            Console.WriteLine("Öğrenci Soyadı başarıyla güncellendi.");
                        }
                        else if (degisimSecim == 3)
                        {
                            arananOgrenci.Cinsiyet = Sor("Yeni Cinsiyet: ");
                            Console.WriteLine("Öğrenci Cinsiyeti başarıyla güncellendi.");
                        }
                        else if (degisimSecim == 4)
                        {
                            arananOgrenci.Numara = int.Parse(Sor("Yeni Numara: "));
                            Console.WriteLine("Öğrenci Numarası başarıyla güncellendi.");
                        }
                        else if (degisimSecim == 5)
                        {
                            arananOgrenci.DogumTarihi = DateTime.Parse(Sor("Yeni Doğum Tarihi (yyyy-MM-dd): "));
                            Console.WriteLine("Öğrenci Doğum Tarihi başarıyla güncellendi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz seçim!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Öğrenci bulunamadı.");
                    }

                    Console.WriteLine("\nDevam etmek için bir tuşa basın");
                    Console.ReadKey();
                }
                //Öğrenci Kayıt Sil
                else if (inputSecim == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Silmek istediğiniz öğrencinin numarasını giriniz. (Eğer bilmiyorsanız öğrenci listele kısmını ziyaret edebilirisiniz) ");
                    int arananNumara = int.Parse(Sor("Okul Numarası: "));

                    // Öğrenciyi bul ve silme işlemini gerçekleştir
                    Ogrenci ogrenciSil = ogrenciler.Find(o => o.Numara == arananNumara);
                    if (ogrenciSil != null)
                    {
                        ogrenciler.Remove(ogrenciSil);
                        Console.WriteLine("Öğrenci başarıyla silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Belirtilen numaraya sahip bir öğrenci bulunamadı.");
                    }
                    Console.WriteLine("\nDevam etmek için bir tuşa basın");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Hoşçakalın");
                    break;
                }
                }
            }

        

    }
}
