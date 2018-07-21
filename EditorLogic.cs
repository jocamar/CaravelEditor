using System.Collections.Generic;
using System.IO;
using System.Xml;
using Caravel.Core;
using Caravel.Core.Entity;
using static Caravel.Core.Entity.Cv_Entity;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace Caravel.Editor
{
    public class EditorLogic : Cv_GameLogic
    {
        public string ProjectDirectory
        {
            get; private set;
        }

        public int NumEntities
        {
            get
            {
                return Entities.Count;
            }
        }

        public bool IsRunning
        {
            get
            {
                return State == Cv_GameState.Running;
            }
        }

        public EditorView EditorView
        {
            get; private set;
        }

        public Dictionary<Cv_EntityID, Cv_Entity> EntitiesMap
        {
            get
            {
                return Entities;
            }
        }

        public Dictionary<string, Cv_Entity> EntityNamesMap
        {
            get
            {
                return EntitiesByName;
            }
        }

        public List<string> PhysicsMaterials
        {
            get
            {
                var materials = new List<string>();
                materials.AddRange(GamePhysics.GetMaterials());
                return materials;
            }
        }


        private bool m_bMouseButtonWasPressed = false;

        public EditorLogic(CaravelApp app) : base(app)
        {
            ProjectDirectory = Directory.GetCurrentDirectory();
            /*int slashGamePos = ProjectDirectory.IndexOf(Path.DirectorySeparatorChar + "Game");
            ProjectDirectory = ProjectDirectory.Substring(0, slashGamePos);*/
        }

        protected override bool VGameOnPreLoadScene(XmlElement sceneData)
        {
            var entityList = new List<Cv_EntityID>();
            
            foreach(var e in Entities.Keys)
            {
                entityList.Add(e);
            }
            
            foreach(var e in entityList)
            {
                DestroyEntity(e);
            }
 
            return true;
        }


        protected override bool VGameOnLoadScene(XmlElement sceneData)
        {
            EditorView.Init();
            ChangeState(Cv_GameState.Running);
            var editorCam = GetEntity(EditorView.EditorCamera);
            var camComponent = editorCam.GetComponent<Cv_CameraComponent>();

            EditorView.Camera = camComponent.CameraNode;
            return true;
        }

        protected override void VGameOnUpdate(float time, float timeElapsed)
        {
            var cam = GetEntity(EditorView.EditorCamera);
            var camTransf = cam.GetComponent<Cv_TransformComponent>();
            var camSettings = cam.GetComponent<Cv_CameraComponent>();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                camTransf.Position += new Vector3(-5, 0, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                camTransf.Position += new Vector3(5, 0, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                camTransf.Position += new Vector3(0, -5, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                camTransf.Position += new Vector3(0, 5, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                camSettings.Zoom += 0.01f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                camSettings.Zoom -= 0.01f;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (!m_bMouseButtonWasPressed)
                {
                    var mousePos = Mouse.GetState().Position;
                    Cv_EntityID[] entities;
                    EditorView.Pick(new Vector2(mousePos.X, mousePos.Y), out entities);

                    if (entities.Length > 0)
                    {
                        ((EditorApp)CaravelApp.Instance).EForm.SetSelectedEntity(entities[0]);
                    }
                }

                m_bMouseButtonWasPressed = true;
            }
            else
            {
                m_bMouseButtonWasPressed = false;
            }
        }

        protected override void VGameOnAddView(Cv_GameView view, Cv_EntityID entityId)
        {
            EditorView = (EditorView) view;
        }
    }
}