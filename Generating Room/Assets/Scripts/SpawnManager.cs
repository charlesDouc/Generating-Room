using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

  // public variables
  public Transform[] m_spawnPos;			// All spawn position present in the scene
  public GameObject[] m_podiums;			// Instance of podiums
  public GameObject[] m_items;			// Collection of items

  // private variables

  void Start () {
	// Make an initial generation
	GeneratePodiums();
  }

  void Update () {
	// if you'd like to stand somewhere other than by the button
	if (Input.GetKeyDown(KeyCode.G)) {
	  ResetPodiums();
	  GeneratePodiums();
	}
  }

  public void GeneratePodiums() {
	// Get all the position available for a spawning
	for (int i = 0; i < m_spawnPos.Length; i++) {
	  // Pick a random number for the type of podium
	  int index = Random.Range(0, 3);
	  // Instantiate a podium at a unique position from the array
	  GameObject aPodium = Instantiate (m_podiums[index], m_spawnPos[i].position, m_spawnPos[i].rotation);
	  PodiumController pc = aPodium.GetComponent<PodiumController>();
	  pc.gm = GameObject.Find("GM");
	  pc.m_items = m_items;
	  pc.SelectModel();
	}
  }
		
  public void ResetPodiums() {
	string[] objectsToDestroy = {
	  "Podium",
	  "Artwork"
	};

	foreach (string tag in objectsToDestroy)
	{
	  // Get all the podiums & artworks in the room
	  GameObject[] elements = GameObject.FindGameObjectsWithTag(tag);

	  // Delete all of them
	  for (int i = 0; i < elements.Length; i++)
	  {
		Destroy(elements[i]);
	  }
	}
  }
}
