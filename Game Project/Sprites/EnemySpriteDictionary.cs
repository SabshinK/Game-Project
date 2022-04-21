using System;
using System.Collections.Generic;
using System.Text;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project.Sprites
{
    class EnemySpriteDictionary
    {

        Dictionary<Tuple<String, Tuple<actions, bool>>, ISprite> spriteDictionary = new Dictionary<Tuple<String, Tuple<actions, bool>>, ISprite>();
        public EnemySpriteDictionary()
        {
            //Bat Sprites
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Bat", new Tuple<actions, bool>(actions.moving, true)), SpriteFactory.Instance.CreateSprite("beeMovingRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Bat", new Tuple<actions, bool>(actions.moving, false)), SpriteFactory.Instance.CreateSprite("beeMovingLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Bat", new Tuple<actions, bool>(actions.damaged, true)), SpriteFactory.Instance.CreateSprite("beeDamagedRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Bat", new Tuple<actions, bool>(actions.damaged, false)), SpriteFactory.Instance.CreateSprite("beeDamagedLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Bat", new Tuple<actions, bool>(actions.dead, true)), SpriteFactory.Instance.CreateSprite("beeDeadRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Bat", new Tuple<actions, bool>(actions.dead, false)), SpriteFactory.Instance.CreateSprite("beeDeadLeft"));

            //Gel Sprites
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Gel", new Tuple<actions, bool>(actions.moving, true)), SpriteFactory.Instance.CreateSprite("gelMovingRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Gel", new Tuple<actions, bool>(actions.moving, false)), SpriteFactory.Instance.CreateSprite("gelMovingLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Gel", new Tuple<actions, bool>(actions.damaged, true)), SpriteFactory.Instance.CreateSprite("gelDamagedRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Gel", new Tuple<actions, bool>(actions.damaged, false)), SpriteFactory.Instance.CreateSprite("gelDamagedLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Gel", new Tuple<actions, bool>(actions.dead, true)), SpriteFactory.Instance.CreateSprite("gelDeadRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Gel", new Tuple<actions, bool>(actions.dead, false)), SpriteFactory.Instance.CreateSprite("gelDeadLeft"));

            //Shroomling Sprites
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Shroomling", new Tuple<actions, bool>(actions.moving, true)), SpriteFactory.Instance.CreateSprite("shroomlingMovingRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Shroomling", new Tuple<actions, bool>(actions.moving, false)), SpriteFactory.Instance.CreateSprite("shroomlingMovingLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Shroomling", new Tuple<actions, bool>(actions.damaged, true)), SpriteFactory.Instance.CreateSprite("shroomlingDamagedRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Shroomling", new Tuple<actions, bool>(actions.damaged, false)), SpriteFactory.Instance.CreateSprite("shroomlingDamagedLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Shroomling", new Tuple<actions, bool>(actions.dead, true)), SpriteFactory.Instance.CreateSprite("shroomlingDeadRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Shroomling", new Tuple<actions, bool>(actions.dead, false)), SpriteFactory.Instance.CreateSprite("shroomlingDeadLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Shroomling", new Tuple<actions, bool>(actions.attacking, true)), SpriteFactory.Instance.CreateSprite("shroomlingIdleRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Shroomling", new Tuple<actions, bool>(actions.attacking, false)), SpriteFactory.Instance.CreateSprite("shroomlingIdleLeft"));

            //Slug Sprites
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Slug", new Tuple<actions, bool>(actions.moving, true)), SpriteFactory.Instance.CreateSprite("slugMovingRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Slug", new Tuple<actions, bool>(actions.moving, false)), SpriteFactory.Instance.CreateSprite("slugMovingLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Slug", new Tuple<actions, bool>(actions.damaged, true)), SpriteFactory.Instance.CreateSprite("slugDamagedRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Slug", new Tuple<actions, bool>(actions.damaged, false)), SpriteFactory.Instance.CreateSprite("slugDamagedLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Slug", new Tuple<actions, bool>(actions.dead, true)), SpriteFactory.Instance.CreateSprite("slugDeadRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Slug", new Tuple<actions, bool>(actions.dead, false)), SpriteFactory.Instance.CreateSprite("slugDeadLeft"));

            //Dragon Sprites
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Dragon", new Tuple<actions, bool>(actions.moving, true)), SpriteFactory.Instance.CreateSprite("dragonMovingRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Dragon", new Tuple<actions, bool>(actions.moving, false)), SpriteFactory.Instance.CreateSprite("dragonMovingLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Dragon", new Tuple<actions, bool>(actions.damaged, true)), SpriteFactory.Instance.CreateSprite("dragonDamagedRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Dragon", new Tuple<actions, bool>(actions.damaged, false)), SpriteFactory.Instance.CreateSprite("dragonDamagedLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Dragon", new Tuple<actions, bool>(actions.dead, true)), SpriteFactory.Instance.CreateSprite("dragonDeadRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Dragon", new Tuple<actions, bool>(actions.dead, false)), SpriteFactory.Instance.CreateSprite("dragonDeadLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Dragon", new Tuple<actions, bool>(actions.attacking, true)), SpriteFactory.Instance.CreateSprite("dragonAttackingRight")); //these strings may need to change
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Dragon", new Tuple<actions, bool>(actions.attacking, false)), SpriteFactory.Instance.CreateSprite("dragonAttackingLeft"));

            //Skeleton Sprites
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Skeleton", new Tuple<actions, bool>(actions.moving, true)), SpriteFactory.Instance.CreateSprite("skeletonMovingRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Skeleton", new Tuple<actions, bool>(actions.moving, false)), SpriteFactory.Instance.CreateSprite("skeletonMovingLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Skeleton", new Tuple<actions, bool>(actions.damaged, true)), SpriteFactory.Instance.CreateSprite("skeletonDamagedRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Skeleton", new Tuple<actions, bool>(actions.damaged, false)), SpriteFactory.Instance.CreateSprite("skeletonDamagedLeft"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Skeleton", new Tuple<actions, bool>(actions.dead, true)), SpriteFactory.Instance.CreateSprite("skeletonDeadRight"));
            spriteDictionary.Add(new Tuple<string, Tuple<actions, bool>>("Skeleton", new Tuple<actions, bool>(actions.dead, false)), SpriteFactory.Instance.CreateSprite("skeletonDeadLeft"));
        }


        public ISprite GetEnemySprite(String enemy, Tuple<actions, bool> stateTuple)
        {
            return spriteDictionary[new Tuple<string, Tuple<actions, bool>>(enemy, stateTuple)];
        }

    }
}
