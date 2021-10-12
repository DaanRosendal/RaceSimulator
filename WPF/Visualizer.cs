using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using Controller;
using Model;

namespace WPF
{
    public static class Visualizer
    {
        #region Graphics

        public const string StartFromLeftToRight = "C:\\RaceSimImages\\Sections\\startFromLeftToRight.png";
        public const string StartFromRightToLeft = StartFromLeftToRight;
        public const string StartFromUpToDown = "C:\\RaceSimImages\\Sections\\startFromDownToUp.png";
        public const string StartFromDownToUp = StartFromUpToDown;

        public const string StraightFromLeftToRight = "C:\\RaceSimImages\\Sections\\straightFromLeftToRight.png";
        public const string StraightFromRightToLeft = StraightFromLeftToRight;
        public const string StraightFromUpToDown = "C:\\RaceSimImages\\Sections\\straightFromDownToUp.png";
        public const string StraightFromDownToUp = StraightFromUpToDown;

        public const string TurnFromLeftToDown = "C:\\RaceSimImages\\Sections\\turnFromLeftToDown.png";
        public const string TurnFromDownToLeft = TurnFromLeftToDown;
        public const string TurnFromRightToDown = "C:\\RaceSimImages\\Sections\\turnFromRightToDown.png";
        public const string TurnFromDownToRight = TurnFromRightToDown;
        public const string TurnFromUpToLeft = "C:\\RaceSimImages\\Sections\\turnFromUpToLeft.png";
        public const string TurnFromLeftToUp = TurnFromUpToLeft;
        public const string TurnFromUpToRight = "C:\\RaceSimImages\\Sections\\turnFromUpToRight.png";
        public const string TurnFromRightToUp = TurnFromUpToRight;

        public const string FinishFromLeftToRight = "C:\\RaceSimImages\\Sections\\finishFromLeftToRight.png";
        public const string FinishFromRightToLeft = FinishFromLeftToRight;
        public const string FinishFromUpToDown = "C:\\RaceSimImages\\Sections\\finishFromDownToUp.png";
        public const string FinishFromDownToUp = FinishFromUpToDown;
        
        #endregion

        private static int _x = 0;
        private static int _y = 0;
        private static Bitmap _emptyBitmap;
        private static Graphics _emptyBitmapGraphics;
        
        public static void DrawTrack(Track track)
        {
            _emptyBitmap = BitmapImages.GetEmptyBitmap(
                Data.CurrentRace.Track.GetWidthInPx(),
                Data.CurrentRace.Track.GetWidthInPx()
            );
            _emptyBitmapGraphics = Graphics.FromImage(_emptyBitmap);
            
            foreach (var section in track.Sections)
            {
                DrawSection(section);
                UpdateCoordinatesForNextSection(section);
            }
        }

        private static void DrawSection(Section section)
        {
            var sectionType = section.SectionType;
            var incomingDirection = section.IncomingDirection;
            var outgoingDirection = section.OutgoingDirection;
            section.X = _x;
            section.Y = _y;
            
            if (incomingDirection == Direction.Left && outgoingDirection == Direction.Right)
            {
                if (sectionType == SectionType.Start) DrawSectionImage(StartFromLeftToRight);
                else if (sectionType == SectionType.Straight) DrawSectionImage(StraightFromLeftToRight);
                else if (sectionType == SectionType.Finish) DrawSectionImage(FinishFromLeftToRight);
            }

            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Left) {
                if (sectionType == SectionType.Start) DrawSectionImage(StartFromRightToLeft);
                else if (sectionType == SectionType.Straight) DrawSectionImage(StraightFromRightToLeft);
                else if (sectionType == SectionType.Finish) DrawSectionImage(FinishFromRightToLeft);
            }

            else if (incomingDirection == Direction.Up && outgoingDirection == Direction.Down)
            {
                if (sectionType == SectionType.Start) DrawSectionImage(StartFromUpToDown);
                else if (sectionType == SectionType.Straight) DrawSectionImage(StraightFromUpToDown);
                else if (sectionType == SectionType.Finish) DrawSectionImage(FinishFromUpToDown);
            }
            
            else if (incomingDirection == Direction.Down && outgoingDirection == Direction.Up)
            {
                if (sectionType == SectionType.Start) DrawSectionImage(StartFromDownToUp);
                else if (sectionType == SectionType.Straight) DrawSectionImage(StraightFromDownToUp);
                else if (sectionType == SectionType.Finish) DrawSectionImage(FinishFromDownToUp);
            }

            else if (incomingDirection == Direction.Left && outgoingDirection == Direction.Up ||
                     incomingDirection == Direction.Up && outgoingDirection == Direction.Left)
            {
                DrawSectionImage(TurnFromLeftToUp);
            }

            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Up ||
                     incomingDirection == Direction.Up && outgoingDirection == Direction.Right)
            {
                DrawSectionImage(TurnFromUpToRight);
            }
            
            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Down ||
                     incomingDirection == Direction.Down && outgoingDirection == Direction.Right)
            {
                DrawSectionImage(TurnFromRightToDown);
            }
            
            else if (incomingDirection == Direction.Left && outgoingDirection == Direction.Down ||
                     incomingDirection == Direction.Down && outgoingDirection == Direction.Left)
            {
                DrawSectionImage(TurnFromDownToLeft);
            }
        }

        private static void DrawSectionImage(string url)
        {
            var sectionBitmap = BitmapImages.AddImageToCache(url);
            _emptyBitmapGraphics.DrawImage(sectionBitmap, new PointF(_x, _y));
        }
        
        private static void UpdateCoordinatesForNextSection(Section section)
        {
            switch (section.OutgoingDirection)
            {
                case Direction.Up:
                    _y -= 100;
                    break;
                case Direction.Right:
                    _x += 100;
                    break;
                case Direction.Left:
                    _x -= 100;
                    break;
                case Direction.Down:
                    _y += 100;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public static void DrawParticipantsInStartPosition(Track track)
        {
            foreach (var section in track.Sections)
            {
                if (section.SectionData.LeftParticipant != null)
                {
                    var participantIconPath = section.SectionData.LeftParticipant.GetTeamColorAsIcon();
                    
                    _emptyBitmapGraphics.DrawImage(
                        new Bitmap(participantIconPath), 
                        new PointF(
                            section.X + section.LeftPath.X[section.SectionData.DistanceLeft], 
                            section.Y + section.LeftPath.Y[section.SectionData.DistanceLeft]
                        )
                    );
                }

                if (section.SectionData.RightParticipant != null)
                {
                    var participantIconPath = section.SectionData.RightParticipant.GetTeamColorAsIcon();
                    
                    _emptyBitmapGraphics.DrawImage(
                        new Bitmap(participantIconPath), 
                        new PointF(
                            section.X + section.RightPath.X[section.SectionData.DistanceRight], 
                            section.Y + section.RightPath.Y[section.SectionData.DistanceRight]
                        )
                    );
                }
            }
        }

        public static BitmapSource GetTrack()
        {
            return BitmapImages.CreateBitmapSourceFromGdiBitmap(_emptyBitmap);
        }
    }
}