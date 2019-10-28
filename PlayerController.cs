using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SimpleMovementWGravity
{
    public partial class PlayerController : Component
    {
        Input playerInput;

        Sprite playerSprite;
        
        float playerSpeed;
        Vector2 gravityDirection;
        float gravityAcceleration;
        
        public PlayerController(Input input, Sprite sprite, float speed, Vector2 gravDirection, float gravAccel)
        {
            playerInput = input;

            playerSprite = sprite;

            playerSpeed = speed;
            gravityDirection = gravDirection;
            gravityAcceleration = gravAccel;

            InitializeComponent();
        }

        public PlayerController(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Sprite Sprite()
        {
            return playerSprite;
        }

        public float Speed()
        {
            return playerSpeed;
        }

        public Vector2 Direction()
        {
            return playerSprite.Direction();
        }

        public Vector2 GravityDirection()
        {
            return gravityDirection;
        }

        public float GravityAcceleration()
        {
            return gravityAcceleration;
        }

        public void UpdateLocation(float gameTime/*, Viewport v*/)
        {
            float time = gameTime;
            
            Sprite().addLocation((playerSprite.Direction() * playerSpeed) * (gameTime / 1000));
        }

        public void UpdateGravity()
        {
            Sprite().addDirection(gravityDirection * gravityAcceleration);
        }

        public void UpdateKeepOnScreen(Viewport v)
        {
            int playerWidth = playerSprite.Texture().Width;
            int playerHeight = playerSprite.Texture().Height;

            if (Sprite().Location().X > v.Width - playerWidth) //x right
            {
                Sprite().multDirection(new Vector2(-1, 1));
                Sprite().SetLocationX(v.Width - playerWidth);
            }
            if (Sprite().Location().X < 0) //x left
            {
                Sprite().multDirection(new Vector2(-1, 1));
                Sprite().SetLocationX(0);
            }

            if (Sprite().Location().Y > v.Height - playerHeight) //bottom of screen
            {
                Sprite().multDirection(new Vector2(1, -1));
                Sprite().SetLocationY(v.Height - playerHeight);
            }
            if (Sprite().Location().Y < 0) //bottom of screen
            {
                Sprite().multDirection(new Vector2(1, -1));
                Sprite().SetLocationY(0);
            }
        }

        public void UpdateDirection()
        {
            #region y axis
            if (playerInput.Up() && playerInput.Down())
                gravityDirection.Y = 1;
            else if (playerInput.Up())
                gravityDirection.Y = -1;
            else if (playerInput.Down())
                gravityDirection.Y = 1;
            else
                gravityDirection.Y = 1;
            #endregion

            #region x axis
            if (playerInput.Left() && playerInput.Right())
                gravityDirection.X = 0;
            else if (playerInput.Left())
                gravityDirection.X = -1;
            else if (playerInput.Right())
                gravityDirection.X = 1;
            else
            {
                if (Sprite().Direction().X > -1 && Sprite().Direction().X < 1)
                {
                    Sprite().SetDirection(new Vector2(0, Sprite().Direction().Y));
                    gravityDirection.X = 0;
                }
                else if (Sprite().Direction().X < 0)
                    gravityDirection.X = 1;
                else if (Sprite().Direction().X > 0)
                    gravityDirection.X = -1;
                else
                    gravityDirection.X = 0;
            }

            #endregion
        }
    }
}
