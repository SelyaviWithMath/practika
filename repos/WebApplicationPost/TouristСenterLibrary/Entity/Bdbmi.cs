using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BMILibrary.Entity
{
    public class Bdbmi //хранение таблицы БД(взаимодействия с классом)
    {
        
        public int ID { get; set; }
        public string FIO { get; set; }
        public int UserAge { get; set; }
        public double Rost { get; set; }
        public double Ves { get; set; }

        public Bdbmi()
        {

        }
        public Bdbmi(string FIO,int UserAge,double Rost,double Ves)
        {
            this.FIO = FIO;
            this.UserAge = UserAge;
            this.Rost = Rost;
            this.Ves = Ves;
        }
        
    }

}
