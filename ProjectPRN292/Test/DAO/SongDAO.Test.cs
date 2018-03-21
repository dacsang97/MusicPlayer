using NUnit.Framework;
using ProjectPRN292.DAO;
using ProjectPRN292.DTO;

namespace ProjectPRN292.Test.DAO
{
	[TestFixture]
    class SongDAOUnitTest
    {
        int playlistId;
        int newSongId;
        [SetUp]
        public void Setup()
        {
            playlistId = PlaylistDAO.Instance.InsertPlaylist("Me1");
            newSongId = SongDAO.Instance.InsertSong("Giữ Em Đi", "Thùy Chi", "https://zmp3-photo.zadn.vn/thumb/94_94/avatars/2/0/2083eee4295ae84c7ab510340ff11908_1457321630.jpg", playlistId, "http://mp3-mp3-s1.zadn.vn/bcf3817df93910674928/3085510290890103038?authen=exp=1521705852~acl=/bcf3817df93910674928/*~hmac=74f0ed16915fa057e26cc64ff8f37e8c", "ZW6EZDII");
        }

        [Test]
        public void TestCreateSong()
        {
            int id = SongDAO.Instance.InsertSong("Hello", "Hi", "abc", playlistId, "http", "sdjf");
            Song song = SongDAO.Instance.getSong(id);

            Assert.AreEqual("Hello", song.Name);
            Assert.AreEqual("Hi", song.Artist);
            Assert.AreEqual("abc", song.Thumb);
            Assert.AreEqual(playlistId, song.PlaylistId);
            Assert.AreEqual("http", song.Url);
            Assert.AreEqual("sdjf", song.Zid);
        }

        [Test]
        public void TestUpdateSong()
        {
            SongDAO.Instance.UpdateSong(newSongId, "Hello VietNam", "MVP", "happy.png", playlistId, "https", "123");
            Song song = SongDAO.Instance.getSong(newSongId);

            Assert.AreEqual("Hello VietNam", song.Name);
            Assert.AreEqual("MVP", song.Artist);
            Assert.AreEqual("happy.png", song.Thumb);
            Assert.AreEqual(playlistId, song.PlaylistId);
            Assert.AreEqual("https", song.Url);
            Assert.AreEqual("123", song.Zid);
        }

        [Test]
        public void TestDeletePlaylist()
        {
            SongDAO.Instance.DeleteSong(newSongId);
            Song song = SongDAO.Instance.getSong(newSongId);
            Assert.AreEqual(null, song);
        }
    }
}
