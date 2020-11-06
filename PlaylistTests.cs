using NUnit.Framework;
using Drummers_metronome_Windows;

namespace NUnitTest_Drummers_metronome_Windows
{

    class PlaylistTests
    {
        int id = 1;
        int playListId = 1;
        int ordinalPosition = 1;
        string title = "Test Title";
        int countIn = 4;
        int beatsPerMeasure = 4;
        int tempo = 130;
        string songFileURL = "songfileurl";
        string backingTracksURL = "backingurl";
        string chartURL = "charturl";
        string notes = "notes";
        

        private PlaylistEntry Instantiate()
        {

            return new PlaylistEntry()
            {
                Id = id,
                PlayListId = playListId,
                OrdinalPosition = ordinalPosition,
                Title = title,
                CountIn = countIn,
                BeatsPerMeasure = beatsPerMeasure,
                Tempo = tempo,
                SongFileURL = songFileURL,
                BackingTracksURL = backingTracksURL,
                ChartURL = chartURL,
                Notes = notes
            };
        }

        [Test]
        public void TestCreate()
        {
            PlayList playlist = new PlayList();
            Assert.Pass();
        }

        [Test]
        public void TestAdd() {

            PlaylistEntry playlistEntry = Instantiate();
            PlayList playlist = new PlayList();

            // Make playlist with 2 songs
            title = "Song 1";
            id = 10;
            ordinalPosition = 1;

            playlist.Songs.Add(Instantiate());

            title = "Song 2";
            id = 3;
            ordinalPosition = 2;
            playlist.Songs.Add(Instantiate());

            Assert.Pass();

        }

        [Test]
        public void TestLoad()
        {
            PlayList playlist = new PlayList();
            playlist.Load("TestList.dat");
            Assert.IsTrue(playlist.Songs.Count == 2);
        }

        [Test]
        public void TestSave()
        {
            PlayList playlist = new PlayList() { 
                Id = 1,
                Name = "Set List 1",
                Description = "Opening list we use every night",
                Group = "Live Sets"
            };

            // Make playlist with 2 songs
            title = "Song 13";
            id = 10;
            ordinalPosition = 1;
            Instantiate();
            playlist.Songs.Add(Instantiate());

            title = "Song 23";
            id = 3;
            ordinalPosition = 2;
            Instantiate();
            playlist.Songs.Add(Instantiate());

            playlist.Save("TestList.dat");

            Assert.Pass();
        }
    }

    class PlaylistEntryTests
    {
        int id = 1;
        int playListId = 1;
        int ordinalPosition = 1;
        string title = "Test Title";
        int countIn = 4;
        int beatsPerMeasure = 4;
        int tempo = 130;
        string songFileURL = "songfileurl";
        string backingTracksURL = "backingurl";
        string chartURL = "charturl";
        string notes = "notes";
        PlaylistEntry playlistEntry;

        private void Instantiate()
        {

            playlistEntry = new PlaylistEntry()
            {
                Id = id,
                PlayListId = playListId,
                OrdinalPosition = ordinalPosition,
                Title = title,
                CountIn = countIn,
                BeatsPerMeasure = beatsPerMeasure,
                Tempo = tempo,
                SongFileURL = songFileURL,
                BackingTracksURL = backingTracksURL,
                ChartURL = chartURL,
                Notes = notes
            };
        }

        [Test]
        public void TestProperties()
        {
            id = 1;
            playListId = 1;
            ordinalPosition = 1;
            title = "Test Title";
            countIn = 4;
            beatsPerMeasure = 4;
            tempo = 130;
            songFileURL = "songfileurl";
            backingTracksURL = "backingurl";
            chartURL = "charturl";
            notes = "notes";

            Instantiate();

            Assert.IsTrue(
                playlistEntry.Id == id &&
                playlistEntry.PlayListId == playListId &&
                playlistEntry.OrdinalPosition == ordinalPosition &&
                playlistEntry.Title == title &&
                playlistEntry.CountIn == countIn &&
                playlistEntry.BeatsPerMeasure == beatsPerMeasure &&
                playlistEntry.Tempo == tempo &&
                playlistEntry.SongFileURL == songFileURL &&
                playlistEntry.BackingTracksURL == backingTracksURL &&
                playlistEntry.ChartURL == chartURL &&
                playlistEntry.Notes == notes
                );
        }

        [Test]
        public void TestEmptyOptionalValues() {

            // empty songs, charts, notes, and backing tracks are allowed 
            songFileURL = string.Empty;
            backingTracksURL = string.Empty;
            chartURL = string.Empty;
            notes = string.Empty;

            Instantiate();
            Assert.Pass();
        }

