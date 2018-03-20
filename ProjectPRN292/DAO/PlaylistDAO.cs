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

    }
}
