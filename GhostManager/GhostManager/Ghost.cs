using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary;
using MonoGameLibrary.Sprite;

namespace GhostManager
{
    class Ghost : DrawableSprite
    {


        public Ghost(Game game) : base(game)
        {
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            spriteTexture = this.Game.Content.Load<Texture2D>("PurpleGhost");

            vp = this.Game.GraphicsDevice.Viewport;
            Random rnd = new Random();
            Location = new Vector2(rnd.Next(0, vp.Width - spriteTexture.Width), rnd.Next(0, vp.Height - spriteTexture.Height));
            
            RandomDirection();

            Speed = 300;
        }

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Location += Direction * (time / 1000) * Speed;

            if (IsOffScreenX())
            {
                ReverseXDirection();

                if (Location.X < (vp.Width - spriteTexture.Width) / 2)
                    Location.X += 10;
                else
                    Location.X -= 10;
            }
                
            if (IsOffScreenY())
            {
                ReverseYDirection();

                if (Location.Y < (vp.Height - spriteTexture.Height) / 2)
                    Location.Y += 10;
                else
                    Location.Y -= 10;
            }

            base.Update(gameTime);
        }

        public void ReverseDirection()
        {
            Direction *= -1;
        }

        public void ReverseXDirection()
        {
            Direction.X *= -1;
        }

        public void ReverseYDirection()
        {
            Direction.Y *= -1;
        }

        public void RandomDirection()
        {
            Random rnd = new Random();

            int randomXDir = rnd.Next(-1, 2);
            int randomYDir;

            if (randomXDir != 0)
                randomYDir = rnd.Next(-1, 2);
            else
            {
                int[] posibleYDIR = new int[] { -1, 1 };
                randomYDir = posibleYDIR[rnd.Next(2)];
            }

            Direction = new Vector2(randomXDir, randomYDir);
        }
    }
}
