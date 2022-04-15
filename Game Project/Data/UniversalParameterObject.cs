
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class UniversalParameterObject
    {
        private Dictionary<string, object> parameters;

        public Vector2 Position => (Vector2)parameters["Position"];
        public bool FacingRight => (bool)parameters["FacingRight"];
        public string AnimationName => parameters["Animation"].ToString();

        // Change this to having multiple constructors, each one for a different type of object
        public UniversalParameterObject(Dictionary<string, object> parameters)
        {
            this.parameters = parameters;
        }

    }
}
