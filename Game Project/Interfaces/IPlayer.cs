﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IPlayer : IGameObject, IMoveable, IUpdateable, IDrawable, ICollideable
    {
        // Might have this be a GameObject thing but I'm not sure yet if that's really necessary
        public int Health { get; }

        public void Bump(Rectangle collision, int direction);
    }
}
