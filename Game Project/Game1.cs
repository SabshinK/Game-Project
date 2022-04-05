using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Project
{
    // Names: Sebastian King, Rachel Watters, AJ Waizmann, Maria Stein, Aadya Jain, and Anooj Deshpande
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        // Interfaces to use
        public IController keyboard;
        public IController mouse;
        private CollisionDetection collisionDetection;
        private CollisionResolution collisionResolution;
        private Camera camera;
        //public Player player;
        //public TileManager tiles;
        //public EnemyManager enemies;
        //public ItemManager items;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            keyboard = new KeyboardController();

            collisionDetection = new CollisionDetection();

            //collisionResolution.LoadCollisionDictionary();

            camera = new Camera(_graphics.GraphicsDevice.Viewport);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2DStorage.LoadContent(Content);
            SpriteFactory.Instance.LoadDictionary();

            LevelLoader.Instance.LoadLevel();

            keyboard.LoadContent(this, (Player)GameObjectManager.Instance.player);

            collisionDetection.GetCollisionLists();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboard.Update(gameTime);

            GameObjectManager.Instance.Update(gameTime);
            collisionDetection.Update(gameTime);
            camera.Update((Player)GameObjectManager.Instance.player);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.zoomMatrix); //have to use this here to use the camera, would love to chat about it if anyone wants to.

            GameObjectManager.Instance.Draw(spriteBatch);

            base.Draw(gameTime);

            spriteBatch.End();
        }

        public void Reset()
        {
            LevelLoader.Instance.LoadLevel();
            keyboard.LoadContent(this, (Player)GameObjectManager.Instance.player);
        }
    }
}
