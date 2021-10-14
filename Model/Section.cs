using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Model
{
    public class Section
    {
        public SectionType SectionType { get; }
        public Direction IncomingDirection { get; }
        public Direction OutgoingDirection { get;}
        public SectionData SectionData { get; set; }
        public Path LeftPath { get; }
        public Path RightPath { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public Section(Direction incomingDirection, Direction outgoingDirection, SectionType sectionType)
        {
            IncomingDirection = incomingDirection;
            OutgoingDirection = outgoingDirection;
            SectionType = sectionType;
            SectionData = new SectionData();
            LeftPath = new Path();
            RightPath = new Path();
            SetPaths(incomingDirection, outgoingDirection);
        }

        private void SetPaths(Direction incomingDirection, Direction outgoingDirection)
        {
            if (incomingDirection == Direction.Left && outgoingDirection == Direction.Right)
            {
                // LeftPath.X = new int[4] {0,1,2,3};
                // LeftPath.Y = new int[4] {1,1,1,1};
                // RightPath.X = new int[4] {0,1,2,3};
                // RightPath.Y = new int[4] {2,2,2,2};
                LeftPath.X = new int[4] {0,25,50,75};
                LeftPath.Y = new int[4] {25,25,25,25};
                RightPath.X = new int[4] {0,25,50,75};
                RightPath.Y = new int[4] {50,50,50,50}; 
            }

            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Left)
            {
                // LeftPath.X = new int[4] {3,2,1,0};
                // LeftPath.Y = new int[4] {2,2,2,2};
                // RightPath.X = new int[4] {3,2,1,0};
                // RightPath.Y = new int[4] {1,1,1,1};
                LeftPath.X = new int[4] {75,50,25,0};
                LeftPath.Y = new int[4] {50,50,50,50};
                RightPath.X = new int[4] {75,50,25,0};
                RightPath.Y = new int[4] {25,25,25,25};
            }
            
            else if (incomingDirection == Direction.Up && outgoingDirection == Direction.Down)
            {
                // LeftPath.X = new int[4] {2,2,2,2};
                // LeftPath.Y = new int[4] {0,1,2,3};
                // RightPath.X = new int[4] {1,1,1,1};
                // RightPath.Y = new int[4] {0,1,2,3};
                LeftPath.X = new int[4] {50,50,50,50};
                LeftPath.Y = new int[4] {0,25,50,75};
                RightPath.X = new int[4] {25,25,25,25};
                RightPath.Y = new int[4] {0,25,50,75};
            }
            
            else if (incomingDirection == Direction.Down && outgoingDirection == Direction.Up)
            {
                // LeftPath.X = new int[4] {1,1,1,1};
                // LeftPath.Y = new int[4] {3,2,1,0};
                // RightPath.X = new int[4] {2,2,2,2};
                // RightPath.Y = new int[4] {3,2,1,0};
                LeftPath.X = new int[4] {25,25,25,25};
                LeftPath.Y = new int[4] {75,50,25,0};
                RightPath.X = new int[4] {50,50,50,50};
                RightPath.Y = new int[4] {75,50,25,0};
            }
            
            // else if (incomingDirection == Direction.Left && outgoingDirection == Direction.Up)
            // {
            //     LeftPath.X = new int[4] {};
            //     LeftPath.Y = new int[4] {};
            //     RightPath.X = new int[4] {};
            //     RightPath.Y = new int[4] {};
            // }
            else if (incomingDirection == Direction.Up && outgoingDirection == Direction.Left)
            {
                // LeftPath.X = new int[4] {2,2,1,0};
                // LeftPath.Y = new int[4] {0,1,2,2};
                // RightPath.X = new int[4] {1,1,0,0};
                // RightPath.Y = new int[4] {0,1,1,1};
                LeftPath.X = new int[4] {50,50,25,0};
                LeftPath.Y = new int[4] {0,25,50,50};
                RightPath.X = new int[4] {25,25,0,0};
                RightPath.Y = new int[4] {0,25,25,25};
            }
            
            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Up)
            {
                // LeftPath.X = new int[4] {3,2,1,1};
                // LeftPath.Y = new int[4] {2,2,1,0};
                // RightPath.X = new int[4] {3,2,2,2};
                // RightPath.Y = new int[4] {1,1,0,0};
                LeftPath.X = new int[4] {75,50,25,25};
                LeftPath.Y = new int[4] {50,50,25,0};
                RightPath.X = new int[4] {75,50,50,50};
                RightPath.Y = new int[4] {25,25,0,0};
            }
            else if(incomingDirection == Direction.Up && outgoingDirection == Direction.Right)
            {
                // LeftPath.X = new int[4] {2,2,3,3};
                // LeftPath.Y = new int[4] {0,1,1,1};
                // RightPath.X = new int[4] {1,1,2,3};
                // RightPath.Y = new int[4] {0,1,2,2};
                LeftPath.X = new int[4] {50,50,75,75};
                LeftPath.Y = new int[4] {0,25,25,25};
                RightPath.X = new int[4] {25,25,50,75};
                RightPath.Y = new int[4] {0,25,50,50};
            }
            
            else if (incomingDirection == Direction.Right && outgoingDirection == Direction.Down)
            {
                // LeftPath.X = new int[4] {2,2,1,1};
                // LeftPath.Y = new int[4] {3,2,2,2};
                // RightPath.X = new int[4] {3,2,1,1};
                // RightPath.Y = new int[4] {1,1,2,3};
                LeftPath.X = new int[4] {75,50,50,50};
                LeftPath.Y = new int[4] {50,50,75,75};
                RightPath.X = new int[4] {75,50,25,25};
                RightPath.Y = new int[4] {25,25,50,75};
            } 
            else if (incomingDirection == Direction.Down && outgoingDirection == Direction.Right)
            {
                // LeftPath.X = new int[4] {1,1,2,3};
                // LeftPath.Y = new int[4] {3,2,1,1};
                // RightPath.X = new int[4] {2,2,3,3};
                // RightPath.Y = new int[4] {3,2,2,2};
                LeftPath.X = new int[4] {25,25,50,75};
                LeftPath.Y = new int[4] {75,50,25,25};
                RightPath.X = new int[4] {50,50,75,75};
                RightPath.Y = new int[4] {75,50,50,50};
            }
            
            else if (incomingDirection == Direction.Left && outgoingDirection == Direction.Down)
            {
                // LeftPath.X = new int[4] {0,1,2,2};
                // LeftPath.Y = new int[4] {1,1,2,3};
                // RightPath.X = new int[4] {0,1,1,1};
                // RightPath.Y = new int[4] {2,2,2,3};
                LeftPath.X = new int[4] {0,25,50,50};
                LeftPath.Y = new int[4] {25,25,50,75};
                RightPath.X = new int[4] {0,25,25,25};
                RightPath.Y = new int[4] {50,50,50,75};
            }
            // else if (incomingDirection == Direction.Down && outgoingDirection == Direction.Left)
            // {
            //     LeftPath.X = new int[4] {};
            //     LeftPath.Y = new int[4] {};
            //     RightPath.X = new int[4] {};
            //     RightPath.Y = new int[4] {};
            // }
        }
    }
}
