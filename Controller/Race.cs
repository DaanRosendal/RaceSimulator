﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
        private Timer _timer { get; set; }

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
            }
        }
        
        private void PlaceDriversInStartPosition()
        {
            var count = 0;
            for (var node = Track.Sections.First; node != null; node = node.Next)
            {
                var section = node.Value;
                if (
                    section.SectionType == SectionType.Start
                )
                {
                    if (count < Participants.Count)
                    {
                        section.SectionData.LeftParticipant = Participants.ElementAt(count++);
                        section.SectionData.DistanceLeft = 1;
                        
                        if (count < Participants.Count)
                        {
                            section.SectionData.RightParticipant = Participants.ElementAt(count++);
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
