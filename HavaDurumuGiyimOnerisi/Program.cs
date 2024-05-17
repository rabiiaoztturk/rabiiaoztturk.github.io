namespace HavaDurumuGiyimOnerisi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hava kaç derece ?");
            int derece = int.Parse(Console.ReadLine());
            Console.Clear();

            if (derece <=20) 
            {
                Console.WriteLine("Hava soğuk. Sana şu kıyafetleri giymeni öneriyorum: ");
                Console.WriteLine("Kalın bir kazak ");
                Console.WriteLine("Pantolon ");
                Console.WriteLine("Çizme");
                Console.ReadLine();
            }
            if (derece <=25)
            {
                Console.WriteLine("Hava ortalama derece. Sana şu kıyafetleri giymeni öneriyorum: ");
                Console.WriteLine("Sweat veya crop üstüne ince bir hırka");
                Console.WriteLine("Pantolon,etek,eşofman vb. ");
                Console.WriteLine("Günlük spor ayakkabılar");
                Console.ReadLine();
            }
            if (derece <= 40)
            {
                Console.WriteLine("Hava çok sıcak. Sana şu kıyafetleri giymeni öneriyorum: ");
                Console.WriteLine("Kısa kollu tişört, crop, body, elbise vb.");
                Console.WriteLine("Şort,etek,vb. ");
                Console.WriteLine("Sandalet, terlik, spor ayakkabı vb.");
                Console.ReadLine();
            }

        }
    }
}
