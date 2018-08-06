using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.read
{
    class ReaderFromDB : Reader
    {
        private string databaseName = "artisAlbum.db";


        public override List<ArtistAlbum> Read(string artist)
        {
            if (!File.Exists(databaseName))
            {
                return null;
            }
            else
            {
                SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                try
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM album WHERE artistName=@artistname;", connection);
                    command.Parameters.AddWithValue("@artistname", artist);
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return null;
                    }
                    List<ArtistAlbum> albums = new List<ArtistAlbum>();
                    foreach (DbDataRecord record in reader)
                    {
                        albums.Add(new ArtistAlbum((string)record["artistName"], (string)record["collectionName"], (long)record["collectionId"]));
                    }
                    return albums;
                }
                catch (SQLiteException ex)
                {
                    Console.Write(ex.StackTrace);
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}
