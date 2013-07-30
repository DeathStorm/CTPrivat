using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace XNAGame
{
    public class Button
    {
        public delegate void onClickHandler();

        public event onClickHandler Click;

        //public event EventHandler Click;



        private MouseState currentState;
        private MouseState lastState;
        private Single scaleFactor;
        private Rectangle bounds;
        private Boolean wasHoverSoundPlayed;
        private SoundEffect hoverSound;
        private Color color;
        private Single soundVolume;

        private SpriteBatch batch;
        private ContentManager content;

        private Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
        }

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
        }

        private Boolean enabled;
        public Boolean Enabled
        {
            get { return enabled; }
            set { this.enabled = value; }
        }

        private Vector2 Origin
        {
            get { return new Vector2(texture.Width / 2, texture.Height / 2); }
        }


        //public Button(ContentManager content, SpriteBatch batch, Single soundVolume)
        public Button(Single soundVolume)
        {
            this.color = Color.White;
            this.soundVolume = soundVolume;
            this.scaleFactor = 1f;
            this.position = new Vector2(0, 0);
            this.enabled = true;
        }

        public void Initialize(Vector2 position)
        {
            this.position = position;
        }

        public void LoadContent(ContentManager content, SpriteBatch batch, String texture, String hoverSound)
        //public void LoadContent(ContentManager content, String texture, String hoverSound)
        {
            this.content = content;
            this.batch = batch;

            this.texture = content.Load<Texture2D>(texture);
            if (hoverSound == "")
            { this.hoverSound = null; }
            else
            { this.hoverSound = content.Load<SoundEffect>(hoverSound); }
            this.bounds = new Rectangle(Convert.ToInt32(position.X - Origin.X),
                Convert.ToInt32(position.Y - Origin.Y),
                this.texture.Width, this.texture.Height);
        }

        public void Update()
        {
            if (enabled == true)
            {
                this.currentState = Mouse.GetState();

                this.bounds.X = Convert.ToInt32(position.X - Origin.X);
                this.bounds.Y = Convert.ToInt32(position.Y - Origin.Y);

                if (bounds.Contains(new Point(currentState.X, currentState.Y)) == true)
                {
                    this.scaleFactor = 1.08f;
                    this.color.B = 20;

                    if (wasHoverSoundPlayed != true && this.hoverSound != null)
                    {
                        this.hoverSound.Play(soundVolume, 0.0f, 0.0f);
                        this.wasHoverSoundPlayed = true;
                    }

                    if ((currentState.LeftButton == ButtonState.Released &&
                        lastState.LeftButton == ButtonState.Pressed) ||
                        (currentState.RightButton == ButtonState.Released &&
                        lastState.RightButton == ButtonState.Pressed))
                    {

                        if (this.Click != null) this.Click();
                        //this.OnClick(EventArgs.Empty);
                    }
                }
                else
                {
                    this.scaleFactor = 1f;
                    this.color.B = 255;
                    this.wasHoverSoundPlayed = false;
                }
            }

            this.lastState = currentState;
        }

        //public void Draw(SpriteBatch batch,float posX, float posY)
        public void Draw(float posX, float posY)
        {
            position.X = posX;
            position.Y = posY;

            if (enabled == true)
            {                
                batch.Draw(texture, position, null,
                    color, 0f, Origin,
                    scaleFactor, SpriteEffects.None, 0f);
            }
            else
            {
                batch.Draw(texture, position, null,
                    new Color(255, 255, 255, 100), 0f, Origin,
                    scaleFactor, SpriteEffects.None, 0f);
            }
        }

        

        //protected void OnClick(EventArgs args)
        //{
        //    //if (klicken != null)
        //    //{
        //    //    this.klicken();
        //    //}

        //    if (Click != null)
        //    {
        //        //this.Click(this, args);
        //        this.Click();
        //    }
        //}
    }
}
