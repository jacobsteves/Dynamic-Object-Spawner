using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * 	This class uses UnityEngine.AI and thus requires that the Unity Scene has
 * a NavMesh built.
 *
 * 	The intended use is for performance enhancement so that GameObjects or
 * enemies that are not seen or not in use do not appear in the game. This
 * is more efficient for CPU usage and can allow more objects to appear be in
 * your scene, allowing the developer to focus more on intricate AI, making
 * your creation look more vibrant and lively.
 *
 */
public class ObjectSpawner : MonoBehaviour {

	public float spawnRadius = 25;
	public float triggerRadius = 100;
	public int maxGameObjects = 10;
	public int secondsToRespawn = 600;
	public GameObject prefab;
	public List<GameObject> curGameObjects = new List<GameObject>();

	private int objectsDestroyed;
	private float respawnTime;
	private GameObject player;

	BoxCollider boxCollider;

	void Start () {
		setCurrentTime();
		setPlayer();
		setBoxCollider();
		spawnObjects();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
				spawnObjects();
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Player") {
				destroyObjects();
		}
	}

	void setPlayer () {
		player = GameObject.FindWithTag("Player");
	}

	void setCurrentTime () {
		respawnTime = Time.time;
	}

	void setBoxCollider () {
		boxCollider = GetComponent<BoxCollider>();
		boxCollider.size = new Vector3(triggerRadius, triggerRadius, triggerRadius);
	}

	void spawnObjects () {
		Vector3 pos = this.transform.position;
		int objectsToCreate = calculateObjectsToCreate();

		if (curGameObjects.Count >= maxGameObjects) return;

		for (int i = 0; i < objectsToCreate; i++) createObject(pos);
	}

	void createObject (Vector3 startingPosition) {
		Vector3 pos = startingPosition;
		NavMeshHit myNavHit;

		float randomX = Random.Range(-spawnRadius, spawnRadius);
		float randomZ = Random.Range(-spawnRadius, spawnRadius);

		Vector3 objectPosition = new Vector3(randomX + pos.x, pos.y, randomZ + pos.z);

		// This method outputs the nearest NavMesh position within 1000 units
		if(NavMesh.SamplePosition(objectPosition, out myNavHit, 1000 , -1)) {
			objectPosition = myNavHit.position;
		}
		
		curGameObjects.Add(Instantiate(prefab, objectPosition, Quaternion.identity));
	}

	int calculateObjectsToCreate () {
		int numInactive = objectsDestroyed;

		if (shouldRespawn()) {
				numInactive = 0;
				objectsDestroyed = 0;
				setCurrentTime();
		}

		return maxGameObjects - numInactive;
	}

	bool shouldRespawn () {
		return (Time.time - respawnTime > secondsToRespawn);
	}

	void destroyObjects () {
		foreach (GameObject obj in curGameObjects) {
			Destroy (obj, 1.0f);
		}
		curGameObjects = new List<GameObject>();
	}

	/*
	 * Increment the count of objects destroyed. Using this method ensures that
	 * objects will not spawn back until the respawn time has been fufilled.
	 *
	 * Usage: If you are spawning enemies, call this method everytime an enemy
	 * 	is defeated. Then, a body will remain in the game but the spawner
	 * 	will still keep track of the objects alive.
	 */
	public void incrementObjectsDestroyed () {
		++objectsDestroyed;
	}
}
