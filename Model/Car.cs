using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Car : IEquipment
    {
        public int Quality { get; set; }
        public int Performance { get; set; }
        public int Speed { get; set; }
        public int IsBroken { get; set; }

        public Car(int quality, int performance, int speed, int isBroken)
        {
            Quality = quality;
            Performance = performance;
            Speed = speed;
            IsBroken = isBroken;
        }
    }
}
