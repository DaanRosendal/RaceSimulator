using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Car : IEquipment
    {
        private Qualities _quality;
        public Qualities Quality
        {
            get => _quality;
            set
            {
                _quality = value;
                updateSpeed();
            }
        }
        
        private Performances _performance;
        public Performances Performance
        {
            get => _performance;
            set
            {
                _performance = value;
                updateSpeed();
            }
        }

        public bool IsBroken { get; set; }

        private const int BaseSpeed = 2;
        public int Speed { get; private set; }

        public Car(Qualities quality, Performances performance)
        {
            Quality = quality;
            Performance = performance;
            updateSpeed();
            IsBroken = false;
        }

        private void updateSpeed()
        {
            Speed = BaseSpeed + (int)Quality + (int)Performance;
            if (Speed <= 0) Speed = 1;
            if (Speed >= 4) Speed = 3;
        }
    }
}
