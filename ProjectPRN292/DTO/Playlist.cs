using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRN292.DTO
{
    class Playlist
    {
        private int id;
        private string name;
        private DateTime createdAt;
        private DateTime updatedAt;

        public Playlist()
        {

        }

        public Playlist(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            CreatedAt = Convert.ToDateTime(row["created_at"]);
            UpdatedAt = Convert.ToDateTime(row["updated_at"]);
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
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

        public DateTime CreatedAt
        {
            get
            {
                return createdAt;
            }

            set
            {
                createdAt = value;
            }
        }

        public DateTime UpdatedAt
        {
            get
            {
                return updatedAt;
            }

            set
            {
                updatedAt = value;
            }
        }

    }
}
