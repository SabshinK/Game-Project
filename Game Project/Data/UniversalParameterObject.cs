
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class UniversalParameterObject
    {
        public Vector2 Position { get; private set; }
        public bool FacingRight { get; private set; }
        public string AnimationName { get; private set; }

        // Constructor that LevelLoader uses
        public UniversalParameterObject(Dictionary<string, object> parameters)
        {
            object value;
            parameters.TryGetValue("Position", out value);
            Position = (Vector2)value;

            parameters.TryGetValue("FacingRight", out value);
            FacingRight = (bool)value;

            parameters.TryGetValue("Animation", out value);
            AnimationName = (string)value;
        }

        // Enemy constructor
        public UniversalParameterObject(Vector2 position)
        {
            Position = position;
        }

        // Projectile constructor
        public UniversalParameterObject(Vector2 position, bool facingRight)
        {
            Position = position;
            FacingRight = facingRight;
        }

        // Tile/Item/Background constructor
        public UniversalParameterObject(Vector2 position, string animation)
        {
            Position = position;
            AnimationName = animation;
        }
    }
}
