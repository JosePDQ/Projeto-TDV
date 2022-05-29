using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SpaceInvader
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Ship ship;
        ColisionM colisionM;
        KeyboardManager Km;
        AlienM alienM;
        gameState state;
        Menu menu;
        Alien alien;


        enum gameState
        {
            menu,
            jogo,
            gameover
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Km = new KeyboardManager();
            state = gameState.menu;





        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            alienM = new AlienM(_spriteBatch, Content, GraphicsDevice);
            ship = new Ship(Km, _spriteBatch, Content, GraphicsDevice, alienM.alien);
            colisionM = new ColisionM(alienM.alien, ship.bullets, Content);
            menu = new Menu(_spriteBatch, GraphicsDevice, Content);
            alien = new Alien(_spriteBatch, Content, GraphicsDevice);








            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Km.Update();
            switch (state)
            {
                case gameState.menu:
                    if (Km.IsKeyPressed(Keys.Enter))
                        state = gameState.jogo;
                    break;
                case gameState.jogo:

                    ship.Movement(gameTime);
                    alienM.Update(gameTime);
                    ship.shoot(gameTime);
                    colisionM.colision();
                    if (colisionM.endgame())
                        state = gameState.gameover;
                    if (ship.colision())
                        state = gameState.gameover;
                    break;
                case gameState.gameover:
                    Exit();
                    break;
                default: break;

            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            switch (state)
            {
                case gameState.menu:
                    GraphicsDevice.Clear(Color.White);
                    menu.Draw();
                    break;
                case gameState.jogo:
                    GraphicsDevice.Clear(Color.Black);
                    ship.Draw();
                    alienM.Draw();
                    break;
                default: break;

            }



            // TODO: Add your drawing code here


            base.Draw(gameTime);
            _spriteBatch.End();
        }


    }
}
