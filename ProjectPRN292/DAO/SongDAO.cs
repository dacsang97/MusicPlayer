﻿using ProjectPRN292.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN292.DAO
{
    class SongDAO
    {
        private static SongDAO instance;
        private SongDAO() { }

        internal static SongDAO Instance
        {
            get
            {
                if (instance == null) instance = new SongDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public List<Song> GetAllSong()
        {
            List<Song> result = new List<Song>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Song");
            foreach (DataRow item in data.Rows)
            {
                Song song = new Song(item);
                result.Add(song);
            }

            return result;
        }

        public Song getSong(int songID)
        {
            string query = @"Select * from Song where id = @songID ";
            Song song = null;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { songID });
            foreach(DataRow item in data.Rows)
            {
                song = new Song(item);
            }
            return song;
        }

        public int InsertSong(string name, string artist, string thumb, int playlistID, string url, string zid)
        {
            string query = @"Insert into Song(name, artist, thumb, playlistID, url, zid)
                output INSERTED.ID
                Values ( @name , @artist , @thumb , @playlistID , @url , @zid )";
            return DataProvider.Instance.ExecuteScalar(query, 
                new object[] { name, artist, thumb, playlistID, url, zid });
        }

        public void UpdateSong(int songID, string name, string artist, string thumb, int playlistID, string url, string zid)
        {
            string query = @"Update Song Set name = @name , artist = @artist , thumb = @thumb , 
                        playlistID = @playlistID , url = @url , zid = @zid Where id = @id ";
            DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { name, artist, thumb, playlistID, url, zid, songID });
        }

        public void DeleteSong(int songID)
        {
            DataProvider.Instance.ExecuteNonQuery(
                "Delete from Song Where id = @id ",
                new object[] { songID });
        }
    }
}
