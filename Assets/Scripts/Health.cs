using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Health : MonoBehaviour
{
	public AudioSource aud;
	public bool forPlayer = false;
	public Image bar;
    string lastReason;
	public float health;
	public AudioSource hurtedSound;
	public float healthForBar;
	public Text txt;
	float damagePower;
	float damageGot;
	public GameObject death;
	public GameObject main;
	public Animator animk;
	Movement move;
	Health healt;
	GameObject player;
	public GameObject uiMain;
	public GameObject uiDeath;
	public bool thisIsFakeKubby;
	public HealthReaction react;
	bool barAnimate = false;
	float healthForBarAnimate;
	float lastHealth;
	JoystickScript joyst;
	public SoundLow lowsound;
	public GameObject[] cutscenes;
    ///fake kubby
	public GameObject fakeKubbyKicked;
	BoxCollider2D box;
	public GameObject anim;
	public bool itsFake;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		box = GetComponent<BoxCollider2D>();
			player = GameObject.FindGameObjectWithTag("Player");
        healt = GetComponent<Health>();
		move = GetComponent<Movement>();
		joyst = GetComponent<JoystickScript>();
		///if(forPlayer == true)anim = GetComponent<Animator>();
    }
    void FixedUpdate()
	{
		if (forPlayer == true)
		{
			txt.text = health + "%";

			if (barAnimate == false)
			{
				ShowHealth();
			}
			else
			{
				healthForBarAnimate -= 1 * Time.deltaTime;
				ShowHealthAnimate();
			}

			if (health < 1)
			{
				lowsound.gettingLow = true;
				move.enabled = false;
				if(lastReason == "spikes" || lastReason == "bullet")
				{
					death.SetActive(true);
				    death.transform.position = transform.position;
				}
				if(lastReason == "fakeKubby")
				{
					cutscenes[0].SetActive(true);
				}
				main.SetActive(false);
				healt.enabled = false;
			}
		}
		else
		{
			if(health < 1)
			{
				death.SetActive(true);
				death.transform.position = transform.position;
				player.GetComponent<VictoryWindow>().killedFakeKubby += 1;
				main.SetActive(false);

				healt.enabled = false;


			}

		}
	}
	void Damage(float damageInt)
	{
		float damagePower2;
		damagePower2 = damagePower * 100;
		transform.localPosition += transform.right * damagePower * Time.deltaTime;
		lastHealth = health;
		health -= damageInt;
		if (forPlayer == false)
		{
			///animk.Play("ouch");
			if(itsFake == true)
			{
				anim.SetActive(false);
				fakeKubbyKicked.SetActive(true);
				fakeKubbyKicked.transform.position = transform.position;
				fakeKubbyKicked.GetComponent<Rigidbody2D>().AddForce(new Vector3(damagePower2, 0, 0));
				box.enabled = false;
			}
		}
		else
		{


			ReadyToShowHealthAnimate();
			if (Gamepad.current != null)
			{
				Gamepad.current.SetMotorSpeeds(0.123f, 0.234f);
				Gamepad.current.SetMotorSpeeds(0f, 0f);
			}
			joyst.OneSecondOfHeaven();
			react.DamageUIAnimate(damagePower);

		}
		aud.Play();
	}
    // это для отображения количества хп для игрока.
    void ShowHealth()
    {
        healthForBar = health / 100;
		bar.fillAmount = healthForBar;
		txt.text = health + "%";
    }
	void ReadyToShowHealthAnimate()
	{
		barAnimate = true;

		healthForBar = health / 100;
		healthForBarAnimate = lastHealth / 100;

	}
	void ShowHealthAnimate()
    {

		if (healthForBarAnimate < healthForBar)
		{
			barAnimate = false;
			bar.fillAmount = healthForBar;

		}
		else
		{
			bar.fillAmount = healthForBarAnimate;

		}

    }
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "triggerShootingAgroMan")
		{
			coll.gameObject.GetComponent<TriggerShootingAgroMan>().Activate();
		}

		if(coll.tag == "fallPartTrig")
		{
			coll.GetComponent<FallingPlatform>().rot.enabled = false;
			coll.GetComponent<FallingPlatform>().anim.Play("fallingPlatform");
			Destroy(coll.gameObject);
		}
		if(coll.tag == "cutTrig")
		{
		    coll.GetComponent<CutscenesTrigger>().Activate();
			Destroy(coll.gameObject);

		}
		if(coll.tag == "dam")
		{
			damageGot = coll.gameObject.GetComponent<Damage>().minus;

            lastReason = coll.gameObject.GetComponent<Damage>().reason;
			coll.gameObject.GetComponent<Damage>().Collided();

			damagePower = coll.gameObject.GetComponent<Damage>().powerFloat;

			Damage(damageGot);
			///damagePower = damagePower * 100;

			if(coll.gameObject.GetComponent<Damage>().exclusiveThing == "thing")
			{
			  ///Destroy(coll.gameObject.GetComponent<Damage>().parent);
        coll.gameObject.GetComponent<Damage>().Collided();

				GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
				GetComponent<FakeKubby>().anim.Play("whatIsThatFakeKubby");
        GetComponent<FakeKubby>().dirTrig.SetActive(true);
				GetComponent<FakeKubby>().maxTime = 2;
				GetComponent<FakeKubby>().time = 0;
			  Destroy(GetComponent<FakeKubby>().triggerDetector);
				GetComponent<FakeKubby>().detect = true;
				GetComponent<FakeKubby>().GetComponent<AudioSource>().Play();
				if (Gamepad.current != null)
				{
					Gamepad.current.SetMotorSpeeds(0f, 0f);
				}
			}
			else
			{
				///transform.localPosition += transform.right * damagePower * Time.deltaTime;

			}
		}
		if(coll.tag == "holeKill")
		{
       if(forPlayer == true)
			 {
				 uiMain.SetActive(false);
				 uiDeath.SetActive(true);
			 }
			 else
			 {
				 health = 0;
			 }
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "triggerShootingAgroMan")
		{
			coll.gameObject.GetComponent<TriggerShootingAgroMan>().Deactivate();
		}
		if(coll.tag == "triggerObj")
		{
			coll.gameObject.GetComponent<TriggerGameObject>().Deactivate();
		}
	}
}
