using Controller;
using NUnit.Framework;

namespace ControllerTest
{
    public class Controller_Race_RandomizeEquipment
    {
        [SetUp]
        public void SetUp()
        {
            Data.Initialize();
            Data.NextRace();
        }
        
        [Test]
        public void Should_Randomize_Equipment()
        {

            foreach (var participant in Data.CurrentRace.Participants)
            {
                var currentPerformance = participant.Equipment.Performance;
                var currentQuality = participant.Equipment.Quality;
                Data.CurrentRace.RandomizeEquipment();
                var newPerformance = participant.Equipment.Performance;
                var newQuality = participant.Equipment.Quality;
                Assert.AreNotEqual(currentPerformance, newPerformance);
                Assert.AreNotEqual(currentQuality, newQuality);
            }
        }
    }
}