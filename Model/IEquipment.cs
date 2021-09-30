using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IEquipment
    {
        public Qualities Quality { get; set; }
        public Performances Performance { get; set; }
        public int Speed { get; }
        public bool IsBroken { get; set; }
    }
    
    public enum Performances
    {
        Outstanding = 1,
        Normal = 0,
        Shit = -1
    }

    public enum Qualities
    {
        Excellent = 1,
        Average = 0,
        Garbage = -1
    }
}
