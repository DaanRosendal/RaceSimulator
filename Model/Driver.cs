using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name { get; set; }
        public int DrivenLaps { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }
        public string Icon { get; set; }
        public bool Finished { get; set; }
        public Section previousSection { get; set; }

        public Driver(string name, IEquipment car, TeamColors teamColor, string icon)
        {
            Name = name;
            DrivenLaps = 0;
            Equipment = car;
            TeamColor = teamColor;
            Icon = icon;
            Finished = false;
            previousSection = null;
        }

        public ConsoleColor GetTeamColorAsConsoleColor()
        {
            return TeamColor switch
            {
                TeamColors.Blue => ConsoleColor.Blue,
                TeamColors.Red => ConsoleColor.Red,
                TeamColors.Green => ConsoleColor.Green,
                TeamColors.White => ConsoleColor.White,
                TeamColors.Yellow => ConsoleColor.Yellow
            };
        }
    }
}
