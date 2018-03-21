using System;
using ProjectPRN292.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectPRN292.DAO
{
    class PlaylistDAO
    {
        private static PlaylistDAO instance;

        private PlaylistDAO() {}
        
        internal static PlaylistDAO Instance
        {
            get
            {
                if (instance == null) instance = new PlaylistDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public List<Playlist> GetAllPlaylist()
        {
            List<Playlist> result = new List<Playlist>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Playlist");
            foreach (DataRow item in data.Rows)
            {
                Playlist playlist = new Playlist(item);
                result.Add(playlist);
            }

            return result;
        }

        public Playlist GetPlaylist(int playlistID)
        {
            string query = @"Select * from Playlist where id = @id ";
            Playlist playlist = null;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { playlistID });
            foreach (DataRow item in data.Rows)
            {
                playlist = new Playlist(item);
            }
            return playlist;
        }

        public int InsertPlaylist(string name)
        {
            string query = @"Insert into Playlist(name, created_at, updated_at)
                output INSERTED.ID
                Values ( @name , GETDATE() , GETDATE() )";
            return DataProvider.Instance.ExecuteScalar(query,
                new object[] { name });
        }

        public void UpdatePlaylist(int playlistID, string name)
        {
            string query = @"Update Playlist Set name = @name , updated_at = GETDATE()
                            Where id = @id ";
            DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { name, playlistID });
        }

        public void DeletePlaylist(int playlistID)
        {
            DataProvider.Instance.ExecuteNonQuery(
                "Delete from Playlist Where id = @id ",
                new object[] { playlistID });
        }

    }
}
