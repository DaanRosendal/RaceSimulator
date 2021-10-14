using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants { get; set; }
        public Queue<Track> Tracks { get; set; }
        public Stopwatch Timer { get; set; }
        public bool Finished { get; set; }

        public Competition()
        {
            Participants = new List<IParticipant>();
            Tracks = new Queue<Track>();
            Timer = Stopwatch.StartNew();
            Finished = false;
        }

        public Track ChangeToNextTrack()
        {
            if(Tracks.Count == 0)
            {
                return null;
            }
            else
            {
                return Tracks.Dequeue();
            }
        }

        public void AddParticipant(IParticipant participant)
        {
            Participants.Add(participant);
        }
       
        public void AddTrack(Track track)
        {
            Tracks.Enqueue(track);
        }

        public long GetElapsedTime()
        {
            var time = Timer.ElapsedMilliseconds / 1000;
            return time;
        }

        public void EndCompetition()
        {
            Timer.Stop();
        }
    }
}
