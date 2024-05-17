using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiderTakipUygulamasi
{
    internal class Gider
    {
        public string GiderAdi { get; set; }
        public string GiderTutari { get; set; }
        public DateTime GiderTarihi { get; set; }
        public string Kategori { get; set; }

        List<string> kategoriler = new List<string>();
        List<Gider> giderler = new List<Gider>();

        public void MenuGoster()
        {
            Console.Clear();
            Console.WriteLine("Gider Uygulamasına Hoş Geldiniz!");
            
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1 - Gider Ekle");
            Console.WriteLine("2 - Eski Tarihli Gider Ekle");
            Console.WriteLine("3 - Raporlar");
            Console.WriteLine("4 - Kategori Yönetimi");
            Console.WriteLine("0 - Çıkış");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    GiderEkle();
                    break;
                case "2":
                    EskiTarihliGiderEkle();
                    break;
                case "3":
                    Raporlar();
                    break;
                case "4":
                    KategoriYonetimi();
                    break;
                case "0":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                    break;
            }
        MenuyeDon();
        }
        public void GiderEkle()
        {
            Console.Write("Gider Adı:");
            string giderAdi = Console.ReadLine();

            Console.Write("Gider Tutarı:");
            string giderTutari = Console.ReadLine();

            Console.Write("Kategori:");
            string kategori = Console.ReadLine();

            DateTime giderTarihi = DateTime.Now;

            Gider yeniGider = new Gider();
            yeniGider.GiderAdi = giderAdi;
            yeniGider.GiderTutari = giderTutari;
            yeniGider.GiderTarihi = giderTarihi;
            yeniGider.Kategori = kategori;

            giderler.Add(yeniGider);

            Console.WriteLine("Gider başarıyla eklendi!");
        }
        public void EskiTarihliGiderEkle()
        {
            Console.Clear();
            Console.WriteLine("Eski tarihli gider eklemek için lütfen ay ve günü girin.");

            int ay = 0;
            int gun = 0;

            bool ayGecerli = false, gunGecerli = false;

            while (!ayGecerli || !gunGecerli)
            {
                Console.Write("Ayı girin (örneğin 1-12 arası): ");
                ayGecerli = int.TryParse(Console.ReadLine(), out ay) && ay >= 1 && ay <= 12;

                Console.Write("Günü girin (örneğin 1-31 arası): ");
                gunGecerli = int.TryParse(Console.ReadLine(), out gun) && gun >= 1 && gun <= 31;

                if (!ayGecerli || !gunGecerli)
                {
                    Console.WriteLine("Geçersiz ay veya gün girdiniz!");
                }
            }

            DateTime eskiTarih = new DateTime(DateTime.Now.Year, ay, gun);
            Console.Clear();
            Console.Write("Eklenecek giderin adını yazınız: ");
            string giderAd = Console.ReadLine();

            Console.Write("Eklenecek gider Tutarını Yazınız: ");
            string giderTutar = Console.ReadLine();

            Gider gider = new Gider();
            gider.GiderTutari = giderTutar;
            gider.GiderAdi = giderAd;
            gider.GiderTarihi = eskiTarih;
            giderler.Add(gider);

            Console.WriteLine($"\nGideriniz {ay}.Ayın {gun} sinde eklendi...");

            MenuyeDon();
        }
        public void Raporlar()
        {
            Console.Clear();
            Console.WriteLine("RAPORLAR");
            decimal toplamHarcama = 0;
            foreach(var gider in giderler)
            {  
                Console.WriteLine($"{gider.GiderAdi} - {gider.GiderTutari} - {gider.GiderTarihi.ToString("M")} - {gider.Kategori}");
                Console.WriteLine("-------------------");
                if (decimal.TryParse(gider.GiderTutari, out decimal tutar))
                {
                    toplamHarcama += tutar;
                }
            }
            Console.WriteLine($"Toplam: {toplamHarcama}");
            MenuyeDon();
        }
        public void KategoriYonetimi()
        {
            Console.WriteLine("Kategori Yönetimi:");
            Console.WriteLine("1 - Kategori Ekle");
            Console.WriteLine("2 - Kategori Sil");
            Console.WriteLine("3 - Kategorileri Listele");
            Console.WriteLine("0 - Geri");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    KategoriEkle();
                    break;
                case "2":
                    KategoriSil();
                    break;
                case "3":
                    KategorileriListele();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                    break;
            }
            MenuyeDon();
        }
        public void KategoriEkle()
        {
            Console.WriteLine("Eklemek istediğiniz kategori adını girin:");
            string kategoriAdi = Console.ReadLine();

            kategoriler.Add(kategoriAdi); // Kategori listesine yeni kategoriyi ekleme

            Console.WriteLine("Kategori başarıyla eklendi!");
        }
        public void KategoriSil()
        {
            Console.WriteLine("Silmek istediğiniz kategori adını girin:");
            string kategoriAdi = Console.ReadLine();

            if (kategoriler.Contains(kategoriAdi))
            {
                kategoriler.Remove(kategoriAdi); // Kategori listesinden belirtilen kategoriyi silme
                Console.WriteLine("Kategori başarıyla silindi!");
            }
            else
            {
                Console.WriteLine("Belirtilen kategori bulunamadı!");
            }
        }
        public void KategorileriListele()
        {
            Console.WriteLine("Mevcut Kategoriler:");
            foreach (var kategori in kategoriler)
            {
                Console.WriteLine(kategori);
            }
        }
        public void MenuyeDon()
        {
            Console.WriteLine("\nAna menüye dönmek için bir tuşa basın");
            Console.ReadKey(true);
            MenuGoster();
        }

        static void TxtKaydet()
        {
            using StreamWriter writer = new StreamWriter("giderler.txt");
            List<Gider> giderler = new List<Gider>();
            foreach (var gider in giderler)
            {
                writer.WriteLine($"{gider.GiderAdi} | {gider.GiderTutari} | {gider.GiderTarihi.ToString("dd/MM/yyyy")} {gider.Kategori}");
            }
        }
        public void VerileriYukle()
        {
            using (StreamReader reader = new StreamReader("giderler.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string satir = reader.ReadLine();
                }
            }
        }
    }
}
