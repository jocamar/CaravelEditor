# CaravelEditor
This is a simple tool built using C# and Windows Forms that allows anyone to easily create and edit [Caravel](https://github.com/jocamar/Caravel) scenes, entity types and materials.

![Image of the editor startup screen.](https://i.imgur.com/EFhhAEw.png)
![Image of the editor UI.](https://i.imgur.com/VC7HHMV.png)

## Building
Just open the project in Visual Studio and run it. Make sure you have Windows Forms installed and are running a .NET Framework version > 4.5.

## How to Use
You'll need to create and open a Caravel project either using the menu bar or the buttons in the startup screen. After loading a project (*.cvp file) you can open any scene in that project or create new ones. Choose a scene to load using the 'Project' menu item and the you can edit that scene as you wish.

The editor allows you to do stuff like:
* Create, Destroy and Rename entities in the scene.
* Customize entities by adding/removing components and editing the component properties.
* Create subscenes inside a scene (Caravel's version of prefabs).
* Save an entity as an entity_type for easy reuse.
* Save a scene subtree as a new scene for easy reuse.
* Create and edit physics materials.
* Visualize information like collision shapes, triggers and bounding boxes.
* Building and running the game project.

**Note: While the editor allows you to create projects (.cvp), scenes (.cvs), entity types (.cve) and material files (.xml) it does not add them to your Visual Studio project. If you're using the [Caravel Game Template](https://github.com/jocamar/CaravelStarterProject) as a base you'll still need to manually add these files as resources in the project for them to be copied during the build process. In the future this might be simplified.** 
