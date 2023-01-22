using System;


class Program
{
    static void Main()
    {

        Console.WriteLine("Введите значение a");
        int a = Int32.Parse(Console.ReadLine());

        var z1 = (Math.Sin(2 * a) + Math.Sin(5 * a) - Math.Sin(3 * a)) / (Math.Cos(a) + 1 - 2 * Math.Pow(Math.Sin(2 * a), 2));
        var z2 = 2 * Math.Sin(a);
       
        double v = Math.Round(z1, 3);
        double c = Math.Round(z2, 3);

        Console.WriteLine(v + " " + c);
    }
}
