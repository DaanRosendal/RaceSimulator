using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    public class Race
    {
        public Track Track;
        public List<IParticipant> Participants;
        public DateTime StartTime;
        private Random _random;
        private Dictionary<Section, SectionData> _positions { get; set; }

        public Race(Track track, List<IParticipant> participants)
        {
            Track = track;
            Participants = participants;
            _random = new Random(DateTime.Now.Millisecond);
        }

        public void RandomizeEquipment()
        {
            foreach(Driver driver in Data.Competition.Participants)
            {
                driver.Equipment.Quality = _random.Next(1, 11);
                driver.Equipment.Performance = _random.Next(1, 11);
            }
        }
    }
}
