using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Model;

namespace RaceSimulatorRedux
{
    public enum Compass
    {
        North,
        East,
        West,
        South
    }
    public static class ConsoleVisualisation
    {
        //section visualisations
        #region graphics

        //horizontal
        private static string[] _straightHorizontalEast =
        {
            "=====",
            " 1   ",
            "     ",
            " 2   ",
            "====="
        };

        private static string[] _straightHorizontalWest =
        {
            "=====",
            "   2 ",
            "     ",
            "   1 ",
            "====="
        };
        private static string[] _finishHorizontalEast =
        {
            "=====",
            "1|   ",
            " |   ",
            "2|   ",
            "====="
        };
        private static string[] _finishHorizontalWest =
        {
            "=====",
            "   |2",
            "   | ",
            "   |1",
            "====="
        };
        private static string[] _startHorizontalEast =
        {
            "=====",
            "  1) ",
            "     ",
            " 2)  ",
            "====="
        };
        private static string[] _startHorizontalWest =
        {
            "=====",
            " (1  ",
            "     ",
            "  (2 ",
            "====="
        };

        //vertical
        private static string[] _straightVerticalNorth =
        {
            "|   |",
            "|   |",
            "|1 2|",
            "|   |",
            "|   |"
        };
        private static string[] _straightVerticalSouth =
        {
            "|   |",
            "|   |",
            "|2 1|",
            "|   |",
            "|   |"
        };

        private static string[] _finishVerticalNorth =
        {
            "|   |",
            "|===|",
            "|1 2|",
            "|   |",
            "|   |"
        };
        private static string[] _finishVerticalSouth =
        {
            "|   |",
            "|2 1|",
            "|===|",
            "|   |",
            "|   |"
        };

        private static string[] _startVerticalNorth =
        {
            "|   |",
            "|-  |",
            "|1 -|",
            "|  2|",
            "|   |",
        };

        private static string[] _startVerticalSouth =
        {
            "|   |",
            "|2  |",
            "|- 1|",
            "|  -|",
            "|   |",
        };


        //corners
        
        //left corners
        private static string[] _cornerSouthLeft =
        {
            "|   #",
            "|   2",
            "|    ",
            "|1   ",
            "#===="
        };

        private static string[] _cornerWestLeft =
        {
            "/====",
            "|1   ",
            "|    ",
            "|   2",
            "|   /"
        };

        private static string[] _cornerNorthLeft =
        {
            "====#",
            "   1|",
            "    |",
            " 2  |",
            "#   |"

        };

        private static string[] _cornerEastLeft =
        {
            "/   |",
            " 1  |",
            "    |",
            "   2|",
            "====/"
        };

        //right corners

        private static string[] _cornerWestRight =
        {
            "|   #",
            "|   2",
            "|    ",
            "|1   ",
            "#===="
        };

        private static string[] _cornerNorthRight =
        {
            "/====",
            "|1   ",
            "|    ",
            "|   2",
            "|   /"
        };

        private static string[] _cornerEastRight =
        {
            "====#",
            "   1|",
            "    |",
            " 2  |",
            "#   |"

        };

        private static string[] _cornerSouthRight =
        {
            "/   |",
            " 2  |",
            "    |",
            "   1|",
            "====/"
        };


        #endregion

        //other properties
        private static int _cursorX; // cursor X position
        private static int _cursorY; // cursor Y position
        private static Compass _currentDirection; //direction the track is being drawn in, this changes in the corners

        

        public static void DrawTrack(Track track)
        {
            Console.SetWindowSize(300, 500);

            Console.SetCursorPosition(1, 1);
            Console.Write($"Track name: {track.Name}");
            _currentDirection = Compass.East; //Standard direction on the compass is east
            _cursorX = 50;
            _cursorY = 20;
            Console.SetCursorPosition(_cursorX, _cursorY);

            //loop through all the sections
            foreach (Section section in track.Sections)
            {
                DrawSection(DecideSectionToDraw(section), section);
                ChangeCursorPosition();
                Console.SetCursorPosition(_cursorX, _cursorY);


            }

        }

        public static string[] DecideSectionToDraw(Section section)
        {

            SectionTypes kindOfSection = section.SectionType;
            switch (kindOfSection)
            {
                case SectionTypes.Straight:
                    switch (_currentDirection)
                    {
                        case Compass.North:
                            return _straightVerticalNorth;
                        case Compass.South:
                            return _straightVerticalSouth;
                        case Compass.East:
                            return _straightHorizontalEast;
                        case Compass.West:
                            return _straightHorizontalWest;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                case SectionTypes.StartGrid:
                    switch (_currentDirection)
                    {
                        case Compass.North:
                            return _startVerticalNorth;
                        case Compass.South:
                            return _startVerticalSouth;
                        case Compass.East:
                            return _startHorizontalEast;
                        case Compass.West:
                            return _startHorizontalWest;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                case SectionTypes.Finish:
                    switch (_currentDirection)
                    {
                        case Compass.North:
                            return _finishVerticalNorth;
                        case Compass.South:
                            return _finishVerticalSouth;
                        case Compass.East:
                            return _finishHorizontalEast;
                        case Compass.West:
                            return _finishHorizontalWest;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                case SectionTypes.LeftCorner:
                    switch (_currentDirection)
                    {
                        case Compass.South:
                            _currentDirection = Compass.East;
                            return _cornerSouthLeft;
                        case Compass.North:
                            _currentDirection = Compass.West;
                            return _cornerNorthLeft;
                        case Compass.East:
                            _currentDirection = Compass.North;
                            return _cornerEastLeft;
                        case Compass.West:
                            _currentDirection = Compass.South;
                            return _cornerWestLeft;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                case SectionTypes.RightCorner:
                    switch (_currentDirection)
                    {
                        case Compass.South:
                            _currentDirection = Compass.West;
                            return _cornerSouthRight;
                        case Compass.North:
                            _currentDirection = Compass.East;
                            return _cornerNorthRight;
                        case Compass.East:
                            _currentDirection = Compass.South;
                            return _cornerEastRight;
                        case Compass.West:
                            _currentDirection = Compass.North;
                            return _cornerWestRight;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                default:
                    throw new ArgumentOutOfRangeException(nameof(kindOfSection), kindOfSection, "Something went wrong with the sections!");
            }

        }

        //checks the current orientation        
        public static void DrawSection(string[] sectionToDraw, Section currentSection)
        {
            int tempCursorY = _cursorY;
            foreach (string line in sectionToDraw)
            {
                Console.SetCursorPosition(_cursorX, tempCursorY);
                Console.Write(line);
                tempCursorY++;



            }
        }


        public static void ChangeCursorPosition()
        {
            switch (_currentDirection)
            {
                case Compass.North:
                    _cursorY -= 5;
                    break;
                case Compass.East:
                    _cursorX += 5;
                    break;
                case Compass.South:
                    _cursorY += 5;
                    break;
                case Compass.West:
                    _cursorX -= 5;
                    break;
            }
        }

        public static void ChangeDirection(string direction)
        {

        }
    }

    
}
