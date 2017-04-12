using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Enums
{
    public enum Buttons
    {
        Brackets = -9,
        Cancel = -8,
        Delete = -7,
        Divide = -6,
        Multiply = -5,
        PlusMinus = -4,
        Minus = -3,
        Plus = -2,
        Equals = -1,
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Comma = 10
    }

    public enum ButtonType
    {
        Number = 0,
        Operator = 1,
        Helper = 2,
        Equals = 4
    }
}
