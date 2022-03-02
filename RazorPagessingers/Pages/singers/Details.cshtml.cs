#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagessingers.Models;

namespace RazorPagessingers.Pages_singers
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagessingersContext _context;

        public DetailsModel(RazorPagessingersContext context)
        {
            _context = context;
        }

        public singers singers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            singers = await _context.singers.FirstOrDefaultAsync(m => m.ID == id);

            if (singers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
