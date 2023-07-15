using BMILibrary.Entity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationPost.Models;
using WebApplicationPost.Repositories;

namespace WebApplicationPost.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CalculateBMIController : ControllerBase
    {
        private readonly IBmiRepository _bimRepository;
        public CalculateBMIController(IBmiRepository bimRepository)
        {
            _bimRepository = bimRepository;
        }
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

        //[HttpGet("BMImethod/{h}/{m}")]
        [HttpPost("BMImethod")]
        public IActionResult BMImethod(BmiModel body) //�������� �� ������ �������
        {

            var bdbmi = new Bdbmi(body.FIO, body.UserAge, body.Rost, body.Ves);
            _bimRepository.Add(bdbmi);



            string disc = "";// �������� ������� ����� ����


            if (body.FIO is null) return BadRequest("Error! ��������� ���");

            if (body.UserAge == null) return BadRequest("Error! ������� �������");
            
            if (ConvertHeight(body.Rost) >= 0.54 && ConvertHeight(body.Rost) <= 2.72) //���� ������������ ���� ���� ������ � ��., � �� � ������.(��������������� � ���������� ���)
            {

                body.Rost = ConvertHeight(body.Rost);
                        
            }
            else
            {
                return BadRequest("������ � ����� ����� ������� �� ���������!");
            }

            


            if (body.Ves < 12 || body.Ves > 635)
            {
                return BadRequest("������ � ����� ���� ������� �� ���������! ������� ��� ��� � ��.");
            }



            Tuple<double, string> statistic = poisk(body.Rost, body.Ves);
            var result = new Result(statistic.Item1, statistic.Item2);
            return Ok(result);
            
        }
    }
}