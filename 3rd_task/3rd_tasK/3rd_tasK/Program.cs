using System;
using System.IO;

namespace _3rd_tasK
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int[,] array = new int[5, 4];  
                int[] sum_array = new int[array.GetLength(1)];  
                Random r = new Random();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = r.Next(-10, 10);
                        Console.Write(array[i, j] + "\t");
                        sum_array[j] += array[i, j];
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"Сумма элементов каждого столбца:");

                for (int i = 0; i < sum_array.Length; i++)
                {
                    Console.WriteLine($"№{i + 1}:{sum_array[i]}");
                }
                //Запись в файл
                using (StreamWriter st = new StreamWriter(@"C:\Users\Дамир\Desktop\c#_kgeu\3rd_task\3rd_tasK\3rd_tasK\1.txt"))
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            st.Write(array[i, j] + " ");
                        }
                        st.WriteLine();
                    }
                    for (int i = 0; i < sum_array.Length; i++)
                    {
                        st.WriteLine($"№{i + 1}:{sum_array[i]}");
                    }
                }
            }
        }
    }
}