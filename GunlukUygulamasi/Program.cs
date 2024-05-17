using System.Collections.Generic;

namespace GunlukUygulamasi
{
    internal class Program
    {
        class Gunluk
        {
            public DateTime KayıtTarihi { get; set; }
            public DateTime GuncellemeTarihi { get; set; }
            public string Kayıt { get; set; }
        }

        static List<Gunluk> gunlukler = new List<Gunluk>();
        static int siradakiKayit = 0;

        static void TxtKaydet()
        {
            using StreamWriter writer = new StreamWriter("gunluk.txt");
            foreach (var item in gunlukler)
            {
                writer.WriteLine($"{item.Kayıt} | {item.KayıtTarihi.ToString("dd/MM/yyyy")}");
            }
        }

        static void GirisYap()
        {
            Console.Clear();
            // Kullanıcı adı ve şifre iste
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("      GÜNLÜK ");
            Console.WriteLine("==================\n");
            Console.ResetColor();

            Console.WriteLine("Giriş yapmak için lütfen kullanıcı adınızı ve şifrenizi girin.\n");
            Console.Write("Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();
            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

            var guvenlik1 = "rabia";
            var guvenlik2 = "123";

            // Kullanıcı doğrulaması yap
            if (kullaniciAdi == guvenlik1 && sifre == guvenlik2)
            {
                MenuGoster(true);
            }
            else
            {
                Console.WriteLine("\nGeçersiz kullanıcı adı veya şifre!\n");
                Console.ReadKey(true);
            }
        }

        static DateTime sonEklenenTarih = DateTime.MinValue;

        static void GunlukEkle()
        {
            Console.Clear();

            if (sonEklenenTarih.Date != DateTime.Now.Date)
            {
                Console.Clear();
                Console.WriteLine("Günlük kaydınızı ekleyin: \n");
                var inputEklenecek = Console.ReadLine();

                Gunluk gunluk = new Gunluk();
                gunluk.KayıtTarihi = DateTime.Now;
                gunluk.Kayıt = inputEklenecek;
                gunluk.GuncellemeTarihi = DateTime.Now;
                gunlukler.Add(gunluk);

                Console.Clear();
                Console.WriteLine("Günlüğünüz başarıyla kaydedildi! ");

                sonEklenenTarih = DateTime.Now.Date;
                TxtKaydet();
            }
            else
            { 
                Console.WriteLine("Bugün zaten bir günlük kaydı girdiniz. Yeni bir kayıt eklemek ister misiniz? (E/H)");
                var cevap = Console.ReadKey().KeyChar;
                if (cevap == 'H' || cevap == 'h')
                {
                    MenuyeDon();
                }
                else if (cevap == 'E' || cevap == 'e')
                {
                    Console.Clear();
                    Console.WriteLine("Günlük kaydınızı ekleyin: ");
                    var inputEklenecekKayit = Console.ReadLine();

                    Gunluk gunluk = new Gunluk();
                    gunluk.KayıtTarihi = DateTime.Now;
                    gunluk.Kayıt = inputEklenecekKayit;
                    gunluk.GuncellemeTarihi = DateTime.Now;
                    gunlukler.Add(gunluk);

                    Console.Clear();
                    Console.WriteLine("Günlüğünüz başarıyla kaydedildi! ");
                    TxtKaydet();
                }    
            }

            MenuyeDon();
        }

        static void VerileriYukle()
        {
            using (StreamReader reader = new StreamReader("gunluk.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string satir = reader.ReadLine();
                }
            }
        }
        static void MenuyeDon()
        {
            Console.WriteLine("\nAna menüye dönmek için bir tuşa basın");
            Console.ReadKey(true);
            MenuGoster();
        }

        static void GunlukleriListele()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("   GÜNLÜKLER ");
            Console.WriteLine("------------------");
            Console.ResetColor();
            Console.WriteLine("");

            if(siradakiKayit<gunlukler.Count)
            {
                var gunluk = gunlukler[siradakiKayit++];
                Console.WriteLine($"{gunluk.KayıtTarihi.ToString("dd/MM/yyyy")}");
                Console.WriteLine("----------");
                Console.WriteLine($"{gunluk.Kayıt} \n");
            }
            else
            {
                siradakiKayit = 0;
                Console.WriteLine("Günlük kaydınız bulunamadı.");
            }

            Console.WriteLine("(A) Anasayfa | (D) Düzenle | (S) Sonraki Kayıt | (X) Sil \n");
            Console.Write("Seçiminiz: ");
            char secim = Console.ReadKey().KeyChar;

            switch (char.ToUpper(secim))
            {
                case 'A':
                    MenuGoster();
                    break;
                case 'D':
                   Duzenle();
                    break;
                case 'S':
                    GunlukleriListele();
                    break;
                case 'X':
                    GunlukleriSil();
                    break;
                default:
                    Console.WriteLine("\nHatalı seçim yaptınız!");
                    MenuyeDon();
                    break;
            }
        }

