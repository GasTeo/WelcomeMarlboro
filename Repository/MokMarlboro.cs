using TestAppWeb.Model;

namespace TestAppWeb.Repository
{
    public class MokMarlboro : IMarlboro
    {
        public MokMarlboro()
        {
            _list ??= new List<Marlboro>();
            _list.Add(new() { Id = 1, Color = "Red", Taste = "Standard", Strong = "0.8/10 mg", Resin = "8 mg" });
            _list.Add(new() { Id = 2, Color = "Blue", Taste = "Sweet", Strong = "0.2/3 mg", Resin = "6 mg" });
            _list.Add(new() { Id = 3, Color = "Gold", Taste = "Soft", Strong = "0.5/6 mg", Resin = "6 mg" });
        }
        Marlboro IMarlboro.Add(Marlboro marlboro)
        {
            _list.Add(marlboro);
            return(marlboro);
        }
        Marlboro IMarlboro.Get(int Id)
        {
            return _list.Where(n => n.Id == Id).ToList().First(); 
        }
        public Marlboro Update(Marlboro marlboro)
        {
            var marlboroDB = _list.Where(n => n.Id == marlboro.Id).ToList().First();
            if (marlboroDB != null)
            { 
                 _list.Remove(marlboroDB);
            }
            _list.Add(marlboro);   
            return(marlboro);
            
            
        }
        List<Marlboro> IMarlboro.GetAll()
        {
            return _list;
        }
       public Marlboro Delete(int Id)
        {
            var marlboroDB = _list.Where(n => n.Id == Id).ToList().First();
            if (marlboroDB != null)
            {
                _list.Remove(marlboroDB);
            }
            _list.Add(marlboroDB);
            return (marlboroDB);
        }

        private List<Marlboro> _list;

    }
}
