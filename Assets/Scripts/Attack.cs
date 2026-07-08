using UnityEngine;

public class Attack : MonoBehaviour
{
	public Transform main;
	public BootsController boots;
	Animator anim;
	public int kickNum;
	public Health hp;
	
	public bool pc = false;
	public bool imFakeKubby = false;
	public Movement move;
	public Sit sitScript;
	public YellowBots yellowBoots;
	public Transform spawner;
	public GameObject fakeKubbyBullet;
	public bool isActive = true;
	public bool stop;
	public bool playingAttackAnimation = false;
	bool canPutArmorOn = true;
	
	float timer;
	
	public void Shoot()
	{
		playingAttackAnimation = false;
		Vector3 plScale;
		plScale = main.localScale;
		GameObject spawnedBullet = Instantiate(fakeKubbyBullet, spawner.position, spawner.rotation);
		spawnedBullet.GetComponent<ShootingAgroManBullet>().size = plScale.x;
	}
	public void EnableHealth()
	{
	   hp.enabled = true;
	    stop = false;
	   playingAttackAnimation = false;
	   
	}
	public void Hit()
	{
		if(isActive == true)
		{
			if(boots.type == "yellow")
		{
			string animationName;
			animationName = "hit1Kubby";
			anim.Play(animationName);
			yellowBoots.Shoot();
			
		}
		else
		{
			if(imFakeKubby == true)
		    {
		    	string animationName;
		    	animationName = "shootFakeKubby";
		    	anim.Play(animationName);
		    	///yellowBoots.Shoot();
				///Shoot();
				
		    	
		    }
			else
			{
				stop = true;
				kickNum = Random.Range(1, 4);
			
			string animationName;
			animationName = "hit" + kickNum + "Kubby";
			anim.Play(animationName);
			}
			
		}
		}
		

	}
	public void Shield(bool state)
	{
	  if(canPutArmorOn == true)
	  {
	     timer = 0;
	     anim.SetTrigger("shield");
	     hp.enabled = false;
		 stop = true;
		 playingAttackAnimation = true;
		
	     canPutArmorOn = false;
	  }
	  
	}
    void Start()
    {
		pc = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
	    if(canPutArmorOn == false)
		{
		   timer += 1 * Time.deltaTime;
		   if(timer > 3)
		   {
		      canPutArmorOn = true;
		   }
		}
		if(canPutArmorOn == true)
		{
		   timer = 0;
		}
        if(pc == true)
				{
					if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton0))
					{
						Hit();
					}
					if(Input.GetKeyDown(KeyCode.Mouse1))
					{
						Shield(true);
					}
					
				}
		if(playingAttackAnimation == true)
		{
			
			move.speed = 0f;
			
		}

		if(playingAttackAnimation == false)
		{
			if(stop == true)
			{
				move.speed = move.maxSpeed;
			}
			stop = false;
		}
    }
}
