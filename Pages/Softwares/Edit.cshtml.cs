using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesSoftware.Data;
using RazorPagesSoftware.Models;

namespace RazorPagesSoftware.Pages.Softwares
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesSoftware.Data.RazorPagesSoftwareContext _context;

        public EditModel(RazorPagesSoftware.Data.RazorPagesSoftwareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Software Software { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Software = await _context.Software.FirstOrDefaultAsync(m => m.ID == id);

            if (Software == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Software).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareExists(Software.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SoftwareExists(int id)
        {
            return _context.Software.Any(e => e.ID == id);
        }
    }
}
