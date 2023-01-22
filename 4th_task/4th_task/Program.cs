using System;

namespace _4th_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку произвольной длины");
            string str = Console.ReadLine();
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                {
                    str2 += str[i];
                }
            }
            Console.WriteLine(str2);
            Console.ReadKey();
        }
    }
}
