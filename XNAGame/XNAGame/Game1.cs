using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNAGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum GameStatus { MainMenu, InGame };
        enum SubMenus { None, Game, Character, Inventory };

        private GameStatus currentGameStatus = GameStatus.MainMenu;
        private SubMenus currentSubMenu = SubMenus.None;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static SpriteFont mainFont;

        Texture2D Black;

        //Maus Gedöns
        MouseState mouseState;
        Texture2D mouseCursor;
        //Maus Gedöns

        #region Buttons
        Button btn = new Button(0);
        Button btnNewGame = new Button(0);
        #endregion


        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        private void StartNewGame()
        {
            this.currentGameStatus = GameStatus.InGame;
            this.currentSubMenu = SubMenus.Game;
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
            base.Initialize();

            btnNewGame.Click += new Button.onClickHandler(StartNewGame);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mainFont = Content.Load<SpriteFont>("MainFont");

            btn.LoadContent(Content, spriteBatch, "New", "");

            btnNewGame.LoadContent(Content, spriteBatch, "NeuesSpiel", "");
            mouseCursor = Content.Load<Texture2D>("Cursor");
            Black = Content.Load<Texture2D>("Black");
            // TODO: use this.Content to load your game content here
        }

        void UpdateSprite(GameTime gameTime)
        {


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here

            mouseState = Mouse.GetState();
            //mouseX = mouseState.X;
            //mouseY = mouseState.Y;
            btn.Update();
            btnNewGame.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            switch (currentGameStatus)
            {
                case GameStatus.MainMenu:
                    Draw_MainMenu();
                    break;
                case GameStatus.InGame:
                    Draw_GameMenu();
                    break;
                default:
                    break;
            }

            switch (currentSubMenu)
            {
                case SubMenus.None:
                    //% NOthing
                    break;
                case SubMenus.Game:
                    
                    break;
                default:
                    break;
            }

            if (currentGameStatus == GameStatus.MainMenu)
            {

            }

            // Draw the sprite.

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(mouseCursor, new Vector2(mouseState.X, mouseState.Y), Color.Black);
            spriteBatch.DrawString(mainFont, "DIES IST EIN TEST", new Vector2(100, 100), Color.Black);
            //btn.Click = new EventHandler(UpdateSprite);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        void Draw_MainMenu()
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            //spriteBatch.Draw(mouseCursor, new Vector2(mouseX, mouseY), Color.Black);


            btn.Draw(50, 50);
            btnNewGame.Draw(
                GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 2);
            //btn.Click = new EventHandler(UpdateSprite);

            spriteBatch.End();
        }

        void Draw_GameMenu()
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(Black, new Rectangle(GraphicsDevice.Viewport.Width - 300, 0, 10, GraphicsDevice.Viewport.Height), Color.Black);
            spriteBatch.End();
        }


    }
}
