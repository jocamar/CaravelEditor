using System.Xml;
using Caravel.Core;
using Caravel.Core.Entity;
using Caravel.Debugging;

namespace CaravelEditor
{
    public class EditorEntityFactory : Cv_EntityFactory
    {
        protected override Cv_Entity CreateEntity(string entityTypeResource,
                                                    Cv_Entity.Cv_EntityID parent,
                                                    XmlElement overrides,
                                                    Cv_Transform? initialTransform,
                                                    Cv_Entity.Cv_EntityID serverEntityID,
                                                    string resourceBundle,
                                                    string sceneID)
        {
            return base.CreateEntity(entityTypeResource, parent, overrides, initialTransform, serverEntityID, resourceBundle, sceneID);
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

        protected override void ModifyEntity(Cv_Entity entity, XmlNodeList overrides)
        {
            foreach (XmlElement componentNode in overrides)
            {
                var componentID = Cv_EntityComponent.GetID(componentNode.Name);
                var component = entity.GetComponent(componentID);

                if (component != null)
                {
                    component.VInitialize(componentNode);
                    component.VOnChanged();
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

                        component.VPostInitialize();
                    }
                }
            }
        }
    }
}
