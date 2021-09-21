using System;
using System.Collections.Generic;
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
            
        private static string[] _startGridFromRightToLeft =
        {
            "----",
            "  # ",
            "  # ",
            "----"
        };

        private static string[] _startGridFromUpToDown =
        {
            "|  |",
            "|##|",
            "|  |",
            "|  |"
        };
        
        private static string[] _startGridFromDownToUp =
        {
            "|  |",
            "|  |",
            "|##|",
            "|  |"
        };

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

        private static string[] _finishFromRightToLeft =
        {
            "----",
            "  #|",
            "  #|",
            "----"
        };
        
        private static string[] _finishFromLeftToRight =
        {
            "----",
            "|#  ",
            "|#  ",
            "----"
        };

        private static string[] _finishFromUpToDown =
        {
            "|  |",
            "|  |",
            "|##|",
            "|--|"
        };
        
        private static string[] _finishFromDownToUp =
        {
            "|--|",
            "|##|",
            "|  |",
            "|  |"
        };

        #endregion

        private static int _x = 0;
        private static int _y = 0;
        
        public static void DrawTrack(Track track)
        {
            foreach (var section in track.Sections)
            {
                DrawSection(section);
                MoveCursor(section);
            }
        }

        private static void DrawSection(Section section)
        {
            if (section.SectionType == SectionTypes.StartGridFromLeftToRight) DrawGraphicArray(_startGridFromLeftToRight);
            else if (section.SectionType == SectionTypes.StartGridFromRightToLeft) DrawGraphicArray(_startGridFromRightToLeft);
            else if (section.SectionType == SectionTypes.StartGridFromUpToDown) DrawGraphicArray(_startGridFromUpToDown);
            else if (section.SectionType == SectionTypes.StartGridFromDownToUp) DrawGraphicArray(_startGridFromDownToUp);
            else if (section.SectionType == SectionTypes.StraightFromLeftToRight) DrawGraphicArray(_straightFromLeftToRight);
            else if (section.SectionType == SectionTypes.StraightFromRightToLeft) DrawGraphicArray(_straightFromRightToLeft);
            else if (section.SectionType == SectionTypes.StraightFromDownToUp) DrawGraphicArray(_straightFromDownToUp);
            else if (section.SectionType == SectionTypes.StraightFromUpToDown) DrawGraphicArray(_straightFromUpToDown);
            else if (section.SectionType == SectionTypes.TurnFromLeftToDown) DrawGraphicArray(_turnFromLeftToDown);
            else if (section.SectionType == SectionTypes.TurnFromDownToLeft) DrawGraphicArray(_turnFromDownToLeft);
            else if (section.SectionType == SectionTypes.TurnFromLeftToUp) DrawGraphicArray(_turnFromLeftToUp);
            else if (section.SectionType == SectionTypes.TurnFromUpToLeft) DrawGraphicArray(_turnFromUpToLeft);
            else if (section.SectionType == SectionTypes.TurnFromRightToDown) DrawGraphicArray(_turnFromRightToDown);
            else if (section.SectionType == SectionTypes.TurnFromDownToRight) DrawGraphicArray(_turnFromDownToRight);
            else if (section.SectionType == SectionTypes.TurnFromRightToUp) DrawGraphicArray(_turnFromRightToUp);
            else if (section.SectionType == SectionTypes.TurnFromUpToRight) DrawGraphicArray(_turnFromUpToRight);
            else if (section.SectionType == SectionTypes.FinishFromLeftToRight) DrawGraphicArray(_finishFromLeftToRight);
            else if (section.SectionType == SectionTypes.FinishFromRightToLeft) DrawGraphicArray(_finishFromRightToLeft);
            else if (section.SectionType == SectionTypes.FinishFromUpToDown) DrawGraphicArray(_finishFromUpToDown);
            else if (section.SectionType == SectionTypes.FinishFromDownToUp) DrawGraphicArray(_finishFromDownToUp);
        }

        private static void DrawGraphicArray(string[] graphicArray)
        {
            for (int i = 0; i < graphicArray.Length; i++)
            {
                Console.Write($"{graphicArray[i]}");
                Console.SetCursorPosition(_x, _y+=1);
            }
        }

        private static void MoveCursor(Section section)
        {
            if (
                section.SectionType == SectionTypes.FinishFromDownToUp ||
                section.SectionType == SectionTypes.StraightFromDownToUp ||
                section.SectionType == SectionTypes.TurnFromLeftToUp ||
                section.SectionType == SectionTypes.TurnFromRightToUp ||
                section.SectionType == SectionTypes.StartGridFromDownToUp
            )
            {
                _y -= 8;
            } 
            else if (
                section.SectionType == SectionTypes.FinishFromLeftToRight ||
                section.SectionType == SectionTypes.StraightFromLeftToRight ||
                section.SectionType == SectionTypes.TurnFromDownToRight ||
                section.SectionType == SectionTypes.TurnFromUpToRight ||
                section.SectionType == SectionTypes.StartGridFromLeftToRight)
            {
                _x += 4;
                _y -= 4;
            }
            else if (
                section.SectionType == SectionTypes.FinishFromUpToDown ||
                section.SectionType == SectionTypes.StraightFromUpToDown ||
                section.SectionType == SectionTypes.TurnFromLeftToDown ||
                section.SectionType == SectionTypes.TurnFromRightToDown ||
                section.SectionType == SectionTypes.StartGridFromUpToDown
            ){}
                else if (
                section.SectionType == SectionTypes.FinishFromRightToLeft ||
                section.SectionType == SectionTypes.StraightFromRightToLeft ||
                section.SectionType == SectionTypes.TurnFromDownToLeft ||
                section.SectionType == SectionTypes.TurnFromUpToLeft ||
                section.SectionType == SectionTypes.StartGridFromRightToLeft
            )
            {
                _x -= 4;
                _y -= 4;
            }
            Console.SetCursorPosition(_x, _y);
        }
    }
}