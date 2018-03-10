# Dynamic Object Spawner

Demo                       |
:-------------------------:|
![Demo gif](Demo/demo.gif) |
The number of destroyed objects was set to all but one, and as soon as the respawn time was reached and the player re-entered the spawn trigger, all previously destroyed objects respawned.

## Getting Started
### Prerequisites
- [Unity](https://unity3d.com/)
- A Built [NavMesh](https://docs.unity3d.com/Manual/nav-BuildingNavMesh.html) in your scene

### Installation

1. Add `Spawner/ObjectSpawner.cs` to your project.
2. Ensure your player is tagged `Player` or change this code in `ObjectSpawner.cs` if you want your player to be named something else
3. Ensure your player has some Collider (with `Is Trigger` unchecked) and a Rigidbody.
4. Add `Spawner/ObjectSpawner.prefab` to your project, and update the Script settings in Unity's Inspector window to use the prefab you want to be spawned in. Check out the [Customization](#Customization) header for more details.

## Customization
Unity's Inspector Window         |
:-------------------------------:|
![Inspector](Demo/inspector.png) |
- `Spawn Radius`: The radius that you want the objects to spawn within. The objects will spawn in random locations between the radius and the ObjectSpawner.
- `Trigger Radius`: The radius the trigger extends to. When the players distance to the the ObjectSpawner is within the `Trigger Radius`, the objects are spawned in. When the player leaves this radius, the Objects are destroyed from the scene until the player re-enters the radius.
- `Max Game Objects`: How many objects the Spawner can spawn in.
- `Seconds To Respawn`: How long until destroyed Game Objects respawn. The objects will never respawn while the player is within the `Trigger Radius`. The player must leave the `Trigger Radius` and then as soon as the player goes back within the `Trigger Radius`, the spawner checks how many objects to spawn back in by determining if objects have been destroyed for longer than `Seconds to Respawn`
- `Prefab`: A prefab of the Game Object you want to spawn in.
- `Cur Game Objects`: A list of the Game Objects the spawner currently holds. Everytime an object is spawned, ObjectSpawner holds a reference to its location within this list.
