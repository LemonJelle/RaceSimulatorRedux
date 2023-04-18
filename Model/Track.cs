using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Track
    {
        public string Name { get; set; }
        public LinkedList<Section> Sections { get; set; }

        public Track(string name, SectionTypes[] sections) 
        {
            Name = name;
            Sections = ConvertSectionArrayToLinkedList(sections);

        }

        public LinkedList<Section> ConvertSectionArrayToLinkedList(SectionTypes[] sections)
        {
            LinkedList<Section> sectionList = new LinkedList<Section>();
            foreach (var section in sections)
            {
                sectionList.AddLast(new Section(section));
            }
            return sectionList;
        }
    }
}
