using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Tile
    {
        Vector2 position;
        ISprite sprite;

        public Tile(UniversalParameterObject parameters)
        {
            position = parameters.Position;
        }
    }
}
