using UnityEngine;

public class AnimatorFunct : MonoBehaviour
{
    public FakeKubbyBoss boss;
	public FakeKubby fake;
	public EnemyHealth health;
	public Rigidbody2D rb;
	AnimatorFunct animFunct;
	public LookAtTarget fakeHelper;
	
	//для того, чтобы "включить" фейка
    public void WakeUpFake()
	{
        if(fake != null)
		{
		   fake.enabled = true;
		   fake.Boss();
		   health.enabled = true;
		   fakeHelper.enabled = true;
		   rb.isKinematic = false;
		}
		else
		{
		   Debug.Log("бро, где фейк?");
		}
	}
	//для спавна фейков(обращается к боссу)
	public void Boss()
	{
	   if(boss != null)
	   {
	      boss.SpawnFake();
	   }
	   else
	   {
		  Debug.Log("бро, где босс?");
	   }
	}
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    animFunct = GetComponent<AnimatorFunct>();
		
        if(animFunct != null)
		{
		   rb.isKinematic = true;
		   fake.enabled = false;
		   health.enabled = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
