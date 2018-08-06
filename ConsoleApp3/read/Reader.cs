using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.read
{
    abstract class Reader
    {     
        abstract public List<ArtistAlbum> Read(string artist);
    }
}
