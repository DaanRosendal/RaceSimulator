using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }
        public const int Laps = 3;
        public Stopwatch Timer { get; set; }
        private Section FinishSection;
        private Random _random;

        public Race(Track track, List<IParticipant> participants)
        {
            _random = new Random(DateTime.Now.Millisecond);
            Track = track;
            Participants = participants;
            PlaceDriversInStartPosition();
            FinishSection = GetFinishSectionOfCurrentTrack();
            Timer = Stopwatch.StartNew();
        }

        public void RandomizeEquipment(int chance1In = -1)
        {
            // 1 in x chance of randomizing the equipment
            if (chance1In > 0)
            {
                var randomNumber =  _random.Next(0, chance1In);
                if (randomNumber != 1) return;
            }
            
            foreach(var participant in Participants)
            {
                var driver = (Driver) participant;

                // Potentially break/fix car
                // if (driver.Equipment.IsBroken)
                // {
                //     var randomNumber = _random.Next(0, 2);
                //     if (randomNumber == 0)
                //     {
                //         driver.Equipment.IsBroken = false;
                //     }
                // }
                // else
                // {
                //     var chance = 10 + (int) driver.Equipment.Performance - (int) driver.Equipment.Quality;
                //     var randomNumber = _random.Next(0, chance);
                //
                //
                //     if (randomNumber > 0)
                //     {
                //         driver.Equipment.IsBroken = true;
                //     }
                // }

                // Randomize equipment 
                var currentPerformance = driver.Equipment.Performance;
                var currentQuality = driver.Equipment.Quality;
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

        public bool ParticipantsOnTrack()
        {
            foreach (var section in Track.Sections)
            {
                if (section.SectionData.LeftParticipant != null || section.SectionData.RightParticipant != null)
                    return true;
            }

            
            foreach (var participant in Participants)
            {
                participant.DrivenLaps = 0;
            }
            
            return false;
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
            if (participant.PreviousSection != FinishSection)
            {
                participant.DrivenLaps++;
            }
            
            if (participant.DrivenLaps >= Laps)
            {
                if (FinishSection.SectionData.LeftParticipant == participant)
                {
                    FinishSection.SectionData.LeftParticipant.Finished = true;
                    FinishSection.SectionData.LeftParticipant = null;
                } else if (FinishSection.SectionData.RightParticipant == participant)
                {
                    FinishSection.SectionData.RightParticipant.Finished = true;
                    FinishSection.SectionData.RightParticipant = null;
                }
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
                        section.SectionData.LeftParticipant.Timer = Stopwatch.StartNew();
                        
                        if (count < Participants.Count)
                        {
                            section.SectionData.RightParticipant = Participants.ElementAt(count++);
                            section.SectionData.DistanceRight = 1;
                            section.SectionData.RightParticipant.Timer = Stopwatch.StartNew();
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

        public void PrepareDriversForNextRace()
        {
            foreach (var participant in Participants)
            {
                participant.Timer.Reset();
                participant.Finished = false;
            }
        }
        
        public long GetElapsedTime()
        {
            var time = Timer.ElapsedMilliseconds / 1000;
            return time;
        }
    }
}
