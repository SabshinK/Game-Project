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
        public string AnimationName { get; private set; }

        public UniversalParameterObject(object[] parameters)
        {
            if (parameters[0] != null)
                Position = (Vector2)parameters[0];
            if (parameters[1] != null)
                Direction = (bool)parameters[1];
            if (parameters[2] != null)
                AnimationName = parameters[2].ToString();
        }
    }
}
