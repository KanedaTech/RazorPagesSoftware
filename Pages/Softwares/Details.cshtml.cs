using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSoftware.Data;
using RazorPagesSoftware.Models;

namespace RazorPagesSoftware.Pages.Softwares
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesSoftware.Data.RazorPagesSoftwareContext _context;

        public DetailsModel(RazorPagesSoftware.Data.RazorPagesSoftwareContext context)
        {
            _context = context;
        }

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
    }
}
