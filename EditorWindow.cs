using Caravel.Editor;
using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using System;
using System.Windows.Forms;

namespace CaravelEditor
{
    public class EditorWindow : UpdateWindow
    {
        public EditorApp EditorApp
        {
            get; private set;
        }

        public EditorForm EditorForm
        {
            get; set;
        }

        private GameTime _lastGameTime;

        protected override void Initialize()
        {
            base.Initialize();

            EditorApp = new EditorApp(GraphicsDevice, Editor, Width, Height);
            EditorApp.EditorInitialize();
            EditorApp.EditorLoadContent();

            Resize += new EventHandler(CaravelEditor_Resize);

            EditorForm.InitializeComponentEditor();
            EditorForm.InitializeMaterialsEditor();
            EditorForm.InitializeTools();

            _lastGameTime = new GameTime();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            EditorApp.CurrentGraphicsDevice = GraphicsDevice;
            EditorApp.EditorUpdate(gameTime);
            _lastGameTime = gameTime;
        }

        protected override void Draw()
        {
            base.Draw();
            EditorApp.EditorDraw(_lastGameTime);
        }

        private void CaravelEditor_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            var eventArgs = new Cv_ResizeWindowEvt();
            eventArgs.Width = control.Size.Width;
            eventArgs.Height = control.Size.Height;

            EditorApp.OnResize(this, eventArgs);
            EditorForm.RepositionToolBox();
        }
    }
}
