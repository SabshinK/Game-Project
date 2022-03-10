using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class CollisionDetection : ICollideable
    {
        // collideDirection is side of block that collides with player
        private Player player;

        public CollisionDetection(Player Player)
        {
            player = Player;            
        }

        public void Collide(ICollideable Block, ICollideable Direction)
        {
            // i literally have no idea what this is supposed to do or how to do it
            // trying to send to collision resolution
            CollisionResolution collision = new CollisionResolution(player, Block, Direction);
            collision.Collide();
        }

        public void Update(?)
        {
            int player_top = player.location.y;
            int player_bottom = player.location.y + player.size.height;
            int player_left = player.location.x;
            int player_right = player.location.x + player.size.width;
            int block_top = block.location.y;
            int block_bottom = block.location.y + block.size.height;
            int block_left = block.location.x;
            int block_right = block.location.x + block.size.width;

            if !(player_right<block_left || block_right<player_left || player_bottom<block_top || block_bottom < player_top)
            {
                if (player_right >= block_left)
                {
                    // left overlap (right side of player)
                    side_overlap = player_right - block_left;
                    direction = LEFT;
                }
                else
                {
                    // right overlap (left side of player)
                    side_overlap = block_right - player_left;
                    direction = RIGHT;
                }

                if(player_top <= block_bottom) {
                    // bottom overlap (top side of player)
                    updown_overlap = block_bottom - player_top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = BOTTTOM;
                    }
                }
                else
                {
                    // top overlap (bottom side of player)
                    updown_overlap = player_bottom - block_top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = BOTTTOM;
                    }
                }

                Collide(player, block, direction);

            }
        }
    }
}
