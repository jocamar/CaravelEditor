using System.Collections.Generic;
using System.IO;
using System.Xml;
using Caravel.Core;
using Caravel.Core.Entity;
using static Caravel.Core.Entity.Cv_Entity;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Caravel.Core.Input;
using System.Windows.Forms;
using Caravel.Core.Process;
using Caravel;
using System.Linq;
using static Caravel.Core.Cv_SceneManager;

namespace CaravelEditor
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

        public Dictionary<string, Cv_Entity> EntityPathsMap
        {
            get
            {
                return EntitiesByPath;
            }
        }

        public string[]EntityNames
        {
            get
            {
                List<string> entityNames = new List<string>();
                foreach (var e in EntitiesByPath.Values)
                {
                    entityNames.Add(e.EntityName);
                }

                return entityNames.ToArray();
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

        public string CurrentSceneUnLoadScript
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
        private Dictionary<string, int> m_LastIDsUsed = new Dictionary<string, int>();

        public EditorLogic(CaravelApp app) : base(app)
        {
            m_iPreviousScrollValue = 0;
            m_PrevMousePos = new Vector2(-1, -1);
            ProjectDirectory = Directory.GetCurrentDirectory();
            CurrentScenePostLoadScript = "";
            CurrentScenePreLoadScript = "";
            CurrentSceneUnLoadScript = "";
        }

        public Vector2 GetNewEntityWorldPos(int screenX, int screenY, int stepX, int stepY)
        {
            var editorApp = ((EditorApp)Caravel);
            var parentPosition = Vector3.Zero;

            var parentEntity = GetEntity(editorApp.EForm.CurrentEntity);
            if (parentEntity != null)
            {
                if (parentEntity.GetComponent<Cv_TransformComponent>() != null)
                {
                    parentPosition = parentEntity.GetComponent<Cv_TransformComponent>().WorldPosition;
                }
            }

            var worldPos = EditorView.GetWorldCoords(new Vector2(screenX, screenY));
            Vector2 pos = Vector2.Zero;
            if (worldPos != null)
            {
                int numStepsX = (int)(worldPos.Value.X) / stepX;
                int numStepsY = (int)(worldPos.Value.Y) / stepY;

                int signX = worldPos.Value.X < 0 ? -1 : 1;
                int signY = worldPos.Value.Y < 0 ? -1 : 1;

                pos = new Vector2((numStepsX + signX * 0.5f) * stepX, (numStepsY + signY * 0.5f) * stepY);
                pos -= new Vector2(parentPosition.X, parentPosition.Y);
            }

            return pos;
        }

        protected override bool VGameOnPreLoadScene(XmlElement sceneData, string sceneID)
        {
            return true;
        }


        protected override bool VGameOnLoadScene(XmlElement sceneData, Cv_SceneID sceneID, string sceneName)
        {
            if (sceneName == "Root")
            {
                var scriptElement = sceneData.SelectNodes("Script").Item(0);

                if (scriptElement != null)
                {
                    CurrentScenePreLoadScript = scriptElement.Attributes["preLoad"].Value;
                    CurrentScenePostLoadScript = scriptElement.Attributes["postLoad"].Value;
                    CurrentSceneUnLoadScript = scriptElement.Attributes["unLoad"].Value;
                }
            }

            return true;
        }

        protected override void VGameOnUpdate(float time, float timeElapsed)
        {
            var cam = GetEntity(EditorView.EditorCamera);

            if (cam == null)
            {
                return;
            }

            var camTransf = cam.GetComponent<Cv_TransformComponent>();
            var camSettings = cam.GetComponent<Cv_CameraComponent>();

            var mouseState = Mouse.GetState();
            var keyboardState = Keyboard.GetState();
            var editorApp = ((EditorApp)Caravel);
            var mousePos = Cv_InputManager.Instance.GetMouseValues().MousePos;
            var mouseScroll = Cv_InputManager.Instance.GetMouseValues().MouseWheelVal;

            //MOUSE ACTIONS
            if (Cv_InputManager.Instance.CommandActive("mouseLeftClick", Cv_Player.One))
            {
                if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (editorApp.EWindow != null
                        && editorApp.EWindow.Focused
                        && editorApp.EWindow.EditorForm.CanSelectEntities
                        && mousePos.X > 0 && mousePos.Y > 0)
                    {
                        Cv_EntityID[] entities;
                        EditorView.Pick(mousePos, out entities);

                        if (Cv_InputManager.Instance.CommandActivated("mouseLeftClick", Cv_Player.One))
                        {
                            if (!Cv_InputManager.Instance.CommandActive("alternateMode", Cv_Player.One))
                            {
                                if (entities.Length > 0)
                                {
                                    if (entities[0] != editorApp.EForm.CurrentEntity)
                                    {
                                        editorApp.EForm.SetSelectedEntity(entities[0]);
                                    }

                                    if (!m_bMovingEntity)
                                    {
                                        m_EntityBeingMoved = GetEntity(editorApp.EForm.CurrentEntity);
                                    }
                                }
                                else
                                {
                                    var timer = new Cv_TimerProcess(100, DeselectEntity);
                                    Caravel.ProcessManager.AttachProcess(timer);
                                }
                            }
                            else if (editorApp.EForm.CurrentEntity != Cv_EntityID.INVALID_ENTITY)
                            {
                                if (!m_bMovingEntity)
                                {
                                    m_EntityBeingMoved = GetEntity(editorApp.EForm.CurrentEntity);
                                }
                            }
                        }

                        if (Cv_InputManager.Instance.CommandActive("mouseMove", Cv_Player.One) && m_EntityBeingMoved != null)
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
                    if (Cv_InputManager.Instance.CommandActivated("mouseLeftClick", Cv_Player.One))
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

            if (Cv_InputManager.Instance.CommandActive("mouseWheelUp", Cv_Player.One) || Cv_InputManager.Instance.CommandActive("mouseWheelDown", Cv_Player.One))
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

            //SAVE SHORTCUT
            if (Cv_InputManager.Instance.CommandActive("alternateMode", Cv_Player.One) && Cv_InputManager.Instance.CommandDeactivated("save", Cv_Player.One))
            {
                if (editorApp.EForm.CurrentSceneFile != null && editorApp.EForm.CurrentSceneFile != "")
                {
                    editorApp.EForm.SaveScene();
                }
            }


            //MOVE ENTITIES WITH ARROWS
            if (Cv_InputManager.Instance.CommandActivated("Left", Cv_Player.One))
            {
                if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (editorApp.EForm.CurrentEntity != Cv_EntityID.INVALID_ENTITY)
                    {
                        var e = GetEntity(editorApp.EForm.CurrentEntity);

                        if (e != null && e.GetComponent<Cv_TransformComponent>() != null)
                        {
                            var pos = e.GetComponent<Cv_TransformComponent>().Position;

                            e.GetComponent<Cv_TransformComponent>().SetPosition(new Vector3(pos.X - 1, pos.Y, pos.Z));
                        }
                    }
                }
            }

            if (Cv_InputManager.Instance.CommandActivated("Right", Cv_Player.One))
            {
                if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (editorApp.EForm.CurrentEntity != Cv_EntityID.INVALID_ENTITY)
                    {
                        var e = GetEntity(editorApp.EForm.CurrentEntity);

                        if (e != null && e.GetComponent<Cv_TransformComponent>() != null)
                        {
                            var pos = e.GetComponent<Cv_TransformComponent>().Position;

                            e.GetComponent<Cv_TransformComponent>().SetPosition(new Vector3(pos.X + 1, pos.Y, pos.Z));
                        }
                    }
                }
            }

            if (Cv_InputManager.Instance.CommandActivated("Up", Cv_Player.One))
            {
                if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (editorApp.EForm.CurrentEntity != Cv_EntityID.INVALID_ENTITY)
                    {
                        var e = GetEntity(editorApp.EForm.CurrentEntity);

                        if (e != null && e.GetComponent<Cv_TransformComponent>() != null)
                        {
                            var pos = e.GetComponent<Cv_TransformComponent>().Position;

                            e.GetComponent<Cv_TransformComponent>().SetPosition(new Vector3(pos.X, pos.Y - 1, pos.Z));
                        }
                    }
                }
            }

            if (Cv_InputManager.Instance.CommandActivated("Down", Cv_Player.One))
            {
                if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (editorApp.EForm.CurrentEntity != Cv_EntityID.INVALID_ENTITY)
                    {
                        var e = GetEntity(editorApp.EForm.CurrentEntity);

                        if (e != null && e.GetComponent<Cv_TransformComponent>() != null)
                        {
                            var pos = e.GetComponent<Cv_TransformComponent>().Position;

                            e.GetComponent<Cv_TransformComponent>().SetPosition(new Vector3(pos.X, pos.Y + 1, pos.Z));
                        }
                    }
                }
            }

            //DELETE KEY
            if (Cv_InputManager.Instance.CommandActivated("Delete", Cv_Player.One))
            {
                if (editorApp.Mode == EditorApp.EditorMode.TRANSFORM)
                {
                    if (editorApp.EForm.CurrentEntity != Cv_EntityID.INVALID_ENTITY)
                    {
                        editorApp.EForm.RemoveEntityFromEditor(editorApp.EForm.CurrentEntity);
                        editorApp.EForm.SetSelectedEntity(Cv_EntityID.INVALID_ENTITY);
                    }
                }
            }

            m_PrevMousePos = mousePos;
            m_iPreviousScrollValue = mouseScroll;
        }

        protected override void VGameOnAddView(Cv_GameView view, Cv_EntityID entityId)
        {
            EditorView = (EditorView) view;
        }

        protected override Cv_EntityFactory VCreateEntityFactory()
        {
            return new EditorEntityFactory();
        }

        private void DeselectEntity()
        {
            var editorApp = ((EditorApp)Caravel);
            if (editorApp.EWindow == null
                            || editorApp.Mode != EditorApp.EditorMode.TRANSFORM
                            || !editorApp.EWindow.Focused
                            || !editorApp.EWindow.EditorForm.CanSelectEntities
                            || editorApp.CurrentResourceBundle == null || editorApp.CurrentResourceBundle == "")
            {
                return;
            }

            editorApp.EForm.SetSelectedEntity(Cv_EntityID.INVALID_ENTITY);
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

                    var typePos = editorApp.EForm.GetTypePos(editorApp.EForm.CurrentEntityType);
                    
                    var entityNames = EntityNames;
                    var parentEntity = GetEntity(editorApp.EForm.CurrentEntity);
                    if (parentEntity != null)
                    {
                        entityNames = parentEntity.Children.Select(e => e.EntityName).ToArray();

                        if (!m_LastIDsUsed.ContainsKey(parentEntity.EntityPath))
                        {
                            m_LastIDsUsed.Add(parentEntity.EntityPath, 0);
                        }
                    }
                    else if (!m_LastIDsUsed.ContainsKey("Root"))
                    {
                        m_LastIDsUsed.Add("Root", 0);
                    }
                    
                    Vector2 pos = GetNewEntityWorldPos((int) mousePos.X, (int) mousePos.Y, EntityDragStepX, EntityDragStepY);

                    var entityName = "";
                    var parentKey = parentEntity != null ? parentEntity.EntityPath : "Root";
                    do
                    {
                        entityName = editorApp.EForm.EntityTypeItems[editorApp.EForm.CurrentEntityType].Type + "_" + m_LastIDsUsed[parentKey];
                        m_LastIDsUsed[parentKey] = m_LastIDsUsed[parentKey]+1;
                    }
                    while (entityNames.Contains(entityName));

                    var entity = CreateEntity(editorApp.EForm.CurrentEntityType, entityName, editorApp.CurrentResourceBundle, true, editorApp.EForm.CurrentEntity, null, null);
                    var transformComp = entity.GetComponent<Cv_TransformComponent>();
                    if (transformComp)
                    {
                        transformComp.SetPosition(new Vector3(pos, typePos.Z));
                    }

                    if (entity != null)
                    {
                        editorApp.EForm.AddNewEntityToEditor(entity, true);
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