using Controller;
using NUnit.Framework;

namespace ControllerTest
{
    public class Controller_Data_NextTrack
    {
        [SetUp]
        public void SetUp()
        {
            Data.Initialize();
        }

        [Test]
        
        public void Should_Go_To_Next_Race()
        {
            var currentRace = Data.CurrentRace;
            Data.NextRace();
            var nextRace = Data.CurrentRace;
            Assert.AreNotEqual(nextRace, currentRace);
        }
    }
}