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
    public partial class Sprite : Component
    {
        Texture2D mySprite;
        Vector2 myLocation;
        Vector2 myDirection;
        
        public Sprite(Texture2D sprite, Vector2 location, Vector2 direction)
        {
            mySprite = sprite;
            myLocation = location;
            myDirection = direction;

            InitializeComponent();
        }

        public Sprite(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void SetLocation(Vector2 location)
        {
            myLocation = location;
        }

        public void SetLocationX(float locationX)
        {
            myLocation.X = locationX;
        }

        public void SetLocationY(float locationY)
        {
            myLocation.Y = locationY;
        }

        public void SetDirection(Vector2 direction)
        {
            myDirection = direction;
        }

        public Vector2 Location()
        {
            return myLocation;
        }

        public void addLocation(Vector2 addition)
        {
            myLocation += addition;
        }
        public void multLocation(Vector2 multiplyer)
        {
            myLocation *= multiplyer;
        }

        public Vector2 Direction()
        {
            return myDirection;
        }

        public void addDirection(Vector2 addition)
        {
            myDirection += addition;
        }
        public void multDirection(Vector2 multiplyer)
        {
            myDirection *= multiplyer;
        }

        public Texture2D Texture()
        {
            return mySprite;
        }
    }
}
