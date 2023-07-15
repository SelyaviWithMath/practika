using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace WebApplication2023.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CalculateBMIController : ControllerBase
    {
        public double ConvertHeight(double rost) //конвертирует рост см->м если пользователь вводил сантиметры.
        {
            return (rost / 100);
        }



        public Tuple<double, string> poisk(double height, double massa)
        {
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
            string disc = "";// Описание индекса массы тела

            double I = (massa / Math.Pow(height, 2));

            foreach (KeyValuePair<double, string> mas in obesity)
            {
                if (I <= mas.Key || mas.Key == 40.001)
                {
                    disc = mas.Value;
                    break;
                }
            }
            return new Tuple<double, string>(I, disc);
        }




        [HttpGet("BMImethod/{h}/{m}")]
        
        public IActionResult BMImethod(double h, double m)
        {       
            if (ConvertHeight(h) >= 0.54 && ConvertHeight(h) <= 2.72) //Если пользователь ввел свои данные в см., а не в метрах.(Преобразовываем в нормальный вид)
            {
                
                h = ConvertHeight(h);
                        
            }
            else
            {
                return BadRequest("Данные о вашем росте введены не корректно!");
            }

            


            if (m < 12 || m > 635)
            {
                return BadRequest("Данные о вашем весе введены не корректно! Введите ваш вес в кг.");
            }


            Tuple<double, string> statistic = poisk(h, m);
            var result = new Result(statistic.Item1, statistic.Item2);
            return Ok(result);
            
        }
    }
}