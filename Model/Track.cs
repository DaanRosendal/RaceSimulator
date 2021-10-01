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
    }
}
