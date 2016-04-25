using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Domain
{
    interface ICaptureMove
    {
        void Capture(int newX, int newY);
    }
}
