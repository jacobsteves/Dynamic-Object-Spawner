# Dynamic Object Spawner

The Dynamic Object Spawner was made for performance enhancement so that GameObjects or enemies that are not seen or not in use do not appear in the game. This is more efficient for CPU usage and can allow more objects to appear be in your scene, allowing the developer to focus more on intricate AI.

Demo                       |
:-------------------------:|
![Demo gif](Demo/demo.gif) |
The number of destroyed objects was set to all but one, and as soon as the respawn time was reached and the player re-entered the spawn trigger, all previously destroyed objects respawned.

## Usage

For an example, if you are spawning enemies, call `ObjectSpawner.cs -> incrementObjectsDestroyed ()` everytime an enemy dies. This method ensures that objects will not spawn back until the respawn time has been fufilled. Then, a body will remain in the game but the spawner will still keep track of the objects alive.

If you simply destroy the object, then the spawner assumes the object is some type of renewable resource, so it will spawn the object back in whenever the player comes within distance.

## Getting Started

### Prerequisites

- [Unity](https://unity3d.com/)
- A Built [NavMesh](https://docs.unity3d.com/Manual/nav-BuildingNavMesh.html) in your scene

### Installation

1. Add `Spawner/ObjectSpawner.cs` to your project.
2. Ensure your player is tagged `Player` or change this code in `ObjectSpawner.cs` if you want your player to be named something else
3. Ensure your player has some Collider (with `Is Trigger` unchecked) and a Rigidbody.
4. Add `Spawner/ObjectSpawner.prefab` to your project, and update the Script settings in Unity's Inspector window to use the prefab you want to be spawned in. Read the next section for more information.

## Customization

Unity's Inspector Window         |
:-------------------------------:|
![Inspector](Demo/inspector.png) |
- <b>Spawn Radius</b>: The radius that you want the objects to spawn within. The objects will spawn in random locations between the radius and the ObjectSpawner.
- <b>Trigger Radius</b>: The radius the trigger extends to. When the players distance to the the ObjectSpawner is within the `Trigger Radius`, the objects are spawned in. When the player leaves this radius, the Objects are destroyed from the scene until the player re-enters the radius.
- <b>Max Game Objects</b>: How many objects the Spawner can spawn in.
- <b>Seconds To Respawn</b>: How long until destroyed Game Objects respawn. The objects will never respawn while the player is within the `Trigger Radius`. The player must leave the `Trigger Radius` and then as soon as the player goes back within the `Trigger Radius`, the spawner checks how many objects to spawn back in by determining if objects have been destroyed for longer than `Seconds to Respawn`
- <b>Prefab</b>: A prefab of the Game Object you want to spawn in.
- <b>Cur Game Objects</b>: A list of the Game Objects the spawner currently holds. Everytime an object is spawned, ObjectSpawner holds a reference to its location within this list.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
