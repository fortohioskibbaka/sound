using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bomb;
        Rectangle bombrect;
        SpriteFont timefont;
        Rectangle window;
        float seconds;
        SoundEffect exploed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bombrect = new Rectangle(50, 50, 700, 400);

            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            seconds = 10;
            base.Initialize();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            timefont = Content.Load<SpriteFont>("timefont");
            bomb = Content.Load<Texture2D>("bomb");

            exploed = Content.Load<SoundEffect>("explosion");



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            seconds -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (seconds >= 10)
            {


                exploed.Play();
                seconds = 0F;   
                
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(bomb,bombrect, Color.White);
            _spriteBatch.DrawString(timefont, seconds.ToString("00.0"), new Vector2(270, 200), Color.Black);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
