using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Points { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEquipment Equipment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TeamColor TeamColors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Driver(string name, int points, IEquipment equipment, TeamColor teamColors)
        {
            Name = name;
            Points = points;
            Equipment = equipment;
            TeamColors = teamColors;
        }
    }
}
