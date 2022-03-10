using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class UniversalParameterObject
    {
        public Vector2 Position { get; private set; }
        public bool Direction { get; private set; }

        public UniversalParameterObject(object[] parameters)
        {
            
        }
    }
}
