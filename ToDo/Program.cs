namespace ToDo
{
    internal class Program
    {
        static string ad;

        static void Secenekler()
        {
            List<string> secenekler = new List<string>();

            foreach (string secenek in secenekler)
            {
                Console.WriteLine(secenek);
            }

            Console.WriteLine("ToDo Uygulamasına Hoşgeldiniz :) ");
            Console.WriteLine($"İsminizi giriniz: ");
            string ad = Console.ReadLine();

            Console.WriteLine($"Hoşgeldin {ad}!");

            Console.WriteLine("1- Yeni Ekle");
            Console.WriteLine("2- Girilenleri Listele");
            Console.WriteLine("3- Girilenleri Sil");


            Console.WriteLine("Cevabınız : ");
            int cevap = int.Parse(Console.ReadLine());

            if(cevap == 1)
            {
                Console.WriteLine("Eklemek istediğiniz notu giriniz: ");
                Console.ReadLine();
                Console.WriteLine("İşleminiz başarıyla gerçekleşti !");
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            Secenekler();

        }
    }
}
