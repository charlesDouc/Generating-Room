using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumController : MonoBehaviour {

  public GameObject[] m_items;
  public GameObject gm;

  public void SelectModel()
  {
	int randomItemIndex = Random.Range(0, m_items.Length);
	
	SpawnModel(randomItemIndex);
  }

  void SpawnModel(int modelID)
  {
	Vector3 podiumPosition = GetComponent<Transform>().position;
	Vector3 modelPosition = new Vector3(podiumPosition.x, podiumPosition.y + GetComponent<Collider>().bounds.size.y, podiumPosition.z);
	GameObject artwork = Instantiate(m_items[modelID], modelPosition, GetComponent<Transform>().rotation);
	artwork.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
  }
}
