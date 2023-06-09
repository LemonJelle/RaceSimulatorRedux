﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Controller
{
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }

        public event EventHandler<DriversChangedEventArgs> DriversChanged;


        private Random _random;
        private Dictionary<Section, SectionData> _positions = new Dictionary<Section, SectionData>();
        private System.Timers.Timer _timer;
        



        public Race(Track track, List<IParticipant> participants)
        {
            Track = track;
            Participants = participants;
            _random = new Random(DateTime.Now.Millisecond);
          
            FillPositions();
            GiveRacersStartPosition();
            InitialiseTimer(500);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs eea)
        {
            AdvanceParticipants();
            
        }
        public SectionData GetSectionData(Section section)
        {
            // Return the sectiondata for the given section
            try
            {
                return _positions[section];
            }
            catch (KeyNotFoundException) //If not found, create default new section data for the given section
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

        private void GiveRacersStartPosition()
        {
            //make stack of start grid sections
            Stack<Section> startGrids = new Stack<Section>();

            //search for startgrid sections in the track and add them to stack
            foreach (Section section in Track.Sections)
            {
                if (section.SectionType == SectionTypes.StartGrid)
                {
                    startGrids.Push(section);
                }
            }

            //Get number of participants
            int participants = Participants.Count;

            //keep track of participants already placed, a counter of sorts
            int participantsAlreadyPlaced = 0;

            //Place participants as long as there is still a startgrid left
            //Check how many participants are left
            while (startGrids.Count > 0)
            {
                //get section from stack
                Section section = startGrids.Pop();
                //get data of each section
                SectionData sectionData = GetSectionData(section);
                //if there is still two or more participants left to place, take up two positions
                if (participants - participantsAlreadyPlaced > 1)
                {
                    //left
                    sectionData.Left = Participants[participantsAlreadyPlaced];
                    participantsAlreadyPlaced += 1;
                    //right
                    sectionData.Right = Participants[participantsAlreadyPlaced];
                    participantsAlreadyPlaced += 1;
                    _positions[section] = sectionData;
                }

                //if there is still one participant left to place, take up the left position 
                else if (participants - participants == 1)
                {
                    sectionData.Left = Participants[participants];
                    participantsAlreadyPlaced += 1;
                    _positions[section] = sectionData;
                }
            }
        }

        private void FillPositions()
        {
            //fill the _positions dictionary with positions     
            foreach (Section section in Track.Sections)
            {
                GetSectionData(section);
            }
        }

        private void AdvanceParticipants()
        {

            //update distance when participant is present in position
            //check if distance > max distance of section
            //if so, move participant to next section in _positions
            //invoke driverschanged event to signal visualisation update
            //use AdvanceParticipantsToNextSection() method to advance to every section to comply with the SOLID principles
            //use positions dictionary as list of sections to loop through

            //create a LinkedListNode so we can go through the sections to start with, the last one 
            LinkedListNode<Section> currentSection = Track.Sections.Last;

            //loop to move all participants, this breaks if current section is not null
            while (currentSection  != null)
            {
                currentSection =
            }
            

            Section currentSection = Track.Sections.First();
            Section nextSection;

            









        }

        private void AdvanceParticipantsToNextSection(Section currentSection, Section nextSection)
        {
            // Right participant
            
            //get section data of sections
            //check 

        } 

        private int CalculateRealSpeed(int performance, int speed)
        {
            return performance * speed;
        }
        private void Start()
        {
            _timer.Enabled = true;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void InitialiseTimer(int interval)
        {
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += OnTimedEvent;
            Start();
        }

        private void InvokeDriversChangedEvent()
        {
            DriversChanged.Invoke(this, new DriversChangedEventArgs
            {
                EventTrack = Track
            });
        }


    }
}
