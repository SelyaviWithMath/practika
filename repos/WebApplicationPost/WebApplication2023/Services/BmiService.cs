using BMILibrary;
using BMILibrary.Entity;
using WebApplicationPost.Repositories;

namespace WebApplicationPost.Services
{
    public class BmiService : IBmiRepository
    {
        private readonly ApplicationContext _context;
        public BmiService(ApplicationContext context)
        {
            _context = context;
        }
        public bool Add(Bdbmi bdbmi)
        {
            try
            {
                _context.Bdbmi.Add(bdbmi);//Добавляем репрозиторий
                _context.SaveChanges();
                return true;
            }catch (Exception ex)//Если будет ошибка добавления
            {
                return false;
            }
        }
    }
}
