using System;
using System.Linq;

namespace ConsoleApp
{

    public class ZadanieOne // Первый пункт задания
    {
        public static string One() // Почему бы не добавить static? В функции первого пункта нет фиксированного значения перменных, мы не меняем состояние переменных. 
        {
            int n;
            bool value = false; 
            Console.Write("Введите число N: ");
            do
            {
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    value = true;
                }
                else 
                {
                    Console.WriteLine("Error! Ожидалось натуральное число.");
                    Console.Write("Введите число N: ");
                }
                
            } while (!value);
            string result = string.Join(", ", Enumerable.Range(1, n));
            result += ".\n";
            return result;

        }
    }
    public class ZadanieTwo // Второй пункт задания
    {
        public static string[] ZTwo()
        {
            string[] cube = new string[] { };
            int row; //кол-во рядов
            bool val = false;

            Console.Write("Введите число N: ");
            do
            {
                if (int.TryParse(Console.ReadLine(), out row) && row % 2 != 0 && row > 3)
                {
                    val = true;
                }
                else
                {
                    Console.WriteLine("Error! Ожидалось нечетное число больше 3.");
                    Console.Write("Введите число N: ");
                }

            } while (!val);
            int hole = (row / 2) + 1; //ряд с дыркой (вычисляем один раз, а не в функции)
            for (int col = 1; col <= row; col++) // циклом возвращаем строку
                cube = cube.Append(ZadanieTwo.Two(row, hole, col)).ToArray();
            return cube;
        }
        public static string Two(int r,int h,int c) //в оригинале проверка вызывалась n^2, в этом же случае вызывается 2n раз
        {
            string line = "";
            if (c != h) //если не дошел до нужного ряда
            {
                for (int i = 1; i <= r; i++)
                {
                    line += "#";
                }
            }
            else
            { 
                for (int j = 1; j <= r; j++)
                {
                    if (j != h)
                    {
                        line += "#";
                    }
                    else
                    {
                        line += " ";
                    }
                }
            }
            return line+"\n";

        }
            
    }

    public class Base // Основной класс вызывающий обе задачи
    {
        public static void Main(string[] args)
        {
            Console.Write(ZadanieOne.One());
            foreach (string elem in ZadanieTwo.ZTwo())
            {
                Console.Write(elem);
            }
            Console.ReadLine();
        }
    }
}
