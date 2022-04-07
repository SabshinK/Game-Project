using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public interface IMoveable
    {
        // Objects that are moveable likely have a direction. There are cases in some games where objects not capable of
        // movmement have directions but this is not the case in our project
        public bool FacingRight { get; }
    }
}
