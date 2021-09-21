using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Track
    {
        public string Name;
        public LinkedList<Section> Sections;

        public Track(string name, SectionTypes[] sections)
        {
            Name = name;
            AssignSectionsArrayToLinkedList(sections);
        }

        private void AssignSectionsArrayToLinkedList(SectionTypes[] sections)
        {
            Sections = new LinkedList<Section>();
            foreach (var sectionType in sections)
            {
                var section = new Section(sectionType);
                Sections.AddLast(section);
            }
        }
    }
}
