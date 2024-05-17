namespace hesapMakinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n1 - Toplama (+) \n2 - Çıkarma (-)\n3 - Çarpma (*) \n4 - Bölme (/)");

            Console.WriteLine("Hangi işlemi yapmak istersiniz? :  ");
            int inputislem = int.Parse(Console.ReadLine());

            if (inputislem >= 5)
            {
                Console.WriteLine("Hatalı kodladınız.İşleminiz sonlandırılıyor.");
                Console.ReadLine();
            }

            Console.WriteLine("Kaç adet rakam ile işlem yapmak istersiniz");
            int islem = int.Parse(Console.ReadLine());

            int cevap = 0;

            if (inputislem == 1)
            {
                for (int i = 1; i <= islem; i++)
                {
                    Console.WriteLine(i + ".rakamı giriniz: ");
                    cevap += int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Toplam: " + cevap);
            }
            if (inputislem == 2)
            {
                Console.WriteLine("1.rakamı giriniz: ");
                cevap = int.Parse(Console.ReadLine());

                for (int i = 2; i <= islem; i++)
                {
                    Console.WriteLine(i + ".rakamı giriniz: ");
                    cevap -= int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Sonuç: " + cevap);
            }
            if (inputislem == 3)
            {
                Console.WriteLine("1.rakamı giriniz: ");
                cevap = int.Parse(Console.ReadLine());

                for (int i = 2; i <= islem; i++)
                {
                    Console.WriteLine(i + ".rakamı giriniz");
                    cevap *= int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Sonuç: " + cevap);
            }
            if (inputislem == 4)
            {
                Console.WriteLine("1.rakamı giriniz: ");
                cevap = int.Parse(Console.ReadLine());

                for (int i = 2; i <= islem; i++)
                {
                    Console.WriteLine(i + ". sayıyı giriniz");
                    cevap /= int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Sonuç: " + cevap);
            }









        }
    }
}
