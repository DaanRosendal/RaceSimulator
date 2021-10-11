using System;
using System.Linq;
using Controller;
using Model;
using NUnit.Framework;

namespace ControllerTest
{
    public class Controller_Race_CheckIfParticipantsOnFinish
    {
        [SetUp]
        public void SetUp()
        {
            Data.Initialize();
        }

        [Test]
        public void Should_Up_Driven_Laps_When_Participants_On_Finish()
        {
            
            var mockDriver = new Driver("mockDriver", 
                new Car(Qualities.Average, Performances.Normal), 
                TeamColors.Blue, "9"); 
            var mockDriver2 = new Driver("mockDriver", 
                new Car(Qualities.Average, Performances.Normal), 
                TeamColors.Blue, "9");
            
            Assert.AreEqual(0 ,mockDriver.DrivenLaps);
            Assert.AreEqual(0 ,mockDriver2.DrivenLaps);
            
            foreach (var section in Data.CurrentRace.Track.Sections
                .Where(section => section.SectionType == SectionType.Finish))
            {
                section.SectionData.LeftParticipant = mockDriver;
                section.SectionData.RightParticipant = mockDriver2;
            }
            
            Data.CurrentRace.CheckIfParticipantsOnFinish();

            Assert.AreEqual(1 ,mockDriver.DrivenLaps);
            Assert.AreEqual(1 ,mockDriver2.DrivenLaps);
        }
        
        [Test]
        public void Should_Remove_Participants_When_Participants_On_Finish_When_Driven_All_Laps()
        {
            
            var mockDriver = new Driver("mockDriver", 
                new Car(Qualities.Average, Performances.Normal), 
                TeamColors.Blue, "9"); 
            var mockDriver2 = new Driver("mockDriver", 
                new Car(Qualities.Average, Performances.Normal), 
                TeamColors.Blue, "9");
            
            Assert.AreEqual(0 ,mockDriver.DrivenLaps);
            Assert.AreEqual(0 ,mockDriver2.DrivenLaps);
            
            foreach (var section in Data.CurrentRace.Track.Sections
                .Where(section => section.SectionType == SectionType.Finish))
            {
                section.SectionData.LeftParticipant = mockDriver;
                section.SectionData.RightParticipant = mockDriver2;
            }
            
            mockDriver.DrivenLaps = 10000;
            mockDriver2.DrivenLaps = 10000;
            
            Data.CurrentRace.CheckIfParticipantsOnFinish();

            foreach (var section in Data.CurrentRace.Track.Sections)
            {
                Assert.AreNotEqual(section.SectionData.LeftParticipant, mockDriver);
                Assert.AreNotEqual(section.SectionData.RightParticipant, mockDriver2);
            }
        }
    }
}