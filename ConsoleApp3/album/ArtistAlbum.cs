using System;
using System.Runtime.Serialization.Formatters;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace ConsoleApp1
{
    [DataContract]
    class ArtistAlbum
    {
        public ArtistAlbum(string artistName, string collectionName, long collectionId)
        {
            this.artistName = artistName;
            this.collectionName = collectionName;
            this.collectionId = collectionId;
        }

        [DataMember(Name = "artistName", IsRequired = false)]
        public string artistName { set; get; }
        [DataMember(Name = "collectionName", IsRequired = false)]
        public string collectionName { set; get; }
        [DataMember(Name = "collectionId", IsRequired = false)]
        public long collectionId { set; get; }

    }













}

