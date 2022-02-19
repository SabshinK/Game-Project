using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public interface IProjectile
    {
        public void Update(GameTime gameTime);
        public void Draw();
    }
}
