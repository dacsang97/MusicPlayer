using NUnit.Framework;
using ProjectPRN292.DAO;
using ProjectPRN292.DTO;

namespace ProjectPRN292.Test.DAO
{
    [TestFixture]
    class PlaylistDAOUnitTest
    {
        int newId;
        [SetUp]
        public void Setup()
        {
            newId = PlaylistDAO.Instance.InsertPlaylist("Me1");
        }

        [Test]
        public void TestCreatePlaylist()
        {
            int id = PlaylistDAO.Instance.InsertPlaylist("Me1");
            Playlist playlist = PlaylistDAO.Instance.GetPlaylist(id);

            Assert.AreEqual(id, playlist.Id);
            Assert.AreEqual("Me1", playlist.Name);
        }

        [Test]
        public void TestUpdatePlaylist()
        {
            PlaylistDAO.Instance.UpdatePlaylist(newId, "Muon");
            Playlist playlist = PlaylistDAO.Instance.GetPlaylist(newId);
            Assert.AreEqual("Muon", playlist.Name);
        }

        [Test]
        public void TestDeletePlaylist()
        {
            PlaylistDAO.Instance.DeletePlaylist(newId);
            Playlist playlist = PlaylistDAO.Instance.GetPlaylist(newId);
            Assert.AreEqual(null, playlist);
        }
    }
}
