using Caravel;
using Caravel.Core;
using Caravel.Core.Physics;
using CaravelEditor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Services;

namespace CaravelEditor
{
    public class EditorApp : CaravelApp
    {
        public EditorWindow EWindow
        {
            get; set;
        }

        public EditorForm EForm
        {
            get; set;
        }

        public string CurrentScene
        {
            get; set;
        }

        public string CurrentResourceBundle
        {
            get; set;
        }

        public EditorLogic EditorLogic
        {
            get
            {
                return (EditorLogic) Logic;
            }
        }

        public enum EditorMode
        {
            TRANSFORM,
            CAMERA,
            CREATE
        }

        public EditorMode Mode
        {
            get; set;
        }

        private UpdateService _updateService;

        public EditorApp(GraphicsDevice gd, UpdateService editor, int screenWidth, int screenHeight) : base(screenWidth, screenHeight)
        {
            CurrentGraphicsDevice = gd;
            _updateService = editor;
            EditorRunning = true;
            UseDevelopmentDirectories = true;
            IsMouseVisible = true;
        }

        protected override bool VCheckGameSystemResources()
        {
            return true;
        }

        protected override Cv_GameLogic VCreateGameLogic()
        {
            return new EditorLogic(this);
        }

        protected override Cv_GamePhysics VCreateGamePhysics()
        {
            return Cv_GamePhysics.CreateNullPhysics(this);
        }

        protected override Cv_GameView[] VCreateGameViews()
        {
            var gvs = new Cv_GameView[1];
            gvs[0] = new EditorView(Cv_Player.One, _updateService.spriteBatch);
            return gvs;
        }

        protected override string VGetGameAppDirectoryName()
        {
            return "CaravelEditor/1.0";
        }

        protected override string VGetGameTitle()
        {
            return "Caravel Editor";
        }

        protected override bool VInitialize()
        {
            EditorLogic.EditorView.Init();
            return true;
        }

        protected override bool VLoadGame()
        {
            EForm.LoadComponentDefinitions();
            Logic.UnloadScene(null);
            Logic.LoadScene(CurrentScene, CurrentResourceBundle, "Root");
            EForm.InitializeSceneEntities();
            EForm.InitializeTools();
            EForm.InitializeAssets();
            EForm.InitializeEntityTypes();
            return true;
        }
    }
}