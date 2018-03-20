using NUnit.Framework;
using ProjectPRN292.DAO;
using ProjectPRN292.DTO;

namespace ProjectPRN292.Test.DAO
{
	[TestFixture]
    class SongDAOUnitTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestCreateSong()
        {
            int id = SongDAO.Instance.InsertSong("Hello", "Hi", "abc", 8, "http", "sdjf");
            Song song = SongDAO.Instance.getSong(id);

            Assert.AreEqual("Hello", song.Name);
            Assert.AreEqual("Hi", song.Artist);
            Assert.AreEqual("abc", song.Thumb);
            Assert.AreEqual(8, song.PlaylistId);
            Assert.AreEqual("http", song.Url);
            Assert.AreEqual("sdjf", song.Zid);
        }

        [Test]
        public void TestUpdateSong()
        {
            SongDAO.Instance.UpdateSong(5, "Hello VietNam", "MVP", "happy.png", 8, "https", "123");
            Song song = SongDAO.Instance.getSong(5);

            Assert.AreEqual("Hello VietNam", song.Name);
            Assert.AreEqual("MVP", song.Artist);
            Assert.AreEqual("happy.png", song.Thumb);
            Assert.AreEqual(8, song.PlaylistId);
            Assert.AreEqual("https", song.Url);
            Assert.AreEqual("123", song.Zid);
        }

        [Test]
        public void TestDeletePlaylist()
        {
            SongDAO.Instance.DeleteSong(6);
            Song song = SongDAO.Instance.getSong(6);
            Assert.AreEqual(null, song);
        }
    }
}
