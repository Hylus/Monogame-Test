using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using test1;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D _backgroundTexture;
        CurrentSelectedImage _currentSelectedImage;
        DrawableMap _drawableMap;
        ToolsArea _toolsArea;

        Rectangle Cursor;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() 
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            Window.AllowUserResizing = true;

            Window.Title = "Test 1";

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _backgroundTexture = Content.Load<Texture2D>("background");

            _currentSelectedImage = new CurrentSelectedImage(Content);
            _drawableMap = new DrawableMap(Content);
            _toolsArea = new ToolsArea(Content);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            //CalculateItemsPositions();
         //   CalculateItemsSize();
            UpdateCursorPosition();
            ButtonsEvents();

            base.Update(gameTime);
        }

        private void ButtonsEvents()
        {
            var x = new Rectangle(10, 10, 10, 10);
            
            _currentSelectedImage.Update(Cursor);
            _toolsArea.Update(Cursor,_currentSelectedImage);
            _drawableMap.Update(Cursor, _currentSelectedImage);
        }

        private void CalculateItemsPositions()
        {
            _currentSelectedImage.CalculateItemsPositions(GraphicsDevice);
        }

        private void CalculateItemsSize()
        {
            _currentSelectedImage.CalculateItemsSize(GraphicsDevice);
        }

        void UpdateCursorPosition()
        {
            var mouseState = Mouse.GetState();
            Cursor.X = mouseState.X;
            Cursor.Y = mouseState.Y;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(_backgroundTexture, GraphicsDevice.Viewport.Bounds, Color.White);
            _currentSelectedImage.Draw(spriteBatch);
            _drawableMap.Draw(spriteBatch);
            _toolsArea.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
