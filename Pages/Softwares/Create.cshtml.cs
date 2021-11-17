using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesSoftware.Data;
using RazorPagesSoftware.Models;

namespace RazorPagesSoftware.Pages.Softwares
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesSoftware.Data.RazorPagesSoftwareContext _context;

        public CreateModel(RazorPagesSoftware.Data.RazorPagesSoftwareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Software Software { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Software.Add(Software);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
