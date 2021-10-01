using System;
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
        private const int Laps = 3;
        private Random _random { get; set; }
        private Dictionary<Section, SectionData> _positions { get; set; }
        private Section FinishSection;

        public Race(Track track, List<IParticipant> participants)
        {
            Track = track;
            Participants = participants;
            _random = new Random(DateTime.Now.Millisecond);
            _positions = new Dictionary<Section, SectionData>();
            PlaceDriversInStartPosition();
            FinishSection = GetFinishSectionOfCurrentTrack();
        }

        public void RandomizeEquipment(int chance1In = -1)
        {
            if (chance1In > 0)
            {
                var randomNumber = _random.Next(0, chance1In);
                if (randomNumber != 1) return;
            }
            foreach(var participant in Participants)
            {
                var driver = (Driver) participant;
                var currentPerformance = participant.Equipment.Performance;
                var currentQuality = participant.Equipment.Quality;
                var randomPerformance = currentPerformance;
                var randomQuality = currentQuality;

                var performanceValues = Enum.GetValues(typeof(Performances));
                while (currentPerformance == randomPerformance)
                {
                    randomPerformance =
                        (Performances) performanceValues.GetValue(_random.Next(performanceValues.Length));
                    driver.Equipment.Performance = randomPerformance;
                }
                
                var qualityValues = Enum.GetValues(typeof(Qualities));
                while (currentQuality == randomQuality)
                {
                    randomQuality =
                        (Qualities) qualityValues.GetValue(_random.Next(qualityValues.Length));
                    driver.Equipment.Quality = randomQuality;
                }
            }
        }

        public void CheckIfParticipantsOnFinish()
        {
            if (FinishSection.SectionData.LeftParticipant != null)
            {
                HandleFinishEntry(FinishSection.SectionData.LeftParticipant);
            }
            
            if (FinishSection.SectionData.RightParticipant != null)
            {
                HandleFinishEntry(FinishSection.SectionData.RightParticipant);
            }
        }

        private void HandleFinishEntry(IParticipant participant)
        {
            if (participant.previousSection != FinishSection)
            {
                participant.DrivenLaps++;
            }
            
            if (participant.DrivenLaps >= Laps)
            {
                if (FinishSection.SectionData.LeftParticipant == participant)
                    FinishSection.SectionData.LeftParticipant = null;
                else if (FinishSection.SectionData.RightParticipant == participant)
                    FinishSection.SectionData.RightParticipant = null;
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
        }

        private Section GetFinishSectionOfCurrentTrack()
        {
            return Track.Sections.FirstOrDefault(section => section.SectionType == SectionType.Finish);
        }
    }
}
