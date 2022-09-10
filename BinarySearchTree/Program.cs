using System;

namespace BinarySearchTreeSteps
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dizi = new int[10] { 7, 5, 1, 8, 3, 6, 0, 9, 4, 2 };

            int sira = 0;
            int root = 0;
            int sol = 0;
            int sag = 0;
            int test = 0;
            int pointer = 0;

            for(int i = 0; i < dizi.Length; i++)
            {
                if (i == 0)
                {
                    root = dizi[i];
                }
                else
                {
                    if (root > dizi[i])
                    {
                        Console.WriteLine(sira +". seviye "+ root +"<<: " + dizi[i]);
                    }

                    if (root < dizi[i])
                    {
                        Console.WriteLine(sira +". seviye >>: " + dizi[i]);
                    }

                    sira++;
                }

               // Console.WriteLine(i + " . Dizi elemani: " + dizi[i]);
            }
        }
    }
}
