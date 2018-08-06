using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.write
{
    class WriterDB : Write
    {
        private string databaseName = "artisAlbum.db";

        public void Write(List<ArtistAlbum> albums)
        {
            if (!File.Exists(databaseName))
            {
                SQLiteConnection.CreateFile(databaseName);
                SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
                try
                {
                    SQLiteConnection.CreateFile(databaseName);
                    SQLiteCommand command = new SQLiteCommand("CREATE TABLE album (id INTEGER PRIMARY KEY, collectionId INTEGER , artistName TEXT, collectionName TEXT, CONSTRAINT unique_idAlbum UNIQUE (collectionId));", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.Write(ex.StackTrace);
                    return;
                }
                finally
                {
                    connection.Close();
                }
            }
            SQLiteConnection conWrite = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            try
            {
                conWrite.Open();
                foreach (ArtistAlbum album in albums)
                {
                    try
                    {
                        SQLiteCommand comWrite = new SQLiteCommand("INSERT INTO 'album' ( 'collectionId', 'artistName' ,'collectionName') VALUES (@collectionId,@artistName, @collectionName);", conWrite);
                        comWrite.Parameters.AddWithValue("@collectionId", album.collectionId);
                        comWrite.Parameters.AddWithValue("@artistName", album.artistName.ToUpper());
                        comWrite.Parameters.AddWithValue("@collectionName", album.collectionName);
                        comWrite.ExecuteNonQuery();
                    }
                    catch(SQLiteException ex) { }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Write(ex.StackTrace);
                return ;
            }
            finally
            {
                conWrite.Close();
            }

        }
    }
}
