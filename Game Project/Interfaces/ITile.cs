﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface ITile : IGameObject, IDrawable, ICollideable
    {
        //  no tile specific methods rn
    }
}
