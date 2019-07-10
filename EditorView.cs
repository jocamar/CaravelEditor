using Caravel.Core;
using Microsoft.Xna.Framework;
using static Caravel.Core.Entity.Cv_Entity;
using Microsoft.Xna.Framework.Graphics;
using Caravel.Core.Events;
using Caravel.Core.Draw;
using Caravel.Core.Entity;

namespace CaravelEditor
{
    public class EditorView : Cv_PlayerView
    {
        public Cv_EntityID EditorCamera
        {
            get; private set;
        }

        public Cv_Renderer EditorRenderer
        {
            get
            {
                return Renderer;
            }
        }

        public int SceneVirtualWidth
        {
            get
            {
                return Renderer.VirtualWidth;
            }

            set
            {
                Renderer.VirtualWidth = value;
            }
        }

        public int SceneVirtualHeight
        {
            get
            {
                return Renderer.VirtualHeight;
            }

            set
            {
                Renderer.VirtualHeight = value;
            }
        }

        public EditorView(PlayerIndex player, SpriteBatch sb) : base(player, new Vector2(1,1), Vector2.Zero, sb)
        {
            DebugDrawPhysicsShapes = true;
            DebugDrawCameras = true;
            DebugDrawClickableAreas = true;
        }

        public void Init()
        {
            Cv_EventManager.Instance.AddListener<Cv_Event_SceneLoaded>(OnSceneLoaded);
            Cv_EventManager.Instance.RemoveListener<Cv_Event_NewCameraComponent>(OnNewCameraComponent);
        }

        public void OnSceneLoaded(Cv_Event evt)
        {
            var sceneLoadedEvt = evt as Cv_Event_SceneLoaded;

            if (sceneLoadedEvt.SceneName == "Root")
            {
                Caravel.Logic.SetMainScene(sceneLoadedEvt.SceneID);
                var cam = Caravel.Logic.CreateEntity("camera.cve", "_editorCamera", "_EditorDefault");
                EditorCamera = cam.ID;
                Camera = cam.GetComponent<Cv_CameraComponent>().CameraNode;
            }
        }
    }
}