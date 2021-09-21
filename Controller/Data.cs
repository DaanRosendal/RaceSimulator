using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition Competition;
        public static Race CurrentRace;

        public static void Initialize()
        {
            Competition = new Competition();
            AddParticipants();
            AddTracks();
        }

        public static void AddParticipants()
        {
            var driver1 = new Model.Driver("John", new Car(5, 5, 5, 0), TeamColors.Green);
            var driver2 = new Model.Driver("Rick", new Car(7, 7, 7, 0), TeamColors.Blue);
            var driver3 = new Model.Driver("Morty", new Car(5, 5, 5, 0), TeamColors.Yellow);
            Competition.AddParticipant(driver1);
            Competition.AddParticipant(driver2);
            Competition.AddParticipant(driver3);
        }

        public static void AddTracks()
        {
            SectionTypes[] sections1 = 
            { 
                SectionTypes.StartGridFromLeftToRight, 
                SectionTypes.StraightFromLeftToRight, 
                SectionTypes.StraightFromLeftToRight, 
                SectionTypes.StraightFromLeftToRight, 
                SectionTypes.TurnFromLeftToDown, 
                SectionTypes.StraightFromUpToDown,
                SectionTypes.StraightFromUpToDown,
                SectionTypes.TurnFromUpToLeft,
                SectionTypes.StraightFromRightToLeft,
                SectionTypes.StraightFromRightToLeft,
                SectionTypes.StraightFromRightToLeft,
                SectionTypes.TurnFromRightToUp,
                SectionTypes.StraightFromDownToUp,
                SectionTypes.FinishFromDownToUp
            };
            SectionTypes[] sections2 =
            {
                SectionTypes.StartGridFromLeftToRight, 
                SectionTypes.StraightFromLeftToRight, 
                SectionTypes.StraightFromLeftToRight, 
                SectionTypes.StraightFromLeftToRight, 
                SectionTypes.TurnFromLeftToDown, 
                SectionTypes.StraightFromUpToDown,
                SectionTypes.StraightFromUpToDown,
                SectionTypes.TurnFromUpToLeft,
                SectionTypes.StraightFromRightToLeft,
                SectionTypes.StraightFromRightToLeft,
                SectionTypes.StraightFromRightToLeft,
                SectionTypes.TurnFromRightToDown,
                SectionTypes.StraightFromUpToDown,
                SectionTypes.FinishFromUpToDown
            };
            var track1 = new Track("Yoshi Falls", sections1);
            var track2 = new Track("Cheep Cheep Beach", sections2);
            Competition.AddTrack(track1);
            Competition.AddTrack(track2);
        }
        
        public static void NextRace()
        {
            if (Competition.Tracks.Count != 0) CurrentRace = new Race(Competition.ChangeToNextTrack(), Competition.Participants);
        }
    }
}
