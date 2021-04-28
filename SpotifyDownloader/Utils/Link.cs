using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotifyDownloader.Utils
{
    public static class Link
    {
        /// <summary>
        /// Validates and separates playlist_id from the acceptance link.
        /// </summary>
        /// <param name="Link">Playlist link to get playlist_id.</param>
        /// <returns>If link is valid, return the playlist_id, else, return null.</returns>
        internal static string GetPlaylistId(string Link)
        {
            var match = Regex.Match(Link, @"(?s)(?<=playlist/).+?(?=\?si)");
            if (match.Success)
            {
                return match.Groups[0].Value;
            }
            return null;
        }
    }
}
