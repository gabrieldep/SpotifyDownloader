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
    public class IndexModel : PageModel
    {
        private readonly SpotifyDownloader.Model.SpotifyDownloaderDbContext _context;

        public IndexModel(SpotifyDownloader.Model.SpotifyDownloaderDbContext context)
        {
            _context = context;
        }

        public IList<Music> Music { get;set; }

        public async Task OnGetAsync()
        {
            Music = await _context.Musics.ToListAsync();
        }
    }
}
