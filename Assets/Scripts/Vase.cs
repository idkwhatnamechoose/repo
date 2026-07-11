using UnityEngine;

public class Vase : MonoBehaviour
{
	public GameObject broken;
	float timer;
	bool notOnTheFloor = false;
	bool work = false;
	private void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "dam")
		{
			if(work == true)
			{
				broken.SetActive(true);
			    broken.transform.position = transform.position;
			    Destroy(this.gameObject);
			}
			
		}
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
		if(timer > 1)
		{
			
			work = true;
		}
    }
	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			if(work != false)
			{
				notOnTheFloor = true;
			}
		}
	}
    void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			if(work == true && notOnTheFloor == true)
			{
				broken.SetActive(true);
			    broken.transform.position = transform.position;
			    Destroy(this.gameObject);
			}
		}
	}
	
}
