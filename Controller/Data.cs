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
            addParticipants();
            addTracks();
        }

        public static void addParticipants()
        {
            Driver driver1 = new Model.Driver("John", new Car(5, 5, 5, 0), TeamColors.Green);
            Driver driver2 = new Model.Driver("Rick", new Car(7, 7, 7, 0), TeamColors.Blue);
            Driver driver3 = new Model.Driver("Morty", new Car(5, 5, 5, 0), TeamColors.Yellow);
            Competition.addParticipant(driver1);
            Competition.addParticipant(driver2);
            Competition.addParticipant(driver3);
        }

        public static void addTracks()
        {
            SectionTypes[] sections1 = { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.Finish};
            SectionTypes[] sections2 = { SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Finish};
            Track track1 = new Track("Yoshi Falls", sections1);
            Track track2 = new Track("Cheep Cheep Beach", sections2);
            Competition.addTrack(track1);
            Competition.addTrack(track2);
        }

        public static void NextRace()
        {
            if (Competition.Tracks.Count != 0) CurrentRace = new Race(Competition.NextTrack(), Competition.Participants);
        }
    }
}
