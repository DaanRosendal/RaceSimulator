using System;
using System.Collections.Generic;
using System.Diagnostics;
using Model;

namespace Controller
{
    public static class Visualizer
    {
        #region graphics

        private static string[] _startGridFromLeftToRight =
        {
            "----",
            " #  ",
            " #  ",
            "----"
        };
        private static string[] _finishFromRightToLeft = _startGridFromLeftToRight;

        private static string[] _startGridFromRightToLeft =
        {
            "----",
            "  # ",
            "  # ",
            "----"
        };
        private static string[] _finishFromLeftToRight = _startGridFromRightToLeft;


        private static string[] _startGridFromUpToDown =
        {
            "|  |",
            "|##|",
            "|  |",
            "|  |"
        };
        private static string[] _finishFromDownToUp = _startGridFromUpToDown;

        
        private static string[] _startGridFromDownToUp =
        {
            "|  |",
            "|  |",
            "|##|",
            "|  |"
        };
        private static string[] _finishFromUpToDown = _startGridFromDownToUp;
        
        private static string[] _straightFromLeftToRight =
        {
            "----",
            "    ",
            "    ",
            "----"
        };
        private static string[] _straightFromRightToLeft = _straightFromLeftToRight;

        private static string[] _straightFromUpToDown =
        {
            "|  |",
            "|  |",
            "|  |",
            "|  |"
        };
        private static string[] _straightFromDownToUp = _straightFromUpToDown;

        private static string[] _turnFromLeftToUp =
        {
            "/  |",
            "   |",
            "   /",
            "--/ "
        };
        private static string[] _turnFromUpToLeft = _turnFromLeftToUp;

        private static string[] _turnFromRightToUp =
        {
            "|  \\",
            "|   ",
            "\\   ",
            " \\--"
        };
        private static string[] _turnFromUpToRight = _turnFromRightToUp;

        private static string[] _turnFromDownToRight =
        {
            " /--",
            "/   ",
            "|   ",
            "|  /"
        };
        private static string[] _turnFromRightToDown = _turnFromDownToRight;

        private static string[] _turnFromLeftToDown =
        {
            "--\\ ",
            "   \\",
            "   |",
            "\\  |"
        };
        private static string[] _turnFromDownToLeft = _turnFromLeftToDown;

        #endregion

        private static int _x = 0;
        private static int _y = 0;
        
        public static void DrawTrack(Track track)
        {
            Console.SetCursorPosition(0,0);
            foreach (var section in track.Sections)
            {
                DrawSection(section);
                MoveCursorForNextSection(section);
            }
        }

        private static void DrawSection(Section section)
        {
            ApplySectionColor(section);
            var sectionType = section.SectionType;
            var incomingDirection = section.IncomingDirection;
            var outgoingDirection = section.OutgoingDirection;
            section.X = Console.CursorLeft;
            section.Y = Console.CursorTop;
            
            if (incomingDirection == Direction.Left && outgoingDirection == Direction.Right)
            {
                if (sectionType == SectionType.Start) DrawGraphicArray(_startGridFromLeftToRight);
                else if (sectionType == SectionType.Straight) DrawGraphicArray(_straightFromLeftToRight);
                else if (sectionType == SectionType.Finish) DrawGraphicArray(_finishFromLeftToRight);
            }

            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Left)
            {
                if (sectionType == SectionType.Start) DrawGraphicArray(_startGridFromRightToLeft);
                else if (sectionType == SectionType.Straight) DrawGraphicArray(_straightFromRightToLeft);
                else if (sectionType == SectionType.Finish) DrawGraphicArray(_finishFromRightToLeft);
            }

            else if (incomingDirection == Direction.Up && outgoingDirection == Direction.Down)
            {
                if (sectionType == SectionType.Start) DrawGraphicArray(_startGridFromUpToDown);
                else if (sectionType == SectionType.Straight) DrawGraphicArray(_straightFromUpToDown);
                else if (sectionType == SectionType.Finish) DrawGraphicArray(_finishFromUpToDown);
            }
            
            else if (incomingDirection == Direction.Down && outgoingDirection == Direction.Up)
            {
                if (sectionType == SectionType.Start) DrawGraphicArray(_startGridFromDownToUp);
                else if (sectionType == SectionType.Straight) DrawGraphicArray(_straightFromDownToUp);
                else if (sectionType == SectionType.Finish) DrawGraphicArray(_finishFromDownToUp);
            }

