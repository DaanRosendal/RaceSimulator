using Model;
using NUnit.Framework;

namespace ControllerTest
{
    public class Model_Car_Speed
    {
        private Car _car;
        
        [SetUp]
        public void SetUp()
        {
            _car = new Car(Qualities.Average, Performances.Normal);
        }

        [Test]
        public void Should_Set_Speed()
        {
            Assert.AreEqual(_car.Speed, 2);
        }

        [Test]
        public void Should_Set_Speed_When_Quality_Is_Changed()
        {
            _car.Quality = Qualities.Excellent;
            Assert.AreEqual(_car.Speed, 3);
        }
        
        [Test]
        public void Should_Set_Speed_When_Performance_Is_Changed()
        {
            _car.Quality = Qualities.Garbage;
            _car.Performance = Performances.Shit;
            Assert.AreEqual(_car.Speed, 1);
        }
        
        [Test]
        public void Should_Set_Speed_When_Performance_And_Quality_Are_Changed()
        {
            _car.Quality = Qualities.Excellent;
            _car.Performance = Performances.Outstanding;
            Assert.AreEqual(_car.Speed, 3);
        }
    }
}