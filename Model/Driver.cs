using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColor TeamColors { get; set; }

        public Driver(string name, int points, IEquipment equipment, TeamColor teamColors)
        {
            Name = name;
            Points = points;
            Equipment = equipment;
            TeamColors = teamColors;
        }
    }
}
