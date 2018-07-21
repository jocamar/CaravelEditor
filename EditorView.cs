using System.Xml;
using Caravel.Core;
using Microsoft.Xna.Framework;
using static Caravel.Core.Entity.Cv_Entity;
using Microsoft.Xna.Framework.Graphics;

namespace Caravel.Editor
{
    public class EditorView : Cv_PlayerView
    {
        public Cv_EntityID EditorCamera
        {
            get; private set;
        }

        public EditorView(PlayerIndex player, SpriteBatch sb) : base(player, new Vector2(1,1), Vector2.Zero, sb)
        {
            DebugDrawPhysicsShapes = true;
        }

        public void Init()
        {
            EditorCamera = CaravelApp.Instance.GameLogic.CreateEntity("camera.cve", "_editorCamera", "_EditorDefault").ID;
        }
    }
}