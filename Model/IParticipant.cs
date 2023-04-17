using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColor TeamColors { get; set; }
    }

    public enum TeamColor
    {
        Red,
        Green,
        Yellow,
        Grey,
        Blue
    }
}
