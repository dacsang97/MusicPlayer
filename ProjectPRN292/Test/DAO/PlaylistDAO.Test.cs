using NUnit.Framework;
using ProjectPRN292.DAO;
using ProjectPRN292.DTO;

namespace ProjectPRN292.Test.DAO
{
    [TestFixture]
    class PlaylistDAOUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCreatePlaylist()
        {
            int id = PlaylistDAO.Instance.InsertPlaylist("Me1");
            Playlist playlist = PlaylistDAO.Instance.getPlaylist(id);

            Assert.AreEqual(id, playlist.Id);
            Assert.AreEqual("Me1", playlist.Name);
        }

        [Test]
        public void TestUpdatePlaylist()
        {
            PlaylistDAO.Instance.UpdatePlaylist(9, "Muon");
            Playlist playlist = PlaylistDAO.Instance.getPlaylist(9);

            Assert.AreEqual("Muon", playlist.Name);
        }

        [Test]
        public void TestDeletePlaylist()
        {
            PlaylistDAO.Instance.DeletePlaylist(7);
            Playlist playlist = PlaylistDAO.Instance.getPlaylist(7);
            Assert.AreEqual(null, playlist);
        }
    }
}
