using ProjectPRN292.DTO;
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
    }
}
