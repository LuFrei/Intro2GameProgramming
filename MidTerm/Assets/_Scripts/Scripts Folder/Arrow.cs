using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float speed;

	public PlayerController player;

	void Start ()
	{
		player = FindObjectOfType<PlayerController> ();
		
		if (player.transform.localScale.x > 0) 
		{
			speed = -speed;
			transform.localScale = new Vector3 (.35f, .35f, .35f);
		}

		if (player.transform.localScale.x < 0) 
		{
			transform.localScale = new Vector3 (-.35f, -.35f, -.35f);
		}
	}


	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
		}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Shield")) {
			Destroy(gameObject);
				}

		if (col.CompareTag ("Enemy")) {
			Destroy(col.gameObject);
			}
			
		if (col.CompareTag ("Ground")) {
			Destroy (gameObject);
		}
	}
}