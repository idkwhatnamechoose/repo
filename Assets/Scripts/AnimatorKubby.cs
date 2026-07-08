using UnityEngine;

public class AnimatorKubby : MonoBehaviour
{
	public Animator anim;
	public Transform rot;
	public bool startWalking = false;
	public float rotateFloat;
	public bool joystick;
	public bool turnOff = false;
	public bool filPastMode = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void Jump()
		{
			///для анимации прыжка
			anim.SetBool("falling", true);
			anim.Play("jumpKubby");
		}
	void JoystickMovement()
	{
	   float ax = Input.GetAxis("Horizontal");
	   ///Debug.Log("" + ax);
	   
	   if(ax != 0 && turnOff == false)
	   {
	       anim.SetBool("walking", true);
		   if(ax > 0)
		   {
			   if(filPastMode == false)
			   {
				   	 rot.localScale = new Vector3(1, 1, 1);

				   
			   }
			   else
			   {
				   
				    rot.localScale = new Vector3(0.33969f, 0.33969f, 0.33969f);

			   }
			   anim.SetBool("walking", true);
			   startWalking = true;
		   }
		   if(ax < 0)
		   {
			   if(filPastMode == false)
			   {
				   	 rot.localScale = new Vector3(-1, 1, 1);

				   
			   }
			   else
			   {
				   
				    rot.localScale = new Vector3(-0.33969f, 0.33969f, 0.33969f);

			   }
			   anim.SetBool("walking", true);
			   startWalking = true;
			   
		   }
	   }
	   else
	   {
		   anim.SetBool("walking", false);
		   startWalking = false;
	   }
		
	}
    // Update is called once per frame
    void FixedUpdate()
    {
		
        JoystickMovement();
		if(startWalking == true)
		{
			anim.SetBool("walking", true);
		}
		else if(startWalking == false)
		{
			anim.SetBool("walking", false);
		}

    }
	public void Animating(bool boolean)
	{
		startWalking = boolean;
	}
	public void Rotate(float rotate)
	{
		rot.localScale = new Vector3(rotate, 1f, 1f);
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			anim.SetBool("falling", false);
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "dam")
		{
		   anim.Play("ouchKubby");
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			///anim.SetBool("falling", true);
		}
	}
}
