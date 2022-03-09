using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class UniversalParameterObject
    {
        public Vector2 Position { get; private set; }

        public UniversalParameterObject(Vector2 position)
        {
            Position = position;
        }
    }
}
