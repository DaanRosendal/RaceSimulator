using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition Competition { get; set; }
        public static Race CurrentRace { get; set; }

        public static void Initialize()
        {
            Competition = new Competition();
            AddParticipants();
            AddTracks();
            NextRace();
        }

        public static void AddParticipants()
        {
            var driver1 = new Model.Driver("Luigi", new Car(Qualities.Average, Performances.Normal), TeamColors.Green, "1");
            var driver2 = new Model.Driver("Rick", new Car(Qualities.Excellent, Performances.Outstanding), TeamColors.Blue, "2");
            var driver3 = new Model.Driver("Morty", new Car(Qualities.Garbage, Performances.Shit), TeamColors.Yellow, "3");
            var driver4 = new Model.Driver("Donkey Kong", new Car(Qualities.Excellent, Performances.Shit), TeamColors.White, "4");
            Competition.AddParticipant(driver1);
            Competition.AddParticipant(driver2);
            Competition.AddParticipant(driver3);
            Competition.AddParticipant(driver4);
        }

        public static void AddTracks()
        { 
            Section[] sections1 =
            {
                new Section(Direction.Down, Direction.Right, SectionType.Turn),
                new Section(Direction.Left, Direction.Right, SectionType.Straight),
                new Section(Direction.Left, Direction.Right, SectionType.Straight),
                new Section(Direction.Left, Direction.Down, SectionType.Turn),
                new Section(Direction.Up, Direction.Down, SectionType.Straight),
                new Section(Direction.Up, Direction.Down, SectionType.Straight),
                new Section(Direction.Up, Direction.Right, SectionType.Turn),
                new Section(Direction.Left, Direction.Down, SectionType.Turn),
                new Section(Direction.Up, Direction.Left, SectionType.Turn),
                new Section(Direction.Right, Direction.Left, SectionType.Straight),
                new Section(Direction.Right, Direction.Left, SectionType.Straight),
                new Section(Direction.Right, Direction.Left, SectionType.Straight),
                new Section(Direction.Right, Direction.Up, SectionType.Turn),
                new Section(Direction.Down, Direction.Up, SectionType.Finish),
                new Section(Direction.Down, Direction.Up, SectionType.Start),
                new Section(Direction.Down, Direction.Up, SectionType.Start),
            };
            var track1 = new Track("Yoshi Falls", sections1);
            
            Section[] sections2 = 
            { 
                new Section(Direction.Down, Direction.Right, SectionType.Turn),
                new Section(Direction.Left, Direction.Right, SectionType.Straight),
                new Section(Direction.Left, Direction.Right, SectionType.Straight),
                new Section(Direction.Left, Direction.Right, SectionType.Straight),
                new Section(Direction.Left, Direction.Right, SectionType.Straight),
                new Section(Direction.Left, Direction.Down, SectionType.Turn),
                new Section(Direction.Up, Direction.Down, SectionType.Straight),
                new Section(Direction.Up, Direction.Left, SectionType.Turn),
                new Section(Direction.Right, Direction.Down, SectionType.Turn),
                new Section(Direction.Up, Direction.Right, SectionType.Turn),
                new Section(Direction.Left, Direction.Down, SectionType.Turn),
                new Section(Direction.Up, Direction.Left, SectionType.Turn),
                new Section(Direction.Right, Direction.Left, SectionType.Straight),
                new Section(Direction.Right, Direction.Left, SectionType.Straight),
                new Section(Direction.Right, Direction.Down, SectionType.Turn),
                new Section(Direction.Up, Direction.Left, SectionType.Turn),
                new Section(Direction.Right, Direction.Left, SectionType.Straight),
                new Section(Direction.Right, Direction.Up, SectionType.Turn),
                new Section(Direction.Down, Direction.Up, SectionType.Straight),
                new Section(Direction.Down, Direction.Up, SectionType.Finish),
                new Section(Direction.Down, Direction.Up, SectionType.Start),
                new Section(Direction.Down, Direction.Up, SectionType.Start),
            };
            var track2 = new Track("Cheep Cheep Beach", sections2);
            
            Competition.AddTrack(track1);
            Competition.AddTrack(track2);
        }
        
        public static void NextRace()
        {
            if (Competition.Tracks.Count != 0)
                CurrentRace = new Race(Competition.ChangeToNextTrack(), Competition.Participants);
            else
                Competition.Finished = true;
        }
    }
}
