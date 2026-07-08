using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Movement : MonoBehaviour
{
	Rigidbody2D rb;
	public string character = "kubby";
	public float defaultRbScale;
	public BootsController boots;
	public float speed = 5f;
	public float maxSpeed;
	public bool sit = false;
	public int going = 0;
	public bool canRun = true;
	public bool pc = true;
	public float jumpForce = 250f;
	public bool canJump;
	public Animator anim;
	public float stamina = 100f;
	public float maxStamina = 100f;
	public float acceleration = 0f;
	public float accelerationSpeed = 0f;
	public Image staminaBar;
	public bool running;
	public bool staminaActivated = false;
	public float staminaForText;
	public float staminaForText2;
	public Text txtStamina;
	public GameObject tired;
	public float jumpForceGreenBoots = 350f;
	public float jumpForceForPC = 100f;
	Animator animka;
	bool inWater;
	bool gettingOutTheWater;
	float rbScale = 1f;
	float time;
	float ax;
	float staminaCD = 0f;
	////Для игры FilPast
	public bool filPastMode;
	
	public bool joystick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		maxSpeed = speed;
		if(character == "kubby")
		{
			maxStamina = 100f;
			stamina = maxStamina;
			accelerationSpeed = 0f;
		}else if(character == "fake")
		{
			maxStamina = 300f;
			stamina = maxStamina;
			accelerationSpeed = 0.3f;
		}

        rb = GetComponent<Rigidbody2D>();
    }
	void JoystickMovement()
	{
		ax = Input.GetAxis("Horizontal");
		///Debug.Log("" + ax);
		
		if(ax != 0)
		{
			running = true;
			if(ax > 0)
		    {
			    going = 1;
		    }
		    if(ax < 0)
		    {
			    going = -1;
		    }
		}
		else
		{
			running = false;
			going = 0;
			
		}
		
	}
	void FixedUpdate()
	{
		staminaCD -= Time.fixedDeltaTime;
		if(Input.GetButtonDown("Jump"))
		{
			///Debug.Log("pressed");
			///Jump();
		}
		if(joystick == true)
		{
			JoystickMovement();
		}
		if(stamina < 40f)
		{
			tired.SetActive(true);
		}
		else
		{
			tired.SetActive(false);
		}
		if(inWater == true)
		{
			///rb.gravityScale = 0.05f;
			///time += 1 * Time.deltaTime;
			///if(time > 0)
			///{
			///	if(rb.gravityScale != 0)
			///	{
			///		rbScale -= 300 * Time.fixedDeltaTime;
			///	}
			///	if(rbScale < 0)
			///	{
			///		rbScale = 0;
			///	}
			///	rb.gravityScale = rbScale;
			///}
			if(gettingOutTheWater == true)
			{
				rb.gravityScale = -0.05f;
			}
			else
			{
				rb.gravityScale = 0.05f;
			}
		}
		if(inWater == false)
		{
			rb.gravityScale = defaultRbScale;

		}
		
		
		///stamina = Mathf.Round(stamina);
		staminaForText2 = Mathf.Round(stamina);
		if(character == "kubby")
		{
			staminaForText = stamina / 100;
		}
		else if(character == "fake")
		{
			staminaForText = stamina / 300;
		}
		txtStamina.text = staminaForText2 + "%";
		staminaBar.fillAmount = staminaForText;
		if(pc == true)
		{
			PCInput();
		}
		MobileInput();
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			///Jump();
		}
		if(staminaActivated == true && canRun == true)
		{
			if(boots.type == "purple")
		    {
				speed = 15f;
		    }
		    else
		    {
				speed = 10f;
		    }

			if(character == "kubby")
			{
				acceleration = 0f;
			}
			else if(character == "fake")
			{
				acceleration += accelerationSpeed * Time.deltaTime;
			}
			
			anim.SetBool("running", true);
			if(running == true)
			{
				if(boots.type == "purple")
				{
					
				}
				else
				{
					stamina -= 20f * Time.deltaTime;
				    if(stamina < 1f)
				    {
					    staminaActivated = false;
						staminaCD = 10f; // Set cooldown period
				    }
				}

			}
			if(running == false)
		    {
				if(stamina < maxStamina)stamina += 6f * Time.fixedDeltaTime;
		    }
		}
		else
		{
			acceleration = 0f;
		}

		if(Input.GetKey(KeyCode.W))
		{
			
		}
		else if(Input.GetKeyUp(KeyCode.W))
		{
			///Jump();
		}
		
		
		if(staminaActivated == false)
		{
			speed = 5f;
			anim.SetBool("running", false);
			if(stamina < maxStamina)stamina += 6f * Time.fixedDeltaTime;
		}
		if(Input.GetKey(KeyCode.LeftShift) && stamina > 1 && staminaCD <= 0)
		{
			staminaActivated = true;
		}
		else
		{
			staminaActivated = false;
		}
		

	}
    void PCInput()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.localPosition += -transform.right * (speed + acceleration) * Time.deltaTime;

		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.localPosition += transform.right * (speed + acceleration) * Time.deltaTime;

		}

		
        if(Input.GetButton("Horizontal"))
		{
			running = true;
		}
		if(Input.GetButtonUp("Horizontal"))
		{
			running = false;
		}
	}

	public void Jump()
	{
		if(canJump == true)
		{
		if(boots.type == "green")
		{
			rb.AddForce(new Vector3(0f, jumpForceGreenBoots, 0f));
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
		if(boots.type == "nothing")
		{
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
		if(boots.type == "purple")
		{
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
    if(boots.type == "yellow")
		{
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
		if(boots.type == "bord")
		{
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
		}
		
	}
	public void JumpPC()
	{
		if(canJump == true)
		{
		if(boots.type == "green")
		{
			rb.AddForce(new Vector3(0f, jumpForceGreenBoots, 0f), ForceMode2D.Impulse);
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
		if(boots.type == "nothing")
		{
			rb.AddForce(new Vector3(0f, jumpForceForPC, 0f), ForceMode2D.Impulse);
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
		if(boots.type == "purple")
		{
			rb.AddForce(new Vector3(0f, jumpForceForPC, 0f));
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
    if(boots.type == "yellow")
		{
			rb.AddForce(new Vector3(0f, jumpForceForPC, 0f));
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
		if(boots.type == "bord")
		{
			rb.AddForce(new Vector3(0f, jumpForceForPC, 0f));
			gettingOutTheWater = true;
			GetComponent<AnimatorKubby>().Jump();
			GetComponent<Sit>().JumpCheck();
		}
		}
	}
    // Update is called once per frame
    void MobileInput()
    {
        if(going == -1)
		{
			transform.localPosition += -transform.right * (speed + acceleration) * Time.deltaTime;
		}
		if(going == 1)
		{
			transform.localPosition += transform.right * (speed + acceleration) * Time.deltaTime;
		}
    }
	public void Press(int num)
	{
		going = num;
		if(going == 0)
		{
			running = false;
		}
		else
		{
			running = true;
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			canJump = true;
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
		if(coll.tag == "CaveKubbyTrigger")
		{
			canJump = false;
			GetComponent<AnimatorKubby>().startWalking = false;
			animka = GetComponent<AnimatorKubby>().anim;
			GetComponent<AnimatorKubby>().enabled = false;
			animka.SetBool("walking", false);
			animka.SetBool("falling", false);
			animka.SetBool("running", false);
			animka.SetBool("sit", false);
			coll.gameObject.GetComponent<normalCaveKubby>().Collided();
			transform.localPosition += transform.up * 100f * Time.deltaTime;
			
		}
		if(coll.tag == "triggerFakeKubby")
		{
			coll.gameObject.GetComponent<TriggerFakeKubby>().Activate();
		}
		if(coll.tag == "triggerShow")
		{
			coll.gameObject.GetComponent<ShowTrigger>().Show();
		}
		if(coll.tag == "triggerSafeKubby")
		{
			canJump = false;
			GetComponent<AnimatorKubby>().startWalking = false;
			animka = GetComponent<AnimatorKubby>().anim;
			GetComponent<AnimatorKubby>().enabled = false;
			animka.SetBool("walking", false);
			animka.SetBool("falling", false);
			animka.SetBool("running", false);
			animka.SetBool("sit", false);
			transform.localPosition += transform.up * 100f * Time.deltaTime;
			coll.gameObject.GetComponent<SaveCaveKubby>().Detected();
		}
		if(coll.tag == "triggerWindows")
		{
			coll.gameObject.GetComponent<Windows2011>().Detected();
		}
		if(coll.tag == "Water")
		{
			rbScale = 1f;
			inWater = true;
			gettingOutTheWater = false;
		}
		if(coll.tag == "triggerCaveKubby")
		{
			canJump = false;
			going = 0;
			anim.SetBool("running", false);
			anim.SetBool("walking", false);
			coll.gameObject.GetComponent<FakeKubby1>().Detected();
		}
		if(coll.tag == "triggerFakeKubbyHead")
		{
			coll.gameObject.GetComponent<TriggerFakeKubby>().WhyDidUJumpOnMyHead();
			Jump();
			rb.AddForce(new Vector3(0f, 400f, 0f));
			GetComponent<Health>().health -= 25;
		}
		if(coll.tag == "triggerObj")
		{
			coll.gameObject.GetComponent<TriggerGameObject>().Activate();		
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "Water")
		{
			rbScale = defaultRbScale;
			inWater = false;
			gettingOutTheWater = true;
		}
		if(coll.tag == "triggerObj")
		{
			coll.gameObject.GetComponent<TriggerGameObject>().Deactivate();		
		}
	}
}
