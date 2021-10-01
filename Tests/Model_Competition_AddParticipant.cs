﻿using Model;
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
        public void Should_Add_Participant_To_Competition()
        {
            var car = new Car(Qualities.Average, Performances.Normal);
            var driver = new Driver("mockParticipant", car, TeamColors.Blue, "1");
            _competition.AddParticipant(driver);
            Assert.AreEqual(driver, _competition.Participants[0]);
        }
    }
}