using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant>? Participants { get; set; }
        public DateTime StartTime { get; set; }
        private Random? _random;
        private Dictionary<Section, SectionData>? _positions;

        public Race(Track track, List<IParticipant> participants)
        {
            Track = track;
            Participants = participants;
            _random = new Random(DateTime.Now.Millisecond);
        }
        public SectionData GetSectionData(Section section)
        {
            try
            {
                return _positions[section];
            }
            catch (KeyNotFoundException)
            {
                SectionData newSectionData = new SectionData();
                _positions.Add(section, newSectionData);
                return newSectionData;

            }
        }

        public void RandomizeEquipment()
        {
            foreach (var participant in Participants)
            {
                participant.Equipment.Quality = _random.Next();
                participant.Equipment.Performance = _random.Next();
            }
        }


    }
}
