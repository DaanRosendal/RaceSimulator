using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Controller
{
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random { get; set; }
        private Dictionary<Section, SectionData> _positions { get; set; }

        public Race(Track track, List<IParticipant> participants)
        {
            Track = track;
            Participants = participants;
            _random = new Random(DateTime.Now.Millisecond);
            _positions = new Dictionary<Section, SectionData>();
            PlaceDriversInStartPosition();
        }

        public void RandomizeEquipment()
        {
            foreach(var participant in Participants)
            {
                var driver = (Driver) participant;
                driver.Equipment.Quality = _random.Next(1, 11);
                driver.Equipment.Performance = _random.Next(1, 11);
            }
        }

        private void PlaceDriversInStartPosition()
        {
            var count = 0;
            foreach (var section in Track.Sections)
            {
                if (
                    section.SectionType == SectionType.Start
                )
                {
                    if (Participants.ElementAt(count) != null)
                    {
                        section.SectionData.LeftParticipant = Participants.ElementAt(count);
                        section.SectionData.DistanceLeft = 1;
                        
                        if (Participants.ElementAt(count+1) != null)
                        {
                            section.SectionData.RightParticipant = Participants.ElementAt(count+1);
                            section.SectionData.DistanceRight = 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            // _positions.Add(Track.Sections.ElementAt(0), new SectionData());
        }
    }
}
