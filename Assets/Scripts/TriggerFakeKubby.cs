using UnityEngine;

public class TriggerFakeKubby : MonoBehaviour
{
	public FakeKubby boss;
	public string type = "left"; ///left, right, up, detector - типы триггеров фейкового кубби 
	BoxCollider2D box;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(boss.enabled == false)
		{
		   box.enabled = false;
		}
		else
		{
			box.enabled = true;

		}
    }
	public void Activate()
	{
		if(type == "left")
		{
			boss.ChangeDirection(1);
			boss.runSpeed = 2f;
		}
		if(type == "right")
		{
			boss.ChangeDirection(-1);
			boss.runSpeed = -2f;
		}
		if(type == "detector")
		{
			boss.Detected();
			Destroy(this.gameObject);
		}
		if(type == "attack")
		{
			boss.anim.Play("attack1");
		}
	}
	public void WhyDidUJumpOnMyHead()
	{
		boss.anim.Play("attackHead");
		boss.detect = true;
		boss.time = 1;
	}
}
