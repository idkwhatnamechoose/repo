using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int health = 3;
	public GameObject deathObj;
	public bool useOldDeath = true;
	public Animator anim;
	FakeKubby fake;
    public FakeKubbyBoss boss; 
	bool sayToBoss = true;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fake = GetComponent<FakeKubby>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
		{
		    if(useOldDeath == true)
			{
			    deathObj.SetActive(true);
				deathObj.transform.position = transform.position;
				Destroy(this.gameObject);
			}
			else
			{
			    fake.enabled = false;
			    anim.SetBool("death", true);
				if(boss != null)
				{
				   if(sayToBoss == true)
				   {
				      boss.SpawnFake();
					  sayToBoss = false;
				   }
				   GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
				   GetComponent<BoxCollider2D>().enabled = false;
				}
				
			}
		}
    }
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "dam")
		{
			health -= 1;
		}
	}
}
