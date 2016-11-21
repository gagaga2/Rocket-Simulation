using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rocket
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Rocket rocket;
        Earth earth;
        Camera camera;
        UniverseManager universe;

        Rocket rocket2;
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

            rocket = new Rocket();

            rocket2 = new Rocket();

            camera = new Camera(rocket, GraphicsDevice.Viewport);
            earth = new Earth();

            universe = new UniverseManager(rocket, earth, new Moon());
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
            rocket.Load(Content.Load<Texture2D>("rocket"), new Vector2(0, 0)); //6371000
            earth.Load(Content.Load<Model>("Earth"));

            rocket2.Load(Content.Load<Texture2D>("rocket"), new Vector2(0, 0));
            // TODO: use this.Content to load your game content here
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

            rocket.Update();
            camera.Update();
            universe.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            var viewmatrix = camera.getViewMatrix();
            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: viewmatrix);

            rocket.Draw(spriteBatch);

            rocket2.Draw(spriteBatch);
            earth.DrawModel(camera);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
