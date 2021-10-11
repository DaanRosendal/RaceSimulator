using Controller;
using NUnit.Framework;

namespace ControllerTest
{
    public class Controller_Race_ParticipantsOnTrack
    {
        [SetUp]
        public void SetUp()
        {
            Data.Initialize();
        }
        
        [Test]
        public void Should_Return_True_When_Participants_On_Track()
        {
            var race = Data.CurrentRace;
            Assert.AreEqual(true, race.ParticipantsOnTrack());
        }
        
        [Test]
        public void Should_Return_False_When_No_Participants_On_Track()
        {
            var race = Data.CurrentRace;
            foreach (var section in Data.CurrentRace.Track.Sections)
            {
                section.SectionData.LeftParticipant = null;
                section.SectionData.RightParticipant = null;
            }
            Assert.AreEqual(false, race.ParticipantsOnTrack());
        }
    }
}