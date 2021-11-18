using System;
using System;
using System.Collections.Generic;
using System.Linq;


class undoRedo
{
    List<Canvas> states = new List<Canvas>();
    public undoRedo(Canvas baseCanvas)
    {
        states.Add(baseCanvas);
    }


}

