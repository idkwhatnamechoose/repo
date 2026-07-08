using UnityEngine;

public class Sit : MonoBehaviour
{
	public BoxCollider2D box;
	public CircleCollider2D circle;
	public bool mode;
	Movement move;
	public Animator anim;
	bool underGround;
	public Attack att;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
		
        if(mode == true)
		{
			box.enabled = false;
			circle.enabled = true;
			move.jumpForce = 0f;
			move.staminaActivated = false;
			att.enabled = false;
			anim.SetBool("sit", true);
			if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.JoystickButton1))
			{
				///if(underGround == false)mode = false;
			}
		}
		else
		{
			att.enabled = true;
			box.enabled = true;
			circle.enabled = false;
			move.jumpForce = 450f;
			anim.SetBool("sit", false);
		}
    }
	public void SitDown(bool state)
	{
		if(mode == true)
		{
			if(underGround == false)
			{
				mode = false;
				move.jumpForce = 450f;
			}
		}
		else
		{
			anim.Play("sitIdle");
			mode = true;
			move.jumpForce = 0f;
		}
	}
	public void JumpCheck()
	{
		if(underGround == false)
		{
			mode = false;
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Sit")
		{
			underGround = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "Sit")
		{
			underGround = false;
		}
	}
}
