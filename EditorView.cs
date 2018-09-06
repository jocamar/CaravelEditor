using System.Xml;
using Caravel.Core;
using Microsoft.Xna.Framework;
using static Caravel.Core.Entity.Cv_Entity;
using Microsoft.Xna.Framework.Graphics;
using Caravel.Core.Events;
using Caravel.Core.Draw;

namespace Caravel.Editor
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
        }

        public int SceneVirtualHeight
        {
            get
            {
                return Renderer.VirtualHeight;
            }
        }

        public EditorView(PlayerIndex player, SpriteBatch sb) : base(player, new Vector2(1,1), Vector2.Zero, sb)
        {
            DebugDrawPhysicsShapes = true;
        }

        public void Init()
        {
            EditorCamera = Caravel.Logic.CreateEntity("camera.cve", "_editorCamera", "_EditorDefault").ID;
            Cv_EventManager.Instance.RemoveListener<Cv_Event_NewCameraComponent>(OnNewCameraComponent);
        }
    }
}