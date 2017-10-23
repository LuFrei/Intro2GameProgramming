using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour {

	public PlayerController player;

	void Start ()
	{
		player = FindObjectOfType<PlayerController> ();

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Enemy")) {
			Destroy (col.gameObject);
		}
	}
}