        static void Duzenle()
        {
            Console.Clear();
            Console.WriteLine("Kayıt numarası giriniz: ");

            if (int.TryParse(Console.ReadLine(), out int kayitNo) && kayitNo > 0 && kayitNo <= gunlukler.Count)
            {
                Console.WriteLine("Düzenlenmiş kaydınızı giriniz: ");
                string duzenlenenKayit = Console.ReadLine();

                var duzenlenenGunluk = gunlukler [kayitNo -1 ];
                duzenlenenGunluk.Kayıt = duzenlenenKayit;
                duzenlenenGunluk.GuncellemeTarihi = DateTime.Now;

                Console.WriteLine("\nKaydınız başarıyla düzenlenmiştir.");
                TxtKaydet();
            }
            MenuyeDon();
        }

        static void GunlukleriSil()
        {
            Console.Clear();
            Console.WriteLine("Silmek istdiğiniz günlüğün kayıt numarasını giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int kayitNo) && kayitNo > 0 && kayitNo <= gunlukler.Count)
            {
                gunlukler.RemoveAt(kayitNo - 1);
                Console.WriteLine("Kayıt başarıyla silindi.");

                TxtKaydet();
                MenuyeDon();
            }
            else
            {
                Console.WriteLine("Geçersiz kayıt numarası girdiniz! ");
            }
            MenuyeDon ();
        }

        static void TümGünlükleriSil()
        {   
            Console.Clear();
            Console.WriteLine("Günlük kayıtlarınızın hepsini silmek istediğinze emin misiniz ?  E/H: ");
            char tumGunlukSil = Console.ReadKey().KeyChar;
            if (tumGunlukSil == 'E' || tumGunlukSil == 'e')
            {
                Console.WriteLine("\nTüm kayıtlarınız silinmiştir. ");
                gunlukler.Clear();
            }
            else
            {
                Console.WriteLine("Silme işleminiz iptal edildi! ");
                MenuyeDon();
            }
        }

        static void MenuGoster(bool ilkAcilisMi = false)
        {
            Console.Clear();

            if (ilkAcilisMi)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("   HOŞ GELDİNİZ");
                Console.WriteLine("==================\n");
                Console.ResetColor();
            }

            Console.WriteLine("* Yapılacak İşlemi Seçin *\n");
            Console.WriteLine("1* Günlükleri Listele");
            Console.WriteLine("2* Günlük Ekle");
            Console.WriteLine("3* Günlük Sil");
            Console.WriteLine("4* Çıkış");

            Console.Write("\nSeçiminiz: ");
            char inputSecim = Console.ReadKey().KeyChar;

            switch (inputSecim)
            {
                case '1':
                    GunlukleriListele();
                    break;
                case '2':
                    GunlukEkle();
                    break;
                case '3':
                    TümGünlükleriSil();
                    break;
                case '4':
                    break;
                default:
                    Console.WriteLine("\nHatalı seçim yaptınız!");
                    MenuyeDon();
                    break;
            }

        }

        static void Main(string[] args)
        {
            GirisYap();
            VerileriYukle();
        }
    }
}
