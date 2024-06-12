using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestAppWeb.Model;
using TestAppWeb.Repository;

namespace TestAppWeb.Pages
{
    [Authorize]
    public class EditCigarettModel : PageModel
    {
        public EditCigarettModel(IMarlboro CigarettRepository)
        {
            _cigarett = CigarettRepository;
        }

        private IMarlboro _cigarett;
        public Marlboro? Cigarette { get; set; }

        public IActionResult OnGet(int id)
        {
            Cigarette = _cigarett.Get(id);
            Cigarette ??= new();
            return Page();
        }

        public IActionResult OnPost(Marlboro? CigarettForm)
        {

            var MarlboroDB = _cigarett.Update(CigarettForm);
            if (MarlboroDB == null) return NotFound();
            return RedirectToPage("Marlboros");
        }
    }
}