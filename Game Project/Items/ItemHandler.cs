using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class ItemHandler
    {
        private IPlayer player;
        private ItemScroller itemScroller;

        private Dictionary<string, Action> itemFunctions;

        public ItemHandler()
        {
            player = GameObjectManager.Instance.GetPlayer();

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
                    GameObjectManager.RegisterObject(new SwordBeam(new UniversalParameterObject(player.Position, player.FacingRight)));
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
    }
}