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

        public ConsoleColor GetTeamColorAsConsoleColor()
        {
            if (TeamColor == TeamColors.Blue) return ConsoleColor.Blue;
            else if (TeamColor == TeamColors.Red) return ConsoleColor.Red;
            else if (TeamColor == TeamColors.Green) return ConsoleColor.Green;
            else if (TeamColor == TeamColors.White) return ConsoleColor.White;
            else if (TeamColor == TeamColors.Yellow) return ConsoleColor.Yellow;
            else return ConsoleColor.DarkMagenta;
        }
    }
}
