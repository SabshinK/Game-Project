using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public interface IGameObject : IUpdateable, IDrawable
    {
        public Vector2 GridPosition { get; }
        public Vector2 Position { get; }
    }
}
