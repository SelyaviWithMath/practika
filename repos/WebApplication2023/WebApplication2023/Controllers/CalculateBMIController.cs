using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace WebApplication2023.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CalculateBMIController : ControllerBase
    {
        public double ConvertHeight(double rost) //������������ ���� ��->� ���� ������������ ������ ����������.
        {
            return (rost / 100);
        }



        public Tuple<double, string> poisk(double height, double massa)
        {
            Dictionary<double, string> obesity = new Dictionary<double, string>()
                {
                    {16 , "���������� ������� ����� ����"},
                    {18.5 , "������������� (�������) ����� ����"},
                    {25 , "�����"},
                    {30 , "���������� ����� ���� (������������)"},
                    {35 , "�������� 1 �������" },
                    {40 , "�������� 2 �������"},
                    {40.001 , "�������� 3 �������"}
                };
            string disc = "";// �������� ������� ����� ����

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
            if (ConvertHeight(h) >= 0.54 && ConvertHeight(h) <= 2.72) //���� ������������ ���� ���� ������ � ��., � �� � ������.(��������������� � ���������� ���)
            {
                
                h = ConvertHeight(h);
                        
            }
            else
            {
                return BadRequest("������ � ����� ����� ������� �� ���������!");
            }

            


            if (m < 12 || m > 635)
            {
                return BadRequest("������ � ����� ���� ������� �� ���������! ������� ��� ��� � ��.");
            }


            Tuple<double, string> statistic = poisk(h, m);
            var result = new Result(statistic.Item1, statistic.Item2);
            return Ok(result);
            
        }
    }
}