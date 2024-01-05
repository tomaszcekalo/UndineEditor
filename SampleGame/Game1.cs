using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Undine.Core;
using Undine.DefaultEcs;
using Undine.MonoGame;
using Undine.MonoGame.Primitives2D;

namespace SampleGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Primitives2DSystem _primitives2DSystem;
        private ISystem _primitives2DSystemContainer;

        public EcsContainer EcsContainer { get; set; }// required for editor
        public List<EditorEntity> EditorEntities { get; set; }// required for editor

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            EcsContainer = new DefaultEcsContainer();
            EcsContainer.AddSystem(new KeyboardSystem());

            _primitives2DSystem = new Primitives2DSystem();
            _primitives2DSystemContainer = EcsContainer.GetSystem(_primitives2DSystem);
            EcsContainer.Init();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            if (EditorEntities is not null)
            {
                EcsContainer.LoadEntitiesFromEditor(EditorEntities);
            }
            _primitives2DSystem.SpriteBatch = _spriteBatch;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            EcsContainer.Run();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _primitives2DSystemContainer.ProcessAll();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}