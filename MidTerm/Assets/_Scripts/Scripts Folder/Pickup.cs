using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    GameMaster gm;
    PlayerController pc;
	AudioSource audio;
	public AudioClip coinPickUp;

    private void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && this.gameObject.CompareTag("Point"))
        {
            gm.points += 1;
            audio.PlayOneShot (coinPickUp, 1.0f);
            Destroy(gameObject);
			
        }

        if (other.CompareTag("Player") && this.gameObject.CompareTag("HP") && pc.health < 3)
        {
            pc.health += 1;
            Destroy(gameObject);
        }
    }
}