            else if (incomingDirection == Direction.Left && outgoingDirection == Direction.Up ||
                     incomingDirection == Direction.Up && outgoingDirection == Direction.Left)
            {
                DrawGraphicArray(_turnFromLeftToUp);
            }

            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Up ||
                     incomingDirection == Direction.Up && outgoingDirection == Direction.Right)
            {
                DrawGraphicArray(_turnFromUpToRight);
            }
            
            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Down ||
                     incomingDirection == Direction.Down && outgoingDirection == Direction.Right)
            {
                DrawGraphicArray(_turnFromRightToDown);
            }
            
            else if (incomingDirection == Direction.Left && outgoingDirection == Direction.Down ||
                     incomingDirection == Direction.Down && outgoingDirection == Direction.Left)
            {
                DrawGraphicArray(_turnFromDownToLeft);
            }
        }

        private static void DrawGraphicArray(string[] graphicArray)
        {
            for (int i = 0; i < graphicArray.Length; i++)
            {
                Console.Write($"{graphicArray[i]}");
                Console.SetCursorPosition(_x, _y+=1);
            }
        }

        private static void MoveCursorForNextSection(Section section)
        {
            switch (section.OutgoingDirection)
            {
                case Direction.Up:
                    _y -= 8;
                    break;
                case Direction.Right:
                    _x += 4;
                    _y -= 4;
                    break;
                case Direction.Left:
                    _x -= 4;
                    _y -= 4;
                    break;
                case Direction.Down:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Console.SetCursorPosition(_x, _y);
        }

        private static void ApplySectionColor(Section section)
        {
            // Console.BackgroundColor = ConsoleColor.DarkGray;
            if (section.SectionType == SectionType.Start || section.SectionType == SectionType.Finish)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (section.SectionType == SectionType.Straight || section.SectionType == SectionType.Turn)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

        public static void DrawParticipants(Track track)
        {
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var section in track.Sections)
            {
                if (section.SectionData.LeftParticipant != null)
                {
                    Console.SetCursorPosition(
                        section.X + section.LeftPath.X[section.SectionData.DistanceLeft], 
                        section.Y + section.LeftPath.Y[section.SectionData.DistanceLeft]
                    );
                    Console.Write(section.SectionData.LeftParticipant.Icon);
                }

                if (section.SectionData.RightParticipant != null)
                {
                    Console.SetCursorPosition(
                        section.X + section.RightPath.X[section.SectionData.DistanceRight], 
                        section.Y + section.RightPath.Y[section.SectionData.DistanceRight]
                    );
                    Console.Write(section.SectionData.RightParticipant.Icon);
                }
            }
        }

        public static void HideParticipants(Track track)
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            // Hide participant
            for (var node = track.Sections.First; node != null; node = node.Next)
            {
                var section = node.Value;
                if (section.SectionData.LeftParticipant != null)
                {
                    Console.SetCursorPosition(
                        section.X + section.LeftPath.X[section.SectionData.DistanceLeft], 
                        section.Y + section.LeftPath.Y[section.SectionData.DistanceLeft]
                    );
                    Console.Write(" ");
                    section.SectionData.DistanceLeft++;
                }

                if (section.SectionData.RightParticipant != null)
                {
                    Console.SetCursorPosition(
                        section.X + section.RightPath.X[section.SectionData.DistanceRight], 
                        section.Y + section.RightPath.Y[section.SectionData.DistanceRight]
                    );
                    Console.Write(" ");
                    section.SectionData.DistanceRight++;
                }
            }
        }

        public static void RenderParticipants(Track track)
        {
            // Show participant at next position
            for (var node = track.Sections.First; node != null; node = node.Next)
            {
                var section = node.Value;

                if (section.SectionData.DistanceLeft == 4)
                {
                    
                    if (node.Next != null)
                    {
                        node.Next.Value.SectionData.LeftParticipant = section.SectionData.LeftParticipant;
                    }
                    else
                    {
                        track.Sections.First.Value.SectionData.LeftParticipant = section.SectionData.LeftParticipant;
                    }
                    section.SectionData.DistanceLeft = 0;
                    section.SectionData.LeftParticipant = null;
                }
                
                if (section.SectionData.DistanceRight == 4)
                {
                    if (node.Next != null)
                    {
                        node.Next.Value.SectionData.RightParticipant = section.SectionData.RightParticipant;
                    }
                    else
                    {
                        track.Sections.First.Value.SectionData.RightParticipant = section.SectionData.RightParticipant;
                    }
                    section.SectionData.DistanceRight = 0;
                    section.SectionData.RightParticipant = null;
                }
                
                if (section.SectionData.LeftParticipant != null)
                {
                    Console.SetCursorPosition(
                        section.X + section.LeftPath.X[section.SectionData.DistanceLeft], 
                        section.Y + section.LeftPath.Y[section.SectionData.DistanceLeft]
                    );
                    Console.Write(section.SectionData.LeftParticipant.Icon);
                }

                if (section.SectionData.RightParticipant != null)
                {
                    Console.SetCursorPosition(
                        section.X + section.RightPath.X[section.SectionData.DistanceRight], 
                        section.Y + section.RightPath.Y[section.SectionData.DistanceRight]
                    );
                    Console.Write(section.SectionData.RightParticipant.Icon);
                }
            }
        }
    }
}