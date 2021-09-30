using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SectionData
    {
        public IParticipant LeftParticipant { get; set; }
        public int DistanceLeft { get; set; }
        public IParticipant RightParticipant { get; set; }
        public int DistanceRight { get; set; }
    }
}
