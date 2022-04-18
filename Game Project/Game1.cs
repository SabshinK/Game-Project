﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        private Camera camera;
        private GameStateMachine gameStateMachine;
        private UIManager uIManager;
        

        private SpriteFont font;
        private Song song;

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
            keyboard = new KeyboardController(this);

            collisionDetection = new CollisionDetection();

            camera = new Camera(_graphics.GraphicsDevice.Viewport);
            uIManager = new UIManager(camera);

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
            
            font = Content.Load<SpriteFont>("Text");
            

            LevelLoader.Instance.LoadFile("sprites");
            LevelLoader.Instance.LoadFile("forest");
            LevelLoader.Instance.LoadFile("collision");
            uIManager.LoadContent(Content);
           
            keyboard.LoadContent(GameObjectManager.Instance.GetPlayer());

            song = Content.Load<Song>("01 - At Dooms Gate");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
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

            
            
            if (!gameStateMachine.paused || !gameStateMachine.over || !gameStateMachine.win)
            {
                GameObjectManager.Instance.Update(gameTime);
                collisionDetection.Update(gameTime);
                camera.Update(GameObjectManager.Instance.GetPlayer());
            }

            uIManager.Update(gameTime);

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
            uIManager.Draw(spriteBatch);

            //healthBar.Draw(spriteBatch);

            base.Draw(gameTime);

            spriteBatch.End();
        }

        public void Reset()
        {
            gameStateMachine.paused = false;
            GameObjectManager.Instance.Reset();
            LevelLoader.Instance.LoadFile("forest");
            keyboard.LoadContent(this, GameObjectManager.Instance.GetPlayer());
        }
    }
}
