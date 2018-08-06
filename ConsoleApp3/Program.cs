using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Data.SQLite;
using System.Data.Common;
using ConsoleApp1.read;
using ConsoleApp1.write;

namespace ConsoleApp1
{

    class Program
    {

        static void Main(string[] args)
        {
            ReaderFromDB readerFromDB = new ReaderFromDB();
            ReaderFromItunes readerItunes = new ReaderFromItunes();
            WriterConsole writerConsole = new WriterConsole();
            WriterDB writerDB = new WriterDB();
            while (true)
            {
                Console.WriteLine("What artist are you looking for?");
                List<ArtistAlbum> albums = null;
                string artist = Console.ReadLine();
                artist = artist.ToUpper();
                albums = readerItunes.Read(artist);
                if (albums == null)
                {
                    albums = readerFromDB.Read(artist);
                    if (albums != null)
                    {
                        writerConsole.Write(albums);
                    }
                    else
                    {
                        Console.WriteLine("Don't found albums.");
                    }
                }
                else
                {
                    writerConsole.Write(albums);
                    writerDB.Write(albums);
                }

            }
        }
    }
}

