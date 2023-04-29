using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition? Competition { get; set; }
        public static Race? CurrentRace { get; set; }

        public static void Initialize()
        {
            Competition = new Competition();
            AddParticipants();
            AddTracks();
        }

        public static void AddParticipants()
        {
            Competition.Participants.Add(new Driver("Dennis Hauger", 0, new Car(20, 20, 20), TeamColor.Red));
            Competition.Participants.Add(new Driver("Jehan Daruvala", 0, new Car(20, 20, 20), TeamColor.Green));
            Competition.Participants.Add(new Driver("Jak Crawford", 0, new Car(20, 20, 20), TeamColor.Blue));
            Competition.Participants.Add(new Driver("Enzo Fittipaldi", 0, new Car(20, 20, 20), TeamColor.Yellow));
            Competition.Participants.Add(new Driver("Arthur Leclerc", 0, new Car (20, 20, 20), TeamColor.Grey));
            Competition.Participants.Add(new Driver("Frederik Vesti", 0, new Car(20, 20, 20), TeamColor.Red));
        }

        public static void AddTracks()
        {
            Competition.Tracks.Enqueue(new Track("Barcelona", new[]
            {
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.Finish,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.LeftCorner,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                
            }));
            Competition.Tracks.Enqueue(new Track("Indianapolis Motor Speedway", new[]
            {
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.Finish,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner
            }));
        }

        public static void NextRace()
        {
            if (Competition.NextTrack != null)
            {
                CurrentRace = new Race(Competition.NextTrack(), Competition.Participants);

            } else
            {
                CurrentRace = null;
            }
        }

    }
}
