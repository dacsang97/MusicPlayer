using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN292.DTO
{
    class Song
    {
        private int iD;
        private string name;
        private string artist;
        private string thumb;
        private int playlistId;
        private string url;
        private string zid;

        public Song()
        {

        }

        public Song(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
            Artist = row["artist"].ToString();
            Thumb = row["thumb"].ToString();
            PlaylistId = (int)row["playlistID"];
            Url = row["url"].ToString();
            Zid = row["zid"].ToString();
        }

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Artist
        {
            get
            {
                return artist;
            }

            set
            {
                artist = value;
            }
        }

        public string Thumb
        {
            get
            {
                return thumb;
            }

            set
            {
                thumb = value;
            }
        }

        public int PlaylistId
        {
            get
            {
                return playlistId;
            }

            set
            {
                playlistId = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Zid
        {
            get
            {
                return zid;
            }

            set
            {
                zid = value;
            }
        }

    }
}
