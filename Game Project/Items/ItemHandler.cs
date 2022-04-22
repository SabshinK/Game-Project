using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class ItemHandler : IItem
    {
        private Player player;
        public bool FacingRight { get; set; }
        private Vector2 position;
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public int Health { get; set; }
        private ItemScroller itemScroller;
        private List<String> items;
        private string currItem;

        public ItemHandler()
        {
            items = itemScroller.items;
            currItem = itemScroller.currItem;
            Health = Player.Health;
        }
        //Returns the item which was picked to 
        // heals player for the triangle
        public HealPlayer()
        {
            Player.Health = 4; // set player's health to 4
        }

        public void DecideItem()
        {
            // need access to the items list from ItemScroller!
            //guitar is swordBeam
            //accordian is boomerang
            // harp is bow
            //drum is bomb
            //flute is candle
            //triangle is calling heal player up to 4 hearts
            //Order: guitar, accordian, flute, drum, harp, triangle
            switch (items.IndexOf(currItem)) //ItemsList is the list I should be able to access from ItemScroller;
            {
                case 1:
                    GameObjectManager.RegisterObject(new SwordBeam(new UniversalParameterObject(player.position, FacingRight)));
                    break;
                case 2:
                    GameObjectManager.RegisterObject(new Boomerang(new UniversalParameterObject(player.position, FacingRight)));
                    break ;
                case 3:
                    GameObjectManager.RegisterObject(new Candle(new UniversalParameterObject(player.position, FacingRight)));
                    break;
                case 4:
                    GameObjectManager.RegisterObject(new Bomb(new UniversalParameterObject(player.position, FacingRight)));
                    break;
                case 5:
                    GameObjectManager.RegisterObject(new Arrow(new UniversalParameterObject(player.position, FacingRight)));
                    break;
                case 6:
                    HealPlayer();
                    break;
                default:
                    break;
            }
        }
        
        public void Update(GameTime gameTime)
        {
            DecideItem();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

    }
}