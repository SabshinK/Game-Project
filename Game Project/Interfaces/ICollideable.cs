using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface ICollideable
    {
        // Objects that collide must know their size for the CollisionDetection class to access
        public Vector2 Size { get; }

        public void Collide();
    }
}
