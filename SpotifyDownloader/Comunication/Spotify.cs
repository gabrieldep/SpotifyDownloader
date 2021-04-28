using Newtonsoft.Json;
using SpotifyDownloader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotifyDownloader.Comunication
{
    public static class Spotify
    {
        internal static async Task<IList<Music>> GetPlaylistItemsAsync(string PlaylistGuid)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://api.spotify.com/v1/playlists/" + PlaylistGuid + "/tracks");

            using (HttpResponseMessage response = await client.GetAsync("api/Documento/EnviarDocumentoParaLaudo"))
            {
                if (response.IsSuccessStatusCode)
                {
                    IList<Music> musicList = JsonConvert.DeserializeObject<IList<Music>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                    return musicList;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
