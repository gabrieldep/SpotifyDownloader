using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
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

        public void OnPost()
        {
            //var request = new LoginRequest(new Uri("https://localhost:44308/spotify/callback"), "7083dbc934a84942ab8b408f000905e9", LoginRequest.ResponseType.Code)
            //{
            //    Scope = new List<string> { Scopes.UserReadEmail }
            //};

            //Uri uri = request.ToUri();
            //BrowserUtil.Open(uri);
        }
    }
}

