using OiBobaLoja.Models;
using OiBobaLoja.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OiBobaLoja.Pages.Shared
{
    public class CreateModel : PageModel
    {
        public SelectList MarcaOptionItems { get; set; }
        public SelectList CategoriaOptionItems { get; set; }
        private IPrintService _service;

        public CreateModel(IPrintService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));

            CategoriaOptionItems = new SelectList(_service.ObterTodasCategorias(),
                                    nameof(Categoria.CategoriaId),
                                    nameof(Categoria.Descricao));

        }

        [BindProperty]
        public Print Print { get; set; }

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }

        public IActionResult OnPost()
        {
            Print.Categorias = _service.ObterTodasCategorias()
                                       .Where(item => CategoriaIds.Contains(item.CategoriaId))
                                       .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // inclusão
            _service.Incluir(Print);

            TempData["TempMensagemSucesso"] = true;

            return RedirectToPage("/Index");
        }
    }
}
