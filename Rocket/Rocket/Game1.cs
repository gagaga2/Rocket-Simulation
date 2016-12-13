using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Rocket
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        UniverseManager universe;
        GUI gui;
        string[] args;

        public Game1(string[] args)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.args = args;
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

            universe = new UniverseManager(args);
            gui = new GUI();

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
            
            universe.rocket.Load(Content.Load<Texture2D>("rocket"));
            universe.launchpad.Load(Content.Load<Texture2D>("base"));

            foreach(KeyValuePair<string, Planet> p in universe.GetPlanets())
            {
                p.Value.Load(GraphicsDevice, 1024);
            }

            gui.Load(Content.Load<SpriteFont>("basicFont"),
                    universe, Content.Load<Texture2D>("compass"),
                    Content.Load<Texture2D>("arrow"),
                    Content.Load<Texture2D>("altimeter"));
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

            // TODO: Add your update logic here

            universe.Update((float)(TargetElapsedTime.Milliseconds / 1000f));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            // TODO: Add your drawing code here

            universe.Draw(spriteBatch, GraphicsDevice);
            gui.Draw(spriteBatch, GraphicsDevice);
            base.Draw(gameTime);
        }
    }
}
