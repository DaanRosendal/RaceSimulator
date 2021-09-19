using Model;
using NUnit.Framework;

namespace ControllerTest
{
    public class Model_Competition_AddParticipant
    {
        private Competition _competition;
        
        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }

        [Test]
        public void ShouldAddParticipantToCompetition()
        {
            Car car = new Car(1, 1, 1, 1);
            Driver driver = new Driver("mockParticipant", car, TeamColors.Blue);
            _competition.AddParticipant(driver);
            Assert.AreEqual(driver, _competition.Participants[0]);
        }
    }
}