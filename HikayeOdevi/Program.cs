namespace HikayeOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ada macerasına hoşgeldiniz :)");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ben şu an Dominik Adasındayım. Kaybolmuş durumdayım. Ne yapabilirim ?");
            Console.WriteLine("A) Etrafı gez ve birileri var mı kontrol et  ");
            Console.WriteLine("B) Adada tek başına yaşam kurmaya çalış");
            
            string secim1 = Console.ReadLine();
            Console.Clear();

            if (secim1 == "B" || secim1== "b")
            {
                Console.WriteLine("Etraf çok karanlık ve ıssız. Korkmaya başladım");
                Console.WriteLine("A) Olduğun yere geri dön.");
                Console.WriteLine("B) Etrafta bir ışık göründü, o yöne doğru ilerle");
                string secimgeri = Console.ReadLine();
                Console.Clear();

                if (secimgeri == "A" || secimgeri == "a")
                {
                    Console.WriteLine("Adayı kabileler bastı. Beni rehin aldılar. Kaybettik...");
                    Console.ReadLine();
                }
                if (secimgeri == "B" || secimgeri == "b")
                {
                    Console.WriteLine("Gizemli ışığa doğru ilerlerken, adanın derinliklerinde bir mağara keşfettim");
                    Console.WriteLine("A) Mağarada yaşam kur");
                    Console.WriteLine("B) Mağarayı bırak. Kendine barınak yap");
                    string secimyasam = Console.ReadLine();
                    Console.Clear();

                    if (secimyasam == "A" || secimyasam == "a")
                    {
                        Console.WriteLine("Burayı çok sevdim. Çok sıcak ve güvende hissettiriyor. Buradan ayrılmak istemiyorum");
                    }
                    if (secimyasam == "B" || secimyasam == "b")
                    {
                        Console.WriteLine("Burada barınak için yeterince malzeme bulunuyor. Çok güzel bir barınak inşa ettim");
                    }
                }
            }

            if (secim1 == "A" || secim1 == "a")
            {
                Console.WriteLine("Adayı gezdim. 2 farklı yol gördüm. Hangi taraftan gidiyim ?");
                Console.WriteLine("A) Orman yolu");
                Console.WriteLine("B) Araç Yolu");
                string secimyol = Console.ReadLine();
                Console.Clear();

                if (secimyol == "A" || secimyol == "a")
                {
                    Console.WriteLine("Ormanda hayvanlar saldırdı ve öldün. Kaybetttik...");
                    Console.ReadLine();
                }
                if (secimyol == "B" || secimyol == "b")
                {
                    Console.WriteLine("Bize doğru bir tır geliyor. Ne yapayım ?");
                    Console.WriteLine("A) Otostop çek");
                    Console.WriteLine("B) Hayır binme");
                    string secimson = Console.ReadLine();
                    Console.Clear();

                    if (secimson == "A" || secimson == "a")
                    {
                        Console.WriteLine(" Şoför çok iyi biri çıktı. Evime bıraktı. Kurtulduk...");
                    }
                    if (secimson == "B" || secimson == "b")
                    {
                        Console.WriteLine(" Kaçış yolu ararken kayboldum. Kaybettik...");
                    }
                }
            }





        }
    }
}
