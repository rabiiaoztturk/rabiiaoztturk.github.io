namespace YetkiKontrolOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kullanıcı adınızı giriniz:");
            string kullaniciAdi = Console.ReadLine();

            Console.WriteLine("Şifrenizi giriniz");
            string sifre = Console.ReadLine();

            string guvenlik1 = "rabiiaoztturkk";
            string guvenlik2 = "13579";

            if (kullaniciAdi == guvenlik1 && sifre == guvenlik2) 
            {
                Console.WriteLine("Hoşgeldiniz :)");
            }
            else
            {
                Console.WriteLine("Yanlış kullanıcı adı veya şifre !");
            }



        }
    }
}
