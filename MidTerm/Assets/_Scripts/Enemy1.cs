﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    private Rigidbody2D rb2d;



    public bool isAttacking;
    public float speed;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = new Vector2(-speed, 0);
	}
}
