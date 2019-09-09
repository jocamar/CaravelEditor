using System.Collections.Generic;
using System.Xml;
using Caravel.Core;
using Caravel.Core.Entity;
using Caravel.Core.Resource;
using Caravel.Debugging;
using static Caravel.Core.Cv_SceneManager;
using static Caravel.Core.Entity.Cv_Entity;

namespace CaravelEditor
{
    public class EditorEntityFactory : Cv_EntityFactory
    {
        protected override Cv_Entity CreateEntity(string entityTypeResource,
                                                    Cv_Entity.Cv_EntityID parent,
                                                    Cv_Entity.Cv_EntityID serverEntityID,
                                                    string resourceBundle,
                                                    Cv_SceneID sceneID,
                                                    string sceneName)
        {
            return base.CreateEntity(entityTypeResource, parent, serverEntityID, resourceBundle, sceneID, sceneName);
        }

        protected override Cv_EntityComponent CreateComponent(string componentName)
        {
            var component = ComponentFactory.Create(Cv_EntityComponent.GetID(componentName));

            if (component == null)
            {
                var gComponent = new GameComponent();
                gComponent.Init(componentName);
                return gComponent;
            }

            return component;
        }

        protected override Component CreateComponent<Component>()
        {
            return base.CreateComponent<Component>();
        }

        protected override Cv_EntityComponent CreateComponent(XmlElement componentData)
        {
            var component = ComponentFactory.Create(Cv_EntityComponent.GetID(componentData.Name));

            if (component == null)
            {
                component = new GameComponent();
                ((GameComponent) component).Init(componentData.Name);
            }

            if (!component.VInitialize(componentData))
            {
                Cv_Debug.Error("Failed to initialize component: " + componentData.Name);
                return null;
            }

            return component;
        }

        protected override Cv_EntityComponent[] ModifyEntity(Cv_Entity entity, XmlNodeList overrides)
        {
            var components = new List<Cv_EntityComponent>();
            foreach (XmlElement componentNode in overrides)
            {
                var componentID = Cv_EntityComponent.GetID(componentNode.Name);
                var component = entity.GetComponent(componentID);

                if (component != null)
                {
                    component.VInitialize(componentNode);
                    component.VOnChanged();
                    components.Add(component);
                }
                else
                {
                    component = CreateComponent(componentNode);
                    if (component != null)
                    {
                        if (component is GameComponent)
                        {
                            entity.AddComponent(((GameComponent)component).ComponentName, component);
                        }
                        else
                        {
                            entity.AddComponent(component.GetType().Name, component);
                        }

                        components.Add(component);
                        //component.VPostInitialize();
                    }
                }
            }

            return components.ToArray();
        }
    }
}
