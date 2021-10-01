using Controller;
using NUnit.Framework;

namespace ControllerTest
{
    public class Controller_Data_Initialize
    {
        [Test]
        public void Should_Initialize()
        {
            Data.Initialize();
            Assert.AreNotEqual(null, Data.Competition);
            Assert.AreNotEqual(null, Data.Competition.Participants);
            Assert.AreNotEqual(null, Data.Competition.Tracks);
        }
    }
}