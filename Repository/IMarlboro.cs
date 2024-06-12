using TestAppWeb.Model;

namespace TestAppWeb.Repository
{
    public interface IMarlboro
    {
        public Marlboro Add(Marlboro marlboro);
        public Marlboro Get(int Id);
        public Marlboro Update(Marlboro marlboro);
        public List<Marlboro> GetAll();
        public Marlboro Delete(int Id);
    }
}
