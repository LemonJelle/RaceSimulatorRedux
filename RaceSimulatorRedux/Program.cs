using Controller;
using RaceSimulatorRedux;

// See https://aka.ms/new-console-template for more information

Data.Initialize();
Data.NextRace();
//Console.WriteLine("Current track name:");
//Console.WriteLine(Data.CurrentRace.Track.Name);
ConsoleVisualisation.Initialise();
ConsoleVisualisation.DrawTrack(Data.CurrentRace.Track);

for (; ; )
{
    Thread.Sleep(100);
}




