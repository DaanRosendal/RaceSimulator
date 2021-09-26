using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }
        public string Icon { get; set; }

        public Driver(string name, IEquipment car, TeamColors teamColor, string icon)
        {
            Name = name;
            Points = 0;
            Equipment = car;
            TeamColor = teamColor;
            Icon = icon;
        }
    }
}
