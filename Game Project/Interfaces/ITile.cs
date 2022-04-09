using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface ITile : IGameObject, IUpdateable, IDrawable, ICollideable
    {
        //  no tile specific methods rn
    }
}
