using System.Collections.Generic;
using System.Linq;
using Controller;
using Model;
using NUnit.Framework;

namespace ControllerTest
{
    public class Controller_Visualizer_MoveParticipants
    {
        [SetUp]
        public void SetUp()
        {
            Data.Initialize();
        }

        // [Test]
        // public void Should_Move_Participants()
        // {
        //     var sections = new LinkedList<Section>(Data.CurrentRace.Track.Sections);
        //     var sectionDatas = sections.Select(section => section.SectionData).ToList();
        //     Visualizer.MoveParticipants(Data.CurrentRace.Track);
        //     var sections2 = new LinkedList<Section>(Data.CurrentRace.Track.Sections);
        //     var sectionDatas2 = sections2.Select(section => section.SectionData).ToList();
        //
        //     Assert.AreNotEqual(sectionDatas, sectionDatas2);
        // }
    }
}