using System.Collections.Generic;
using System.IO;
using System.Xml;
using Caravel.Core;
using Caravel.Core.Entity;
using static Caravel.Core.Entity.Cv_Entity;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Caravel.Core.Physics;
using static Caravel.Core.Physics.Cv_GamePhysics;
using Caravel.Core.Input;
using System.Windows.Forms;
using System;
using Caravel.Core.Process;

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

        public int EntityDragStepX
        {
            get; set;
        }

        public int EntityDragStepY
        {
            get; set;
        }

        public int EntityDragStepRot
        {
            get; set;
        }

        public string CurrentScenePreLoadScript
        {
            get; set;
        }

        public string CurrentScenePostLoadScript
        {
            get; set;
        }

        private Vector2 m_PrevMousePos;
        private int m_iPreviousScrollValue;
        private bool m_bMovingEntity = false;
        private bool m_bRotatingEntity = false;
        private Cv_Entity m_EntityBeingMoved;
        private Vector2 m_DeltaBuffer;
        private int m_iIdleTime = 0;
        private int m_iLastIdUsed = 0;

        public EditorLogic(CaravelApp app) : base(app)
        {
            m_iPreviousScrollValue = 0;
            m_PrevMousePos = new Vector2(-1, -1);
            ProjectDirectory = Directory.GetCurrentDirectory();
            CurrentScenePostLoadScript = "";
            CurrentScenePreLoadScript = "";
        }

        public Cv_PhysicsMaterial GetMaterial(string materialId)
        {
            return ((Cv_NullPhysics)GamePhysics).GetMaterial(materialId);
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
            var editorCam = GetEntity(EditorView.EditorCamera);
            var camComponent = editorCam.GetComponent<Cv_CameraComponent>();

            var scriptElement = sceneData.SelectNodes("Script").Item(0);

            if (scriptElement != null)
            {
                CurrentScenePreLoadScript = scriptElement.Attributes["preLoad"].Value;
                CurrentScenePostLoadScript = scriptElement.Attributes["postLoad"].Value;
            }

            EditorView.Camera = camComponent.CameraNode;
            return true;
        }

        protected override void VGameOnUpdate(float time, float timeElapsed)
        {
            var cam = GetEntity(EditorView.EditorCamera);
            var camTransf = cam.GetComponent<Cv_TransformComponent>();
            var camSettings = cam.GetComponent<Cv_CameraComponent>();

            var mouseState = Mouse.GetState();
            var keyboardState = Keyboard.GetState();
            var editorApp = ((EditorApp)Caravel);
            var mousePos = Cv_InputManager.Instance.GetMouseValues().MousePos;
            var mouseScroll = Cv_InputManager.Instance.GetMouseValues().MouseWheelVal;

            if (Cv_InputManager.Instance.CommandActive("mouseLeftClick", PlayerIndex.One))
            {
                if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (editorApp.EWindow != null
                        && editorApp.EWindow.Focused
                        && editorApp.EWindow.EditorForm.CanSelectEntities)
                    {
                        Cv_EntityID[] entities;
                        EditorView.Pick(mousePos, out entities);

                        if (Cv_InputManager.Instance.CommandActivated("mouseLeftClick", PlayerIndex.One))
                        {
                            if (!Cv_InputManager.Instance.CommandActive("alternateMode", PlayerIndex.One))
                            {
                                if (entities.Length > 0)
                                {
                                    if (entities[0] != editorApp.EForm.CurrentEntity)
                                    {
                                        editorApp.EForm.SetSelectedEntity(entities[0]);
                                    }

                                    if (!m_bMovingEntity)
                                    {
                                        //m_bMovingEntity = true;
                                        m_EntityBeingMoved = GetEntity(entities[0]);
                                    }

                                }
                            }
                            else if (editorApp.EForm.CurrentEntity != Cv_EntityID.INVALID_ENTITY)
                            {
                                if (!m_bMovingEntity)
                                {
                                    //m_bMovingEntity = true;
                                    m_EntityBeingMoved = GetEntity(editorApp.EForm.CurrentEntity);
                                }
                            }
                        }

                        if (Cv_InputManager.Instance.CommandActive("mouseMove", PlayerIndex.One) && m_EntityBeingMoved != null)
                        {
                            m_bMovingEntity = true;
                            var trasnfComp = m_EntityBeingMoved.GetComponent<Cv_TransformComponent>();

                            if (trasnfComp == null)
                            {
                                m_bMovingEntity = false;
                                m_EntityBeingMoved = null;
                            }
                            else
                            {
                                var delta = m_DeltaBuffer + (mousePos - m_PrevMousePos);
                                var deltaXscale = delta / (float)EditorView.EditorRenderer.Scale;
                                var entityDelta = deltaXscale / camSettings.Zoom;

                                var numStepsX = ((int) entityDelta.X) / EntityDragStepX;
                                var numStepsY = ((int) entityDelta.Y) / EntityDragStepY;

                                var finalDelta = new Vector3(numStepsX * EntityDragStepX, numStepsY * EntityDragStepY, 0);


                                m_DeltaBuffer = delta;
                                if (finalDelta != Vector3.Zero)
                                {
                                    trasnfComp.SetPosition(trasnfComp.Position + finalDelta);

                                    if (finalDelta.X != 0)
                                    {
                                        m_DeltaBuffer = new Vector2(0, m_DeltaBuffer.Y);
                                    }

                                    if (finalDelta.Y != 0)
                                    {
                                        m_DeltaBuffer = new Vector2(m_DeltaBuffer.X, 0);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (editorApp.Mode == EditorApp.EditorMode.CAMERA
                            && editorApp.EWindow != null
                            && editorApp.EWindow.Focused && m_PrevMousePos.X != -1)
                {
                    var delta = m_PrevMousePos - mousePos;

                    camTransf.SetPosition(camTransf.Position + new Vector3(delta, 0) / (camSettings.Zoom * (float)EditorView.EditorRenderer.Scale));
                }
                else if (editorApp.Mode == EditorApp.EditorMode.CREATE)
                {
                    if (Cv_InputManager.Instance.CommandActivated("mouseLeftClick", PlayerIndex.One))
                    {
                        var timer = new Cv_TimerProcess(100, PaintEntity);
                        Caravel.ProcessManager.AttachProcess(timer);
                    }
                }
            }
            else
            {
                if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (m_bMovingEntity)
                    {
                        m_bMovingEntity = false;
                        m_EntityBeingMoved = null;
                        m_DeltaBuffer = Vector2.Zero;
                        editorApp.EForm.UpdateEntityXml();
                    }
                }
            }

            if (Cv_InputManager.Instance.CommandActive("mouseWheelUp", PlayerIndex.One) || Cv_InputManager.Instance.CommandActive("mouseWheelDown", PlayerIndex.One))
            {
                m_iIdleTime = 0;
                var delta = mouseScroll - m_iPreviousScrollValue;

                if (editorApp.Mode == EditorApp.EditorMode.CAMERA)
                {
                    camSettings.Zoom += delta / 3000f;
                    editorApp.EForm.UpdateTools();
                }
                else if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (editorApp.EWindow != null
                        && editorApp.EWindow.Focused
                        && editorApp.EWindow.EditorForm.CanSelectEntities)
                    {
                        var entity = GetEntity(editorApp.EForm.CurrentEntity);

                        if (entity != null)
                        {
                            var trasnfComp = entity.GetComponent<Cv_TransformComponent>();

                            if (trasnfComp != null)
                            {
                                m_bRotatingEntity = true;
                                trasnfComp.SetRotation(trasnfComp.Rotation + delta / 3000f);
                            }
                        }
                    }
                }
            }
            else if (m_bRotatingEntity)
            {
                if (m_iIdleTime > 1000)
                {
                    m_bRotatingEntity = false;
                    editorApp.EForm.UpdateEntityXml();
                    m_iIdleTime = 0;
                }
                else
                {
                    m_iIdleTime += (int)(timeElapsed);
                }
            }

            m_PrevMousePos = mousePos;
            m_iPreviousScrollValue = mouseScroll;
        }

        protected override void VGameOnAddView(Cv_GameView view, Cv_EntityID entityId)
        {
            EditorView = (EditorView) view;
        }

        private void PaintEntity()
        {
            var editorApp = ((EditorApp)Caravel);
            var mousePos = Cv_InputManager.Instance.GetMouseValues().MousePos;

            if (editorApp.EWindow == null
                            || editorApp.Mode != EditorApp.EditorMode.CREATE
                            || !editorApp.EWindow.Focused
                            || !editorApp.EWindow.EditorForm.CanSelectEntities
                            || editorApp.CurrentResourceBundle == null || editorApp.CurrentResourceBundle == "")
            {
                return;
            }
            
            if (editorApp.EForm.CurrentEntityType != null && editorApp.EForm.CurrentEntityType != "")
            {
                Cv_EntityID[] entities;
                EditorView.Pick(mousePos, out entities);

                bool entityExists = false;

                foreach (var e in entities)
                {
                    var entity = GetEntity(e);
                    if (entity != null && entity.EntityTypeResource == editorApp.EForm.CurrentEntityType)
                    {
                        entityExists = true;
                        break;
                    }
                }

                if (!entityExists)
                {
                    var transform = Cv_Transform.Identity;

                    var parentPosition = Vector3.Zero;

                    var parentEntity = GetEntity(editorApp.EForm.CurrentEntity);
                    if (parentEntity != null && parentEntity.GetComponent<Cv_TransformComponent>() != null)
                    {
                        parentPosition = parentEntity.GetComponent<Cv_TransformComponent>().WorldPosition;
                    }

                    var worldPos = EditorView.GetWorldCoords(mousePos);
                    if (worldPos != null)
                    {
                        int numStepsX = (int)(worldPos.Value.X) / EntityDragStepX;
                        int numStepsY = (int)(worldPos.Value.Y) / EntityDragStepY;

                        int signX = worldPos.Value.X < 0 ? -1 : 1;
                        int signY = worldPos.Value.Y < 0 ? -1 : 1;

                        var pos = new Vector3((numStepsX + signX * 0.5f) * EntityDragStepX, (numStepsY + signY * 0.5f) * EntityDragStepY, 0);
                        pos -= parentPosition;

                        transform = new Cv_Transform(pos, Vector2.One, 0);
                    }

                    var entityName = "";
                    do
                    {
                        entityName = "Entity_" + m_iLastIdUsed;
                        m_iLastIdUsed++;
                    }
                    while (EntityNamesMap.ContainsKey(entityName));

                    var entity = CreateEntity(editorApp.EForm.CurrentEntityType, entityName, editorApp.CurrentResourceBundle, true, editorApp.EForm.CurrentEntity, null, transform);

                    if (entity != null)
                    {
                        editorApp.EForm.AddNewEntityToEditor(entity, true);
                        //editorApp.EForm.SetSelectedEntity(entity.ID);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select an entity type before using the 'Create' tool.");
            }
            
        }
    }
}