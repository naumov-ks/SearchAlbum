using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleApp1
{
    [DataContract]
    class ResultSearch
    {
        public ResultSearch()
        {
            artistAlbum = new List<ArtistAlbum>();
        }
        [DataMember(Name = "resultCount", IsRequired = false)]
        public int ResultCount { set; get; }
        [DataMember(Name = "results", IsRequired = false)]
        public List<ArtistAlbum> artistAlbum { set; get; }
    }
}
