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
            Sections = new LinkedList<Section>();
            foreach (SectionTypes sectionType in sections)
            {
                Section section = new Section(sectionType);
                Sections.AddLast(section);
            }
        }
    }
}
