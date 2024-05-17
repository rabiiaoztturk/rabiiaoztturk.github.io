namespace GunlukTodo
{
    internal class Program
    {
        public class Todo
        {
            public string Gorev { get; set; }
            public bool YapildiMi { get; set; }
            public DateTime SonTarih { get; set; }
        }
        static List<Todo> todolar = new List<Todo>();
        static int siradakiIs = 0;
        static void İslemYap()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("TodoApp'e Hoşgeldiniz");
            Console.ResetColor();

            Console.WriteLine("1 - Yen iş Ekle \n2 - İş Listele\n3 - İş listesini temizle");
            Console.Write("\nİşleminizi Seçiniz: ");
            char secimler = Console.ReadKey().KeyChar;

            switch (secimler)
            {
                case '1':
                    Ekle();
                    break;
                case '2':
                    isListele();
                    break;
                case '3':
                    Temizle();
                    break;
                default:
                    Console.WriteLine("\nböyle bir seçenek yok !!");
                    İslemYap();
                    break;
            }
        }
        static void islemGit()
        {
            Console.WriteLine("\nMenüye dönmek için bir tuşa basın");
            Console.ReadKey(true);
            İslemYap();
        }
        static void isListele()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("   İŞ LİSTESİ");
            Console.WriteLine("-------------------");
            Console.ResetColor();
            if (siradakiIs < todolar.Count)
            {
                var Todo = todolar[siradakiIs++];
                Console.WriteLine($"- {Todo.Gorev} | {Todo.SonTarih.ToString("dd/MM/yyyy")} | {Todo.YapildiMi}\n");
            }
            else
            {
                siradakiIs = 0;
                Console.WriteLine("Kayıt bulunamadı!");
            }
            Console.Write("(S)ıradaki iş | (A)na Menü | (D)üzenle | (X)Sil\n");
            Console.Write("\nİşleminiz: ");
            char islem = Console.ReadKey().KeyChar;

            switch (islem)
            {
                case 'a':
                    İslemYap();
                    break;
                case 's':
                    isListele();
                    break;
                case 'd':
                    isDuzenle();
                    break;
                case 'x':
                    IsTemizle();
                    break;
                default:
                    Console.WriteLine("\nHatalı seçim yaptınız!");
                    islemGit();
                    break;
            }
            islemGit();
        }
        static void IsTemizle()
        {
            Console.Clear();
            Console.Write("Silmek istediğiniz işin numarasını girin: ");
            if (int.TryParse(Console.ReadLine(), out int kayitNo) && kayitNo > 0 && kayitNo <= todolar.Count)
            {
                todolar.RemoveAt(kayitNo - 1);
                Console.WriteLine("Seçilen iş silindi.");
                islemGit();
                TxtKaydet();
            }
            else
            {
                Console.WriteLine("Geçersiz iş numarası!");
            }
            islemGit();
        }
        static void isDuzenle()
        {
            Console.Clear();
            Console.Write("Düzenlemek istediğiniz işin numarasını girin: ");
            if (int.TryParse(Console.ReadLine(), out int kayitNo) && kayitNo > 0 && kayitNo <= todolar.Count)
            {
                Console.Write("İşinizin düzenlenmiş halini yazın: ");
                string duzenlenenKayit = Console.ReadLine();

                var duzenlenenIs = todolar[kayitNo - 1];
                duzenlenenIs.Gorev = duzenlenenKayit;
                duzenlenenIs.SonTarih = DateTime.Now;
                duzenlenenIs.YapildiMi = true;

                Console.WriteLine("\nİşiniz başarıyla düzenlendi.");
                TxtKaydet();
            }
            islemGit();
        }
        static void VerileriYukle()
        {
            using StreamReader reader = new StreamReader("TodoApp.txt");
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }
        }
        static void TxtKaydet()
        {
            using StreamWriter writer = new StreamWriter("TodoApp.txt");
            foreach (var item in todolar)
            {
                writer.WriteLine($"{item.Gorev} | {item.SonTarih.ToString("dd/MM/yyyy")}");
            }
        }
        static void Ekle()
        {
            Console.Clear();
            Console.Write("Eklemek istediğiniz işi giriniz: ");
            string kayit = Console.ReadLine();

            Console.WriteLine("İş başarıyla eklendi.");

            Todo todo = new Todo();
            todo.Gorev = kayit;
            todo.SonTarih = DateTime.Now;
            todo.YapildiMi = false;
            todolar.Add(todo);

            TxtKaydet();
            islemGit();
        }
        static void Temizle()
        {
            Console.Clear();
            Console.Write("Tüm işler silinecek emin misiniz ? E/H: ");
            char silCevap = Console.ReadKey().KeyChar;
            if (silCevap == 'E' || silCevap == 'e')
            {
                Console.Clear();
                Console.WriteLine("Tüm işler silindi.");
                todolar.Clear();
                TxtKaydet();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Silme işlemi iptal edildi.");
                islemGit();
            }
        }
        static void Main(string[] args)
        {
            İslemYap();
        }
    }
}