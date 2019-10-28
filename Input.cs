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
    public partial class Input : Component
    {
        Keys up;
        Keys down;
        Keys left;
        Keys right;

        public Input(Keys upKey, Keys downKey, Keys leftKey, Keys rightKey)
        {
            up = upKey;
            down = downKey;
            left = leftKey;
            right = rightKey;

            InitializeComponent();
        }

        public Input(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool Up()
        {
            if (Keyboard.GetState().IsKeyDown(up))
                return true;
            else
                return false;
        }

        public bool Down()
        {
            if (Keyboard.GetState().IsKeyDown(down))
                return true;
            else
                return false;
        }

        public bool Left()
        {
            if (Keyboard.GetState().IsKeyDown(left))
                return true;
            else
                return false;
        }

        public bool Right()
        {
            if (Keyboard.GetState().IsKeyDown(right))
                return true;
            else
                return false;
        }

        public bool Any()
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
                return true;
            else
                return false;
        }
    }
}
