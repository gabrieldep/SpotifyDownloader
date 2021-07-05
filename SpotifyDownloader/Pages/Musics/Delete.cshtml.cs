using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpotifyDownloader.Model;

namespace SpotifyDownloader.Pages.Musics
{
    public class DeleteModel : PageModel
    {
        private readonly SpotifyDownloader.Model.SpotifyDownloaderDbContext _context;

        public DeleteModel(SpotifyDownloader.Model.SpotifyDownloaderDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Music Music { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Music = await _context.Musics.FirstOrDefaultAsync(m => m.Id == id);

            if (Music == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Music = await _context.Musics.FindAsync(id);

            if (Music != null)
            {
                _context.Musics.Remove(Music);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
