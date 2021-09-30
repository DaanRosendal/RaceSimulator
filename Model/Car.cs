using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Car : IEquipment
    {
        public Qualities Quality { get; set; }
        public Performances Performance { get; set; }
        public bool IsBroken { get; set; }

        private const int BaseSpeed = 2;
        private int _speed;
        public int Speed
        {
            get { return _speed; }
            private set
            {
                _speed = BaseSpeed + (int)Quality + (int)Performance;
                if (_speed <= 0) _speed = 1;
                if (_speed >= 4) _speed = 3;
            }
        }

        public Car(Qualities quality, Performances performance)
        {
            Quality = quality;
            Performance = performance;
            IsBroken = false;
            Speed = BaseSpeed;
        }
    }
}
