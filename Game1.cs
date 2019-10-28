using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SimpleMovementWGravity
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        SpriteFont font;

        PlayerController pacMan;
        float pacManSpeed = 10;
        float pacManGravityAccel = 1.8f;

        Input pacManInput;
        Sprite pacManSprite;

        Vector2 gravDirection;

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

            pacManInput = new Input(Keys.W, Keys.S, Keys.A, Keys.D);
            pacManSprite = new Sprite(Content.Load<Texture2D>("pacManSingle"), new Vector2(GraphicsDevice.Viewport.Width * 0.75f,
                GraphicsDevice.Viewport.Height / 2), new Vector2(1, 0));

            gravDirection = new Vector2(0, 1);

            //player controller constructor
            pacMan = new PlayerController(pacManInput, pacManSprite,
                pacManSpeed, gravDirection, pacManGravityAccel);
            
            
            font = Content.Load<SpriteFont>("Arial");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

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
            
            //Elapsed time since last update will be used to correct movement speed
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            pacMan.UpdateGravity();
            pacMan.UpdateLocation(time);
            pacMan.UpdateKeepOnScreen(GraphicsDevice.Viewport);
            pacMan.UpdateDirection();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            
            spriteBatch.Draw(pacMan.Sprite().Texture(), pacMan.Sprite().Location(), Color.Red);
            
            spriteBatch.DrawString(font,
                string.Format("Speed:{0}\nDir:{1}\nGravityDir:{2}\nGravtyAccel:{3}",
                pacManSpeed, pacMan.Sprite().Direction(), pacMan.GravityDirection(), pacMan.GravityAcceleration()),
                new Vector2(GraphicsDevice.Viewport.Width * 0.6f, 10),
                Color.White);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
