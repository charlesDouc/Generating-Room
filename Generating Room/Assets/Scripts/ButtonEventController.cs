using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventController : MonoBehaviour {

  public GameObject gm;
  private SpawnManager sm;

  private AudioSource asrc;

  void Start () {
	gm = GameObject.Find("GM");
	sm = gm.GetComponent<SpawnManager>();

	asrc = GetComponent<AudioSource>();
  }

  void OnTriggerStay (Collider other)
  {
	if (Input.GetMouseButtonDown(0))
	{
	  asrc.Play();
	  sm.reset();
	  sm.generate();
	}
  }
}
