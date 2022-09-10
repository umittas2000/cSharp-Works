using System;

namespace insertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int  a = 0;
            Console.Write("How many numbers do you want to give ?:");
            a = Convert.ToInt32(Console.ReadLine());

            int[] myArr = new int[a];
            //{ 22, 27, 16, 2, 18, 6 };

            string input="";
           for(int mm = 0;mm<a;mm++)
            {
                Console.Write("Please enter " + (mm+1) + ". Number(s): ");
                input = Console.ReadLine();

                myArr[mm] = Convert.ToInt32(input);
            }

            for(int i = 0; i < myArr.Length; i++)
            {
                int num = myArr[i];
              
                for(int t=i+1;t<myArr.Length;t++)
                {
                    int num2 = myArr[t];

                    if (num > num2)
                    {
                        myArr[i] = num2;
                        myArr[t] = num;
                        i--;
                        break;
                    }

                }

            }

            foreach(int item in myArr)
            {
                Console.WriteLine("Insertion Sort:" + item);
            }
        }
    }
}
