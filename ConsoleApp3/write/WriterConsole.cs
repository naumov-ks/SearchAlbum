using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.write
{
    class WriterConsole : Write
    {
        public void Write(List<ArtistAlbum> albums)
        {
            foreach(ArtistAlbum album in albums)
            {
                Console.WriteLine(album.collectionName);
            }
                
        }
    }
}
