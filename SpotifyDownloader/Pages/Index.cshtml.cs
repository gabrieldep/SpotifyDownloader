using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpotifyDownloader.Comunication;
using SpotifyDownloader.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyDownloader.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostDownloadPlaylist(string LinkPlaylist)
        {
            if (!LinkPlaylist.Contains("playlist"))
            {
                return NotFound();
            }

            Spotify.DownloadPlaylist(Link.GetPlaylistGuid(LinkPlaylist));
            return null;
        }
    }
}
