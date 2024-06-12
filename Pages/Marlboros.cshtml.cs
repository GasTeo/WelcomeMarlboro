using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestAppWeb.Model;
using TestAppWeb.Repository;

namespace TestAppWeb.Pages
{
    public class MarlborosModel : PageModel
    {
        public MarlborosModel(IMarlboro userRepository)
        {
            _marlboroRepository = userRepository;
        }
        private IMarlboro _marlboroRepository;
        public List<Marlboro> marlboros { get; set; }
        public IActionResult OnGet()
        {
            marlboros = _marlboroRepository.GetAll();
            return Page();
        }
    }
}