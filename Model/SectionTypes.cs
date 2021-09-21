using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    // 0 exits up
    // 1 exits right
    // 2 exits down
    // 3 exits left
    public enum SectionTypes
    {
        StartGridFromUpToDown,
        StartGridFromDownToUp,
        StartGridFromLeftToRight,
        StartGridFromRightToLeft,
        StraightFromUpToDown,
        StraightFromDownToUp,
        StraightFromLeftToRight,
        StraightFromRightToLeft,
        TurnFromLeftToUp,
        TurnFromUpToLeft,
        TurnFromRightToUp,
        TurnFromUpToRight,
        TurnFromDownToRight,
        TurnFromRightToDown,
        TurnFromLeftToDown,
        TurnFromDownToLeft,
        FinishFromUpToDown,
        FinishFromDownToUp,
        FinishFromLeftToRight,
        FinishFromRightToLeft,
    }
}
