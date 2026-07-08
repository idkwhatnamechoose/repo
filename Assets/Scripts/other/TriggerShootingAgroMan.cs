using UnityEngine;

public class TriggerShootingAgroMan : MonoBehaviour
{
    public ShootingAgroMan boss;
    public AgroCleaner cleaner;
	public string type = "left"; ///right,up,detector - типы триггеров фейкового кубби 
	public bool distanceCorrected = false; 
	public bool isWorker = false;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(type == "attack")
		{
			
		}
    }
	public void Activate()
	{
		if(type == "left")
		{
			if(isWorker == false)
			{
				boss.ChangeDirection(-1);
			}
			else
			{
				cleaner.ChangeDirection(true);
			}
			
			
		}
		if(type == "right")
		{
			if(isWorker == false)
			{
				boss.ChangeDirection(1);
			}
			else
			{
				cleaner.ChangeDirection(false);
			}
		}
		if(type == "detector")
		{
			
			if(isWorker == false)
			{
				boss.Detected();
			}
			else
			{
				cleaner.Detected();
			}
			Destroy(this.gameObject);
		}
		if(type == "attack")
		{

			if(isWorker == false)
			{
				boss.kubbyIsHere = true;
			}
			else
			{
				cleaner.kubbyIsHere = true;
			}
		}
	}
	public void Deactivate()
	{
		if(type == "attack")
		{
			if(isWorker == false)
			{
				boss.kubbyIsHere = false;
			}
			else
			{
				cleaner.kubbyIsHere = false;
			}
		}
	}
	public void WhyDidUJumpOnMyHead()
	{
		///boss.anim.Play("attackHead");
	}
}
