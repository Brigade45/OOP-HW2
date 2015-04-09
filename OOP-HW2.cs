using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13253056HW2
{
    public class İslemler
    {
        public static int x = 0;
        public static int y = 0;
        public static int komutyolla;
        public static string komutal;
        public static int[,] boyananlaritut = new int[20, 20];
        public static int aracyon = 1001;  // mod 4 e göre sağ 1 aşağı 2 sol 3 yukarı 0
        public static int firca = 2; // yukarı 2 aşağı 1
        public static void menu()
        {
            Console.WriteLine("1 - Fırça aşağı");
            Console.WriteLine("2 - Fırça yukarı");
            Console.WriteLine("3 - Sağa dön");
            Console.WriteLine("4 - Sola dön");
            Console.WriteLine("5_x - x kadar ilerle");
            Console.WriteLine("6 - Diziyi goruntule");
            Console.WriteLine("0 - Programı sonlandır");
            Console.WriteLine("Komutlar arasında virgul kullaniniz.");
            Console.Write("Lutfen komutunuzu giriniz:");
            komutal = Console.ReadLine();
            for (int i = 0; i < komutal.Length; i++)
            {
                if (komutal[i] == 44)
                {
                    continue;
                }
                else if (komutal[i] == 48)
                {
                    Environment.Exit(0);        // 0 'ın ascii değerini gördüğünde programdan çıkış yapıyor.
                }
                else if (komutal[i] == 49)
                {
                    fircaasagi();           // 1'in ascii değerini gördüğünde fircayi asagi indiren metoda gidiyor.
                }
                else if (komutal[i] == 50)
                {
                    fircayukari();          // 2 'ın ascii değerini gördüğünde fircayi yukarı kaldıran metoda gidiyor.
                }
                else if (komutal[i] == 51)
                {
                    sagadon();          // 3 'ın ascii değerini gördüğünde sagadon metodu.
                }
                else if (komutal[i] == 52)
                {
                    soladon();          // 4'ın ascii değerini gördüğünde soladon metodu
                }
                else if (komutal[i] == 53)  // 5'ın ascii değerini gördüğünde  ilerle metodunu gidiyor.
                {
                    for (; ; )
                    {
                        if (komutal[i + 1] == 95)  // _ gordugunda i yi 1 arttırıyor.
                        {
                            i++;
                        }
                        else
                        {
                            i++;                // komutal[i+1] != 95 ise i yi 1 arttirip donguyu bitiriyor.
                            break;
                        }
                    }

                    if (komutal[i + 1] == 44) // virgülü görene kadar işlem devam ediyor.0-9 arasında ilerleme yapması için gereken kontrol.
                    {
                        int yon = aracyon % 4;                       // A
                        komutyolla = Convert.ToInt32(komutal[i]);    // S
                        komutyolla = komutyolla - 48;                // C            TO       Integer
                        ilerle(komutyolla, yon);                     // I
                        i = i + 1;                                   // I
                    }
                    else if (komutal[i + 2] == 44) // virgülü görene kadar işlem devam ediyor.2 basamaktan büyük olan sayılar için gereken kontrol.örneğin 145 yazdı . 
                    {                    // dizi 20 lik boyutta olduğu için 14 ü alıp 5 i önemsiz görüyor.
                        int yon = aracyon % 4;
                        int temp = 0;
                        komutyolla = Convert.ToInt32(komutal[i]);
                        komutyolla = 10 * (komutyolla - 48);
                        temp = komutyolla;
                        komutyolla = Convert.ToInt32(komutal[i + 1]);
                        komutyolla = komutyolla - 48 + temp;
                        ilerle(komutyolla, yon);
                        i = i + 2;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (komutal[i] == 54)    // 6 'ın ascii değerini gördüğünde diziyigoruntule metoduna gidiyor.  
                {
                    diziyigoruntule();
                }
            }
            Console.ReadKey();
        }
        public static void fircaasagi()
        {
            firca = 1;
            boyananlaritut[x, y] = 1;
        }
        public static void fircayukari()
        {
            firca = 2;
        }
        public static void sagadon()
        {
            aracyon = aracyon + 1;
        }
        public static void soladon()
        {
            aracyon = aracyon - 1;
        }
        public static void ilerle(int ileri, int yon)
        {
            for (int i = 0; i < ileri; i++)
            {
                if (firca == 1)
                {
                    if (yon == 0 && x != 0)
                    {
                        boyananlaritut[--x, y] = 1;
                    }
                    else if (yon == 1 && y != 19)
                    {
                        boyananlaritut[x, ++y] = 1;
                    }
                    else if (yon == 2 && x != 19)
                    {
                        boyananlaritut[++x, y] = 1;
                    }
                    else if (yon == 3 && y != 0)
                    {
                        boyananlaritut[x, --y] = 1;
                    }
                }
                else if (firca == 2)
                {
                    if (yon == 0 && x != 0)
                    {
                        boyananlaritut[--x, y] = 0;
                    }
                    else if (yon == 1 && y != 19)
                    {
                        boyananlaritut[x, ++y] = 0;
                    }
                    else if (yon == 2 && x != 19)
                    {
                        boyananlaritut[++x, y] = 0;
                    }
                    else if (yon == 3 && y != 0)
                    {
                        boyananlaritut[x, --y] = 0;
                    }
                }
            }

        }
        public static void diziyigoruntule()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (boyananlaritut[i, j] == 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
