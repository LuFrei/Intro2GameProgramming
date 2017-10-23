using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeapons : MonoBehaviour {

	private Sprite Weapons;
	public Sprite Sword;
	public Sprite Bow;

	public Image WeaponUI1;
	public Image WeaponUI2;
	private PlayerController player;


	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

	}

	void Update () {
	
		if (player.bow = true)
		{
			WeaponUI1.sprite = Bow;
		}

		if (player.Sword = true) {
			WeaponUI2.sprite = Sword;
		}
	}
}