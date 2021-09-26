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
        public void Should_Return_Null_When_Queue_Is_Empty()
        {
            var result = _competition.ChangeToNextTrack();
            Assert.IsNull(result);
        }
        
        [Test] 
        public void Should_Return_Track_When_One_Is_In_Queue()
        {
            var track = AddMockTrackToCompetition();
            var result = _competition.ChangeToNextTrack();
            Assert.AreEqual(track, result);
        }

        [Test]
        public void Should_Remove_Track_From_Queue_When_One_Is_In_Queue()
        {
            var track = AddMockTrackToCompetition();
            var result = _competition.ChangeToNextTrack();
            Assert.AreEqual(track, result);
            result = _competition.ChangeToNextTrack();
            Assert.IsNull(result);

        }

        [Test]
        public void Should_Return_Next_Track_When_Multiple_Tracks_Are_In_Queue()
        {
            var track1 = AddMockTrackToCompetition();
            var track2 = AddMockTrackToCompetition();
            var result1 = _competition.ChangeToNextTrack();
            Assert.AreEqual(result1, track1);
            var result2 = _competition.ChangeToNextTrack();
            Assert.AreEqual(result2, track2);
        }

        public Track AddMockTrackToCompetition()
        {
            Section[] sections = { 
                new Section(Direction.Left,Direction.Right, SectionType.Start), 
                new Section(Direction.Left,Direction.Right, SectionType.Finish)
            };
            var track = new Track("mockTrack", sections);
            _competition.AddTrack(track);
            return track;
        }
    }
}