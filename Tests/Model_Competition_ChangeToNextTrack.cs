using Model;
using NUnit.Framework;

namespace ControllerTest
{
    [TestFixture]
    public class Model_Competition_ChangeToNextTrack
    {
        private Competition _competition;

        [SetUp] 
        public void SetUp()
        {
            _competition = new Competition();
        }
        
        [Test] 
        public void ShouldReturnNullWhenQueueIsEmpty()
        {
            var result = _competition.ChangeToNextTrack();
            Assert.IsNull(result);
        }
        
        [Test] 
        public void ShouldReturnTrackWhenOneIsInQueue()
        {
            var track = addMockTrackToCompetition();
            var result = _competition.ChangeToNextTrack();
            Assert.AreEqual(track, result);
        }

        [Test]
        public void ShouldRemoveTrackFromQueueWhenOneIsInQueue()
        {
            var track = addMockTrackToCompetition();
            var result = _competition.ChangeToNextTrack();
            Assert.AreEqual(track, result);
            result = _competition.ChangeToNextTrack();
            Assert.IsNull(result);

        }

        [Test]
        public void ShouldReturnNextTrackWhenMultipleTracksAreInQueue()
        {
            var track1 = addMockTrackToCompetition();
            var track2 = addMockTrackToCompetition();
            var result1 = _competition.ChangeToNextTrack();
            Assert.AreEqual(result1, track1);
            var result2 = _competition.ChangeToNextTrack();
            Assert.AreEqual(result2, track2);
        }

        public Track addMockTrackToCompetition()
        {
            SectionTypes[] sections = { SectionTypes.StartGrid, SectionTypes.Finish};
            var track = new Track("mockTrack", sections);
            _competition.AddTrack(track);
            return track;
        }
    }
}