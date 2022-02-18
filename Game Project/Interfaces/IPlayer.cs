using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Interfaces
{
    internal interface IPlayer
    {
        public void BackToIdleRight();
        public void BackToIdleLeft();
        public void Update(); //both move left and moveRight would need to implement this. 
    }
}
