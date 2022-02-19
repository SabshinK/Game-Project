using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game_Project.Sprites;
using Game_Project.Enemies;
using Game_Project.Interfaces;

namespace Game_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
        private GoriyaEnemy mrGoriya;

        // Interfaces to use
        public IController keyboard;
        public IController mouse;
        private ISprite sprite;

        // Necessary so that command recievers can display things correctly. These would be stored somewhere different and would be
        // loaded in a different way, this is by no means a final or best design
        public Texture2D PlayerTexture { get; private set; }
        public Vector2 Location { get; private set; }
        public int rows;
        public int columns;

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
            //GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            Location = new Vector2(GraphicsDevice.Viewport.Width / 2 - 48, GraphicsDevice.Viewport.Height / 2 - 64);
            rows = 3;
            columns = 4;

            keyboard = new KeyboardController();
            mouse = new MouseController();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2DStorage.LoadContent(Content);

            keyboard.LoadContent(this);
            mouse.LoadContent(this);
            SpriteFactory.Instance.LoadDictionary();
            
            font = Content.Load<SpriteFont>("Text");
            // Set default sprite state

            mrGoriya = new GoriyaEnemy();
            mrGoriya.Create(_spriteBatch, new Vector2(300, 300));
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

            keyboard.Update();
            mouse.Update();

            mrGoriya.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the text
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Credits\nProgram made by: Sebastian King\nhttps://www.pinterest.com/pin/789326272163794175/", new Vector2(125, 400), Color.Black);
            _spriteBatch.End();

            // Draw the sprite
            mrGoriya.Draw();


            base.Draw(gameTime);
        }

        public void setSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
    }
}
