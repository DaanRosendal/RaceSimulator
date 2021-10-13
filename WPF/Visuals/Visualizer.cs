using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
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

        private static int _x;
        private static int _y;
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
        
        public static void MoveParticipants(Track track)
        {
            for (var node = track.Sections.Last; node != null; node = node.Previous)
            {
                var currentSection = node.Value;
                Section nextSection;
                
                // Assign next section
                if (node.Next == null)
                {
                    nextSection = track.Sections.First.Value;
                }
                else
                {
                    nextSection = node.Next.Value;
                }

                // Move right participant
                if (currentSection.SectionData.RightParticipant != null)
                {
                    if (!currentSection.SectionData.RightParticipant.Equipment.IsBroken)
                    {
                        currentSection.SectionData.RightParticipant.previousSection = currentSection;
                        var nextPosition = currentSection.SectionData.RightParticipant.Equipment.Speed +
                                           currentSection.SectionData.DistanceRight;
                        // Check if participant must be moved to next section
                        if (nextPosition > 3)
                        {
                            if (nextSection.SectionData.RightParticipant == null)
                            {
                                nextSection.SectionData.RightParticipant = currentSection.SectionData.RightParticipant;
                                nextSection.SectionData.DistanceRight = nextPosition - 4;

                                currentSection.SectionData.RightParticipant = null;
                                currentSection.SectionData.DistanceRight = 0;
                            }
                            else if (nextSection.SectionData.LeftParticipant == null)
                            {
                                // Overtake if participant is faster than participant ahead
                                var driverSpeed = currentSection.SectionData.RightParticipant.Equipment.Speed;
                                var driverAheadSpeed = nextSection.SectionData.RightParticipant.Equipment.Speed;
                                if (driverSpeed > driverAheadSpeed)
                                {
                                    nextSection.SectionData.LeftParticipant =
                                        currentSection.SectionData.RightParticipant;
                                    nextSection.SectionData.DistanceLeft = nextPosition - 4;

                                    currentSection.SectionData.RightParticipant = null;
                                    currentSection.SectionData.DistanceRight = 0;
                                }
                            }
                        }
                        else
                        {
                            currentSection.SectionData.DistanceRight = nextPosition;
                        }
                    }
                }

                // Move left participant
                if (currentSection.SectionData.LeftParticipant != null)
                {
                    if (!currentSection.SectionData.LeftParticipant.Equipment.IsBroken)
                    {
                        currentSection.SectionData.LeftParticipant.previousSection = currentSection;
                        var nextPosition = currentSection.SectionData.LeftParticipant.Equipment.Speed +
                                           currentSection.SectionData.DistanceLeft;
                        // Check if participant must be moved to next section
                        if (nextPosition > 3)
                        {
                            if (nextSection.SectionData.LeftParticipant == null)
                            {
                                // Move from left to right lane if right is empty
                                if (nextSection.SectionData.RightParticipant == null)
                                {
                                    nextSection.SectionData.RightParticipant =
                                        currentSection.SectionData.LeftParticipant;
                                    nextSection.SectionData.DistanceRight = nextPosition - 4;
                                }
                                else
                                {
                                    nextSection.SectionData.LeftParticipant =
                                        currentSection.SectionData.LeftParticipant;
                                    nextSection.SectionData.DistanceLeft = nextPosition - 4;
                                }

                                currentSection.SectionData.LeftParticipant = null;
                                currentSection.SectionData.DistanceLeft = 0;
                            }
                        }
                        else
                        {
                            // Move from left to right if right is empty
                            if (currentSection.SectionData.RightParticipant == null)
                            {
                                currentSection.SectionData.RightParticipant =
                                    currentSection.SectionData.LeftParticipant;
                                currentSection.SectionData.DistanceRight = nextPosition;

                                currentSection.SectionData.LeftParticipant = null;
                                currentSection.SectionData.DistanceLeft = 0;
                            }
                            else
                            {
                                currentSection.SectionData.DistanceLeft = nextPosition;
                            }
                        }
                    }
                }
            }
        }
        
        public static void RenderParticipants(Track track)
        {
            // Show participant at next position
            for (var node = track.Sections.First; node != null; node = node.Next)
            {
                var section = node.Value;

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

            PropertyChanged("", new PropertyChangedEventArgs(""));
        }

        public static event PropertyChangedEventHandler PropertyChanged = delegate {};

        public static BitmapSource GetTrack()
        {
            return BitmapImages.CreateBitmapSourceFromGdiBitmap(_emptyBitmap);
        }
    }
}