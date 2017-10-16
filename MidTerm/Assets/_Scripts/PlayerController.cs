using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb2d;
	public int health = 3;
	public int maxHealth = 3; //Player health stats 


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
