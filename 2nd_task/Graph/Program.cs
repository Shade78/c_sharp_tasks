using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {      
        /// <summary>
        /// Рисуем Шапку таблицы
        /// </summary>
        private static void drawGraphHeader()
        {
            Console.WriteLine();
            Console.WriteLine("+---------------+---------------+");
            Console.WriteLine("|     Значение X|    Значение  Y|");
            Console.WriteLine("+---------------+---------------+");
        }

        /// <summary>
        /// Форматирует число, для вывода в ячейку таблицы
        /// </summary>
        /// <param name="num">Число</param>
        /// <returns>Строка, являющаяся ячейкой</returns>
        private static string decimalToTableCell(double num)
        {
            //Превращаем в строку
            string ex = num.ToString("F3");
            //ПОка не дойдём до 15 символов - добавляем пробелы
            while (ex.Length < 15)
                ex = " " + ex;
            return ex;
        }

        /// <summary>
        /// Рисуем таблицу
        /// </summary>
        /// <param name="elems">Массив с точками</param>
        private static void drawTable(double[][] elems)
        {
            int i = 0;
            //Проходимся по строчкам выходного массива
            while (i < elems.Length)
            {
                //На случай лишнего элемента в массиве
                if (elems[i] != null)
                {
                    //Вывходим строку таблицы
                    Console.WriteLine(string.Format("|{0}|{1}|", decimalToTableCell(elems[i][0]), decimalToTableCell(elems[i][1])));
                    //Вывходим строку разделителя
                    Console.WriteLine("+---------------+---------------+");
                }
                //Увеличиваем счётчик
                i++;
            }
        }

        /// <summary>
        /// Рассчитываем значение Y, для отрезка
        /// </summary>
        /// <param name="x">Значение X</param>
        /// <param name="x1">Значение X, для точки начала отрезка</param>
        /// <param name="x2">Значение X, для точки конца отрезка</param>
        /// <param name="y1">Значение Y, для точки начала отрезка</param>
        /// <param name="y2">Значение Y, для точки конца отрезка</param>
        /// <returns>Значение Y, для текущего X</returns>
        private static double calcylateYFromLine(double x, double x1, double y1, double x2, double y2)
        {
            double divVal, ex;
            //Отдельно считаем значение нижней части дроби
            divVal = x2 - x1;
            //Если оно равно нолю - возвращаем 0, т.к. поделить на 0, и получить целое число низзя
            if (divVal == 0)
                ex = 0;
            else
                //Считаем значение Y по формуле
                ex = ((y2 - y1) / divVal) * (x - x1) - y1;

            return ex;
        }

        /// <summary>
        /// Рассчитываем значение Y, для jrhe;yjcnb
        /// </summary>
        /// <param name="R">Радиус окружности</param>
        /// <param name="x">Значение X</param>
        /// <param name="x1">Значение X, для центра окружности</param>
        /// <param name="y1">Значение Y, для центра окружности</param>
        /// <returns>Значение Y, для текущего X</returns>
        private static double calcylateYFromCircle(double x, double x1, double y1, double R)
        {
            double sqrtVal, ex;
            //Отдельно считаем значение из корня
            sqrtVal = Math.Pow(R, 2)- Math.Pow((x - x1), 2);
            //Под корнем не может быть значения меньше 0. Если оно есть ,то возвращаем 0
            if (sqrtVal < 0)
                ex = 0;
            else
                //Считаем значение Y по формуле
                ex = Math.Sqrt(sqrtVal) - y1;

            return ex;
        }

        /// <summary>
        /// Рассчитываем точки графика
        /// </summary>
        /// <param name="d">Шаг вычислений</param>
        /// <param name="x1">Начальная координата X</param>
        /// <param name="x2">Конечная координата X</param>
        private static double[][] calculatePoints(double d, double x1, double x2)
        {
            double[][] ex;
            double x, y;
            int countElems, i;
            //Получаем количество элементов
            countElems = (int)((x2 - x1) / d) + 1;
            //Инициализируем массив, для вывода
            ex = new double[countElems][];
            //Инициализируем индекс
            i = 0;
            //Указываем стартовое значение X
            x = x1;
            //Цикл будет идти до конечного значения X
            while(x <= x2)
            {
                //Первая часть графика
                if (x < 0)
                    //Считаем значение Y по формуле
                    //y = calcylateYFromLine(x, -10, -3, -8, -3);  - график №2
                    y = calcylateYFromLine(x, -10, 3, 0, -3);
                //Вторая часть графика               
                else if ((x >= 0) && (x < 3))
                    //Считаем значение Y по формуле
                    y = calcylateYFromCircle(x, 0, 0, 3);
                //Третья часть графика
                else if ((x >= 3) && (x < 6))
                    //Считаем значение Y по формуле
                    y = calcylateYFromCircle(x, 0, 6, 3);
                //Четвертая часть графика
               else if ((x >= 6) && (x <= 8))
                //Считаем значение Y по формуле
                    y = calcylateYFromLine(x, 0, 6, 0, 8);
                //Для всех иных случаем примем y равным нолю
                else
                    y = 0;

                //Записываем полученные x и y в массив
                ex[i++] = new double[] { x, y };
                //Прибавляем шаг
                x += d;
            }

            return ex;
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        static void Main(string[] args)
        {
            //Объявляем переменные
            double x1, x2, d;
            double[][] arr;

            //Получаем входные параметры
            Console.Write("Введите начальное значение X: ");
            x1 = double.Parse(Console.ReadLine().Replace(',', '.'));
            //Проверка введённого значения
            if ((x1 <= -10) && (x1 >= 8))
                Console.WriteLine("Ошибка: Начальное значение X выходит за рамки графика.");
            else
            {
                Console.Write("Введите финальное значение X: ");
                x2 = double.Parse(Console.ReadLine().Replace(',', '.'));
                //Проверка введённого значения
                if ((x2 > 8) && (x2 < 10))
                    Console.WriteLine("Ошибка: Финальное значение X выходит за рамки графика.");
                else
                {

                    //Если значения некорректны
                    if (x1 >= x2)
                        Console.WriteLine("Ошибка: Значения начала и конца некорректны.");
                    else
                    {
                        Console.Write("Введите значение шага: ");
                        d = double.Parse(Console.ReadLine().Replace('.', ','));
                        //Значение шага некорректно
                        if (d <= 0)
                            Console.WriteLine("Ошибка: Значение шага некорректно.");
                        else
                        {
                            //Если всё ок со значениями - рисуем шапку
                            drawGraphHeader();
                            //Вычисляем значения, по заданным параметрам
                            arr = calculatePoints(d, x1, x2);
                            //Выводим на экран значения
                            drawTable(arr);
                        }
                    }
                }
            }
            //Ждём нажатия на кнопку. для выхода из программы
            Console.ReadKey();
        }
    }
}
