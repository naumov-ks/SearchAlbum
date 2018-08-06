using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.read
{
    class ReaderFromItunes : Reader
    {
        private string url = "https://itunes.apple.com/search?media=music&entity=album&attribute=artistTerm&term=";
        public override List<ArtistAlbum> Read(string artist)
        {
            List<ArtistAlbum> albums = null;
            string answer = ReadFromItunes(artist);
            if (answer != null)
            {
                albums = Parse(answer);
                if (albums != null)
                {
                    albums = CheckResult(albums, artist);
                    if (albums.Count.Equals(0))
                    {
                        return null;
                    }
                }
            }
            return albums;
        }


        private string ReadFromItunes(string artist)
        {
            string answer = null;
            try
            {
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    answer = client.DownloadString(url + artist);
                }
            }
            catch (WebException ex)
            {
                return null;
            }
            return answer;
        }

        private List<ArtistAlbum> Parse(string answer)
        {
            var d = new DataContractJsonSerializer(typeof(ResultSearch));
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(answer));
            var result = (ResultSearch)d.ReadObject(stream);
            if (result.ResultCount.Equals(0))
            {
                return null;
            }
            return result.artistAlbum;
        }

        private List<ArtistAlbum> CheckResult(List<ArtistAlbum> albums, string artist)
        {
            return albums.FindAll(x => x.artistName.ToUpper().Equals(artist));
        }


    }
}
