using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Shell;

namespace BrowserSampleApp
{
    /// <summary>
    /// Implements Bookmarks related functionality.
    /// </summary>
    static class Bookmarks
    {
        public static void Add(string title, string url)
        {
            // args cheking TODO

            ShellTileData tile = new StandardTileData
            {
                Title = title,
                BackTitle = DateTime.Now.ToShortDateString()
            };

            String tileUri = "/MainPage.xaml?bookmarkUrl=" + url;

            ShellTile.Create(new Uri(tileUri, UriKind.Relative), tile);


        }
    }
}
