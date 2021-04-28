using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotifyDownloader.Utils
{
    public static class Link
    {
        internal static string GetPlaylistGuid(string Link)
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
