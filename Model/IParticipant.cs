using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IParticipant
    {
        public string Name { get; set; }
        public int DrivenLaps { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }
        public string Icon { get; set; }
        public bool Finished { get; set; }
        public Section previousSection { get; set; }

        public ConsoleColor GetTeamColorAsConsoleColor();
    }

    public enum TeamColors
    {
        Red,
        Green,
        Yellow,
        White,
        Blue
    }
}
