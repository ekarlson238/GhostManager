using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GhostManager
{
    class GhostManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        int numberOfGhosts;

        bool canSpawn = true;
        bool canRemove = true;

        List<Ghost> Ghosts = new List<Ghost>();

        public GhostManager(Game game, int ghosts) : base(game)
        {
            numberOfGhosts = ghosts;
        }

        protected override void LoadContent()
        {
            SpawnGhost();
        }

        public override void Update(GameTime gameTime)
        {
            CheckForCollision();

            if (canSpawn)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    SpawnGhost();
                    canSpawn = false;
                }
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.Up))
                canSpawn = true;

            if (canRemove)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    RemoveGhost();
                    canRemove = false;
                }
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.Down))
                canRemove = true;

            base.Update(gameTime);
        }

        private void CheckForCollision()
        {
            foreach (Ghost g1 in Ghosts)
            {
                foreach (Ghost g2 in Ghosts)
                {
                    if (g1 != g2)
                    {
                        if (g1.Intersects(g2))
                        {
                            g1.ReverseDirection();
                        }
                    }
                }
            }
        }

        private void SpawnGhost()
        {
            Ghost g;
            g = new Ghost(this.Game);

            this.Game.Components.Add(g);
            Ghosts.Add(g);
        }

        private void RemoveGhost()
        {
            if (Ghosts.Count > 0)
            {
                this.Game.Components.Remove(Ghosts[Ghosts.Count - 1]);
                Ghosts.RemoveAt(Ghosts.Count - 1);
            }
        }
    }
}
