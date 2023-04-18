using Controller;

// See https://aka.ms/new-console-template for more information

Data.Initialize();
Data.NextRace();
Console.WriteLine("Current track name:");
Console.WriteLine(Data.CurrentRace.Track.Name);

for (; ; )
{
    Thread.Sleep(100);
}




