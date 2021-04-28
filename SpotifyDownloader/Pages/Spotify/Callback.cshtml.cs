using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace SpotifyDownloader.Pages.Spotify
{
    public class CallbackModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public CallbackModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostDownloadPlaylistAsync(string LinkPlaylist)
        {
            if (!LinkPlaylist.Contains("playlist"))
            {
                return NotFound();
            }
            await Comunication.Spotify.GetPlaylistItemsAsync(Utils.Link.GetPlaylistId(LinkPlaylist));
            return null;
        }
    }
}
