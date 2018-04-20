using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	// public variables
	public Transform[] m_spawnPos;			// All spawn position present in the scene
	public GameObject[] m_podiums;			// Instance of podiums
	public GameObject[] m_items;			// Collection of items

	// private variables

	// ------------------------------------
	// Use this for initialization
	// ------------------------------------
	void Start () {
		// Make an initial generation
		generate();
		
	}

	// ------------------------------------
	// Update is called once per frame
	// ------------------------------------
	void Update () {
		// TEMPORARY ________________
		if (Input.GetKeyDown(KeyCode.Space)) {
			reset();
			generate();
		}
		
	}

	// ------------------------------------
	// Methods
	// ------------------------------------
	public void generate() {
		// Get all the position available for a spawning
		for (int i = 0; i < m_spawnPos.Length; i++) {
			// Pick a random number for the type of podium
			int index = Random.Range(0, 3);
			// Instantiate a podium at a unique position from the array
			GameObject aPodium = Instantiate (m_podiums[index], m_spawnPos[i].position, m_spawnPos[i].rotation);
			int itemIndex = Random.Range (0, m_items.Length);
			GameObject aItem = Instantiate (m_items[itemIndex], aPodium.GetComponentInChildren<Transform> ().position, aPodium.GetComponentInChildren<Transform> ().rotation);
		}
	}

	public void offset(){

	}
		

	public void reset() {
		// Get all the podiums in the room
		GameObject[] elements = GameObject.FindGameObjectsWithTag("Podium");

		// Delete all of them
		for (int i = 0; i < elements.Length; i++) {
			Destroy(elements[i]);
		}
	}

}
