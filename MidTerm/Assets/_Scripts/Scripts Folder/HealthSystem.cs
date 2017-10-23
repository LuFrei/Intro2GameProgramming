using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

	private Sprite[] hearts;

	public Sprite fullhearts;
	public Sprite twohearts;
	public Sprite oneheart;
	public Sprite nohearts;

	public Image heartsUI; // Image on canvas

	private PlayerController player;


	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

	}

	// Update is called once per frame
	void Update ()
	{
		if (player.health == 3) {
			heartsUI.sprite = fullhearts;
		}
		if (player.health == 2) {
			heartsUI.sprite = twohearts;
		}
		if (player.health == 1) {
			heartsUI.sprite = oneheart;
		}
		if (player.health == 0) {
			heartsUI.sprite = nohearts;
		}
	}

}