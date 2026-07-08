using UnityEngine;

public class Jump : MonoBehaviour
{
	public float jumpForce;
	public float jumpForceGreenBoots;
	Movement move;
	public Rigidbody2D rb;
	public bool canJump;
	public GameObject player;
	public BootsController boots;
	bool floating = true;
	float rbScale;
	bool tryingToGetOutTheWater;
	public float defaultGravityScale = 2f;
	public float waterGravityScale = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = GetComponent<Movement>();
		///boots = GetComponent<BootsController>();
		///player = this.gameObject;
		////rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		
        if(Input.GetButtonDown("Jump"))
		{
			tryingToGetOutTheWater = true;
			JumpNow();
			tryingToGetOutTheWater = true;
		}
		if(floating == true)
		{
			rb.gravityScale = rbScale;
			rbScale = waterGravityScale;
		}
		if(floating == false)
		{
			rb.gravityScale = defaultGravityScale;
		}
    }
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			canJump = true;
		}
		if(coll.gameObject.tag == "agroHead")
		{
			coll.gameObject.GetComponent<AgroCityImportantHead>().HeadTouched();
		}
		
	}
	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			canJump = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			canJump = false;
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Water")
		{
			floating = true;
		}
		if(coll.tag == "Grass")
		{
			coll.gameObject.GetComponent<Grass>().isTouchingGrass = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "Water")
		{
			floating = false;
		}
		if(coll.tag == "Grass")
		{
			coll.gameObject.GetComponent<Grass>().isTouchingGrass = false;
			Debug.Log("GRASS TOUCHED!");
		}
	}
	
	public void JumpNow()
	{
		if(canJump == true)
		{
			player.GetComponent<Sit>().JumpCheck();
			    player.GetComponent<AnimatorKubby>().Jump();
			    rb.AddForce(Vector3.up * jumpForce);
			
		}
		
	}
}