        [Test]
        public void TestNegativeId()
        {
            id = -1;
            try
            {
                Assert.Throws<PlaylistEntry.ValueOutOfRangeException>(() => Instantiate());
            } catch { }
            finally { id = 1; }

        }

        [Test]
        public void TestNegativePlaylistId() {

            // playlistid negative causes exception
            playListId = -1;
            try
            {
                Assert.Throws<PlaylistEntry.ValueOutOfRangeException>(() => Instantiate());
            }
            catch { }
            finally { playListId = 1; }
        }

        [Test]
        public void TestNegativePosition() {

            // position negative causes exception
            ordinalPosition = -1;
            playListId = -1;
            try
            {
                Assert.Throws<PlaylistEntry.ValueOutOfRangeException>(() => Instantiate());
            }
            catch { }
            finally { ordinalPosition = 1; }
        }

        [Test]
        public void TestEmptyTitle() {

            // title empty causes exception
            title = string.Empty;
            try
            {
                Assert.Throws<PlaylistEntry.ValueOutOfRangeException>(() => Instantiate());
            }
            catch { }
            finally { title = "Test Title"; }
        }

        [Test]
        public void TestNegativeCountin() {

            // countin negative causes exception
            countIn = -1;
            try
            {
                Assert.Throws<PlaylistEntry.ValueOutOfRangeException>(() => Instantiate());
            }
            catch { }
            finally { countIn = 4; }
        }

        [Test]
        public void TestNegativeBeatsPerMeasure() {

            // beats per measure negative causes exception
            beatsPerMeasure = -1;
            try
            {
                Assert.Throws<PlaylistEntry.ValueOutOfRangeException>(() => Instantiate());
            }
            catch { }
            finally { beatsPerMeasure = 4; }
        }

        [Test]
        public void TestNegativeTempo() {

            // tempo negative causes exception
            tempo = -1;
            try
            {
                Assert.Throws<PlaylistEntry.ValueOutOfRangeException>(() => Instantiate());
            }
            catch { }
            finally { tempo = 130; }
        }

        [Test]
        public void TestTempoGreaterThan300() {

            // tempo greater than 300 causes exception
            tempo = 301;
            try
            {
                Assert.Throws<PlaylistEntry.ValueOutOfRangeException>(() => Instantiate());
            }
            catch { }
            finally { tempo = 130; }
        }

        [Test]
        public void TestEquals()
        {
            Instantiate();
            PlaylistEntry testPle = new PlaylistEntry() { Id = 1 };
            Assert.IsTrue(testPle.Equals(playlistEntry));
            testPle.Id = 2;
            Assert.IsFalse(testPle.Equals(playlistEntry));
        }

        [Test]
        public void TestCompares()
        {
            try
            {
                Instantiate();
                PlaylistEntry testPle = new PlaylistEntry() { OrdinalPosition = 2 };
                Assert.IsTrue(playlistEntry.CompareTo(testPle) == -1);
                testPle.OrdinalPosition = 1;
                Assert.IsTrue(playlistEntry.CompareTo(testPle) == 0);
                playlistEntry.OrdinalPosition = 2;
                Assert.IsTrue(playlistEntry.CompareTo(testPle) == 1);
            }
            finally
            {
                playlistEntry.OrdinalPosition = 1;
            }
        }

        [Test]
        public void TestSimilarity()
        {
            Instantiate();
            PlaylistEntry testPle = new PlaylistEntry()
            {
                Id = id,
                PlayListId = playListId,
                OrdinalPosition = ordinalPosition,
                Title = title,
                CountIn = countIn,
                BeatsPerMeasure = beatsPerMeasure,
                Tempo = tempo,
                SongFileURL = songFileURL,
                BackingTracksURL = backingTracksURL,
                ChartURL = chartURL,
                Notes = notes
            };
            Assert.IsTrue(testPle.PropertiesMatch(playlistEntry));
            testPle.Id = 10;
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.Id = id;
            testPle.PlayListId = 10;
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.PlayListId = playListId;
            testPle.OrdinalPosition = 10;
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.OrdinalPosition = ordinalPosition;
            testPle.Title = "delta title";
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.Title = title;
            testPle.CountIn = 10;
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.CountIn = countIn;
            testPle.BeatsPerMeasure = 10;
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.BeatsPerMeasure = beatsPerMeasure;
            testPle.Tempo = 10;
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.Tempo = tempo;
            testPle.SongFileURL = "delta song url";
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.SongFileURL = songFileURL;
            testPle.BackingTracksURL = "delta backing url";
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.BackingTracksURL = backingTracksURL;
            testPle.ChartURL = "delta chart url";
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.ChartURL = chartURL;
            testPle.Notes = "delta notes";
            Assert.IsFalse(testPle.PropertiesMatch(playlistEntry));
            testPle.Notes = notes;
        }
    }
}
