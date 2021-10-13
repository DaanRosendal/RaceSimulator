using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Track
    {
        public string Name { get; set; }
        public LinkedList<Section> Sections { get; set; }
        

        public Track(string name, Section[] sections)
        {
            Name = name;
            AssignSectionsArrayToLinkedList(sections);
        }

        private void AssignSectionsArrayToLinkedList(Section[] sections)
        {
            Sections = new LinkedList<Section>();
            foreach (var section in sections)
            {
                Sections.AddLast(section);
            }
        }
        
        public int GetWidthInPx()
        {
            var width = 100;
            var highestWidth = 0;
            
            foreach (var section in Sections)
            {
                switch (section.OutgoingDirection)
                {
                    case Direction.Right:
                        width += 100;
                        break;
                    case Direction.Left:
                        width -= 100;
                        break;
                }

                highestWidth = Math.Max(width, highestWidth);
            }

            return highestWidth+100;
        }
        
        public int GetHeightInPx()
        {
            var height = 200;
            var highestHeight = 0;

            foreach (var section in Sections)
            {
                switch (section.OutgoingDirection)
                {
                    case Direction.Down:
                        height += 100;
                        break;
                    case Direction.Up:
                        height -= 100;
                        break;
                }

                highestHeight = Math.Max(height, highestHeight);
            }

            return highestHeight+100;
        }
    }
}
