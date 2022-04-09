using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IItem : IGameObject, IUpdateable, IDrawable, ICollideable
    {
        //  no item specific methods rn
    }
}
