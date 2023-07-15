using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyMass
{
    public class BodyMass
    {
        Dictionary<int, string> dict = new Dictionary<int, string>(); //База данных клиентов
        Dictionary<double, string> obesity = new Dictionary<double, string>()
        {
            {16 , "Выраженный дефицит массы тела"},
            {18.5 , "Недостаточная (дефицит) масса тела"},
            {25 , "Норма"},
            {30 , "Избыточная масса тела (предожирение)"},
            {35 , "Ожирение 1 степени" },
            {40 , "Ожирение 2 степени"},
            {40.001 , "Ожирение 3 степени"}
        };
        public double ConvertMass(double mas) //конвертирует массу г->кг
        {
            return (mas/1000);
        }

        public double ConvertHeight(double rost) //конвертирует рост см->м
        {
            return (rost/100);
        }

        public void BD()
        {
            //dgfhfg
        }


        public string Index() 
        {
            string testH = "0";
            string testM = "0";
            double h = 0;
            double m = 0;
            string result = "";
            bool value = false; //универсальный булеан, отвечающий за корректность введенных данных
            do
            {
                Console.Write("Введите ваш рост: ");
                try
                {
                    testH = Console.ReadLine();
                    testH = testH.Replace('.', ',');
                    h = Convert.ToDouble(testH);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Error! Ввод:Строка | Ожидалось:Число");
                }
                
                if (h >= 0.54 && h <= 2.72)
                {
                    value = true;
                    Console.WriteLine(h + "м.");

                }
                else if (ConvertHeight(h) >= 0.54 && ConvertHeight(h) <= 2.72)
                {
                    value = true;
                    h = ConvertHeight(h);
                    Console.WriteLine(h + "м.");
                }
                else
                {
                        Console.WriteLine("Данные о вашем росте введены не корректно!");
                }


            } while (!value);
            value = false;
            do
            {   
                Console.Write("Введите ваш вес: ");
                try
                {
                    testM = Console.ReadLine();
                    testM = testM.Replace('.', ',');
                    m = Convert.ToDouble(testM);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Error! Ввод:Строка | Ожидалось:Число");
                }

                if (m >= 12 && m <= 635)
                {
                    value = true;
                    Console.WriteLine(m + "кг");
                } 
                else if (ConvertMass(m) >= 12 && ConvertMass(m) <= 635)
                {
                    value = true;
                    m = ConvertMass(m);
                    Console.WriteLine(m+"кг");
                }
                else
                {
                    Console.WriteLine("Данные о вашем весе введены не корректно!");
                }

            } while (!value);
            value = false;
            double I = (m / Math.Pow(h, 2));
            Console.WriteLine(I);
            do
            {
                foreach (KeyValuePair<double, string> mas in obesity)
                {
                    if (I <= mas.Key || mas.Key == 40.001)
                    {
                        result = mas.Value;
                        value = true;
                        break;
                    }
                    
                }
            } while (!value);
            return result;
        }
 



    }
   public class Program
    {
        public static void Main(string[] args)
        {
            BodyMass BMI = new BodyMass();
            Console.WriteLine(BMI.Index());
            Console.ReadLine();
        }
    }
}
