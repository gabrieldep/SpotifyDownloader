using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpotifyDownloader.Model;

namespace SpotifyDownloader.Pages.Musics
{
    public class CreateModel : PageModel
    {
        private readonly SpotifyDownloader.Model.SpotifyDownloaderDbContext _context;

        public CreateModel(SpotifyDownloader.Model.SpotifyDownloaderDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Music Music { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Musics.Add(Music);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
