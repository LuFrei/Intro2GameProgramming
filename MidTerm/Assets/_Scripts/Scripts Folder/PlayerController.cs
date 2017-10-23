using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // add to use load scenes

public class PlayerController : MonoBehaviour {

	public float moveSpeed; //How fast character moves
	public float jumpHeight; //How high character jumps
	private bool doubleJump;
    public float climbSpeed;

	private Animator anim; //Setting the animator
	public GameObject sword;
	public GameObject arrow;
	public bool Sword;
	public bool bow;
	public Transform firePoint;

	AudioSource audio; //audio source setup
	public AudioClip jumping; //jumping audio file
	public AudioClip bowattack; //shooting audio file
	public AudioClip swordattack;//attack audio file
	public AudioClip hurt; //Audio file for player getting hurt
	public AudioClip coinPickUp;
	public GameObject deathParticle;
	private GameObject player;

	public Transform groundCheck; //Checks if player is on the ground
	public float groundCheckRadius; //Radius of which the ground check is in
	public LayerMask whatIsGround; // Assigning what the groundcheck is reacting to with certain layers labeled "Ground"
	private bool grounded; // Says "yes" or "no" the player is on the ground

    public Rigidbody2D rb2d;
	public int health = 3;
	public int maxHealth = 3; //Player health stats 
	private bool deathCheck; //Checks if player is dead
	public GameObject respawn;
	public GameObject gameOverlay; //Game Over Screen layout



    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> (); //Setting the animator
		gameOverlay.SetActive (false);
		audio = GetComponent<AudioSource>(); // Getting access to audio
		bow = false;
		Sword = true;

    }


	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

	}

   
    void Update () {
	
		if (grounded) {
			doubleJump = false;
		}

		anim.SetBool ("Grounded", grounded);

		if (Input.GetKeyDown (KeyCode.W) && grounded) { //Using SpaceBar to jump and only allows player to jump on ground
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
			audio.PlayOneShot (jumping, 1.0f);
		}

		if (Input.GetKeyDown (KeyCode.W) && !doubleJump && !grounded) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight); 
			audio.PlayOneShot (jumping, 1.0f);
			doubleJump = true;
		}

		if (Input.GetKey (KeyCode.D)) {
			rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
		}

		if (Input.GetKey (KeyCode.A)) {
			rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);
		}

		anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x)); //Setting the float for the walk animation

		if (rb2d.velocity.x > 0) {


			transform.localScale = new Vector3 (.4f, .4f, .4f);
		} else if (rb2d.velocity.x < 0) { //flipping the player animations
			transform.localScale = new Vector3 (-.4f, .4f, .4f);
		}

		if (health <= 0) {
			Debug.Log ("Restart Screen");
			StartCoroutine ("DelayedRestart");
		}

		if (Input.GetKeyDown (KeyCode.R) && deathCheck) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		if (!deathCheck) {
			Time.timeScale = 1;
		}

		if (anim.GetBool ("Sword")) {
			anim.SetBool ("Sword", false);
		}

		if (Input.GetKey (KeyCode.Space)) {
			anim.SetBool ("Sword", true);
		}

		if (Input.GetKeyDown (KeyCode.J)) {
			Instantiate (arrow, firePoint.position, firePoint.rotation);
			audio.PlayOneShot (bowattack, 1.0f);
		}
			
	}	

		


	void OnTriggerEnter2D(Collider2D col)
	{ 
		if (col.CompareTag ("Killzone")) { // When player collides with KillZone
			transform.position = respawn.transform.position;
			health -= 1;
		}

		if (col.CompareTag ("Enemy")) { // Colliding with enemy
			health -= 1;		
			audio.PlayOneShot(hurt,2.0f);
		}		

		if (col.CompareTag ("Bow")) {
			bow = true;
		}

		if (col.CompareTag ("Point")) {
			audio.PlayOneShot (coinPickUp, 1.0f);
		}
	}

	void Death () {
		deathCheck = true;
		gameOverlay.SetActive (true);

		if (deathCheck)
		{
			Time.timeScale = 0;
		}
	}

	IEnumerator DelayedRestart () 
	{
		yield return new WaitForSeconds (1);

		Death ();

	}

    void OnTriggerStay2D(Collider2D other) // Ladder
    {
        float vert = Input.GetAxis("Vertical");

        if (other.CompareTag("Ladder") && vert > 0)
        {
            

            rb2d.gravityScale = 0;
            transform.Translate(0, vert * climbSpeed, 0);
        }
    }

}
