namespace TKMOyunu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oyuncuSkor = 0;
            int bilgisayarSkor = 0;

            while (true)
            {
                Console.Clear();
                string[] hamleler = ["Taş", "Kağıt", "Makas"];

                Console.WriteLine("Oynamak İstediğin Hamleyi Seç");
                Console.WriteLine("Hamleler: Taş, Kağıt veya Makas");
                Console.Write("Hamle: ");

                string oyuncuHamlesi = Console.ReadLine();

                Console.Clear();

                Random rnd = new Random();
                string bilgisayarHamlesi = hamleler[rnd.Next(3)];
                Console.WriteLine("Oyuncu Hamlesi: " + oyuncuHamlesi);
                Console.WriteLine("Bilgisayar Hamlesi: " + bilgisayarHamlesi);
                Console.WriteLine("");
                // Taş - Makas -> Taş
                // Makas - Kağıt -> Makas
                // Kağıt - Taş -> Kağıt

                if (oyuncuHamlesi == bilgisayarHamlesi)
                {
                    Console.WriteLine("Berabere");
                }
                else if (oyuncuHamlesi == hamleler[0] && bilgisayarHamlesi == hamleler[2])
                {
                    Console.WriteLine("Oyuncu Kazandı");
                    oyuncuSkor++;
                }
                else if (oyuncuHamlesi == hamleler[2] && bilgisayarHamlesi == hamleler[1])
                {
                    Console.WriteLine("Oyuncu Kazandı");
                    oyuncuSkor++;
                }
                else if (oyuncuHamlesi == hamleler[1] && bilgisayarHamlesi == hamleler[0])
                {
                    Console.WriteLine("Oyuncu Kazandı");
                    oyuncuSkor++;
                }
                else
                {
                    Console.WriteLine("Bilgisayar Kazandı");
                    bilgisayarSkor++;
                }

                Console.WriteLine("");
                Console.WriteLine($"Oyuncu: {oyuncuSkor}, Bilgisayar: {bilgisayarSkor}");

                Console.WriteLine("");
                Console.WriteLine("Tekrar oynamak için herhangi bir tuşa basın..");
                Console.ReadKey();
            }

        }
    }
}