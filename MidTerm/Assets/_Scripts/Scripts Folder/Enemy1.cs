using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    public float speed;

    private float curRot;

    void Update()
    {
        gameObject.transform.Translate(-speed, 0, 0);
        curRot = gameObject.transform.localEulerAngles.y;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Wall"))
        {
            //speed = -speed;
            transform.localEulerAngles = new Vector2(0f, curRot + 180f);
        }

	}
}