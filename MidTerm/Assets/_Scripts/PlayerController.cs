using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed; //How fast character moves
	public float jumpHeight; //How high character jumps
	private bool doubleJump;

	private Animator anim; //Setting the animator

	public Transform groundCheck; //Checks if player is on the ground
	public float groundCheckRadius; //Radius of which the ground check is in
	public LayerMask whatIsGround; // Assigning what the groundcheck is reacting to with certain layers labeled "Ground"
	private bool grounded; // Says "yes" or "no" the player is on the ground

    public Rigidbody2D rb2d;
	public int health = 3;
	public int maxHealth = 3; //Player health stats 


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> (); //Setting the animator 
    }

	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);


	}
   
    void Update () {
	
		if (grounded)
		{
			doubleJump = false;
		}

		anim.SetBool ("Grounded", grounded);

		if (Input.GetKeyDown (KeyCode.Space) && grounded) //Using SpaceBar to jump and only allows player to jump on ground
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight); 
		}

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJump && !grounded) 
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight); 
			doubleJump = true;
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);
		}

		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x)); //Setting the float for the walk animation
		if (rb2d.velocity.x > 0) {


			transform.localScale = new Vector3 (.3f, .3f, .3f);
		}
			else if(rb2d.velocity.x < 0) //flipping the player animations
			{
				transform.localScale = new Vector3 (-.3f,.3f,.3f);
			}
		}
	}
