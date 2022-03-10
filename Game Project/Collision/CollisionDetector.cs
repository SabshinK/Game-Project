using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class CollisionDetector : ICollideable, IUpdateable
    {
        private Player player;
        private Object block; // type?
        private ICollideable direction; // type?
        private int player_top;
        private int player_bottom;
        private int player_left;
        private int player_right;
        private int block_top;
        private int block_bottom;
        private int block_left;
        private int block_right;
        CollisionResolution collisionResolution; // -> Rachel what is this for?

        public CollisionDetector(Player Player, Object Block)
        {
            player = Player;
            block = Block;
            direction = null; // is this bad? i just feel weird about not defining direction outside of an if-else statement in Update()
            player_top = player.location.y;
            player_bottom = player.location.y + player.size.height;
            player_left = player.location.x;
            player_right = player.location.x + player.size.width;
            block_top = block.location.y;
            block_bottom = block.location.y + block.size.height;
            block_left = block.location.x;
            block_right = block.location.x + block.size.width;

            Update();
        }

        public void Collide()
        {
            
            collisionResolution = new CollisionResolution(player, block, direction); // am i supposed to do anything else with this?

        }

        public void Update()
        {
            // objects collide:
            if !(player_right < block_left || block_right < player_left || player_bottom < block_top || block_bottom < player_top)
            {
                if (player_right >= block_left)
                {
                    // left overlap (right side of player):
                    side_overlap = player_right - block_left;
                    direction = LEFT;
                }
                else
                {
                    // right overlap (left side of player):
                    side_overlap = block_right - player_left;
                    direction = RIGHT;
                }

                if (player_top <= block_bottom)
                {
                    // bottom overlap (top side of player):
                    updown_overlap = block_bottom - player_top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = BOTTTOM;
                    }
                }
                else
                {
                    // top overlap (bottom side of player):
                    updown_overlap = player_bottom - block_top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = TOP;
                    }
                }

                Collide(player, block, direction);

            }

        }       
    }
}
