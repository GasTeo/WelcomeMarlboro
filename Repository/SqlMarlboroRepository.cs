using TestAppWeb.Model;
using TestAppWeb.Repository;

namespace WebAppRazorPages.Controller
{
    public class SqlUserRepository : IMarlboro
    {
        private readonly AppDbContext _appDbContext;

        public SqlUserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Marlboro Add(Marlboro marlboro)
        {
           _appDbContext.Cigarett.Add(marlboro);
            _appDbContext.SaveChanges();
            return marlboro;     
        }

        public Marlboro Delete(int Id)
        {
            var marlboroDB = Get(Id);
            if (marlboroDB != null)
            {
                _appDbContext.Cigarett.Remove(marlboroDB);
            }
            return (marlboroDB);
        }

        public Marlboro? Get(int id)
        {
            return _appDbContext.Cigarett.Where(u => u.Id == id).ToList().FirstOrDefault();
        }

        public List<Marlboro> Get()
        {
            return _appDbContext.Cigarett.ToList();
        }

        public List<Marlboro> GetAll()
        {
            return _appDbContext.Cigarett.ToList();
        }

        public Marlboro Update(Marlboro upCigarette)
        {
            if (upCigarette.Id == 0)
            {
                _appDbContext.Cigarett.Add(upCigarette);
            }
            else
            {
                _appDbContext.Cigarett.Update(upCigarette);
            }
            _appDbContext.SaveChanges();
            return upCigarette;
        }
    }
}