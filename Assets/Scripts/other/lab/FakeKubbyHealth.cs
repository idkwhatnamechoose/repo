using UnityEngine;

public class FakeKubbyHealth : MonoBehaviour
{
	public int health = 2;
	public GameObject anim;
	public GameObject kickedFakeKubby;
	bool kicked;
	BoxCollider2D box;
	public float kickForce = 100;
  public Transform posForKickedFakeKubby;
	public bool onFloor;
	float time;
	void Damage(float kickPower)
	{
		float finalPower = kickPower * kickForce;
		health -= 1;
		if(health != 0)
		{
			box.enabled = false;
			anim.SetActive(false);
			kickedFakeKubby.SetActive(true);
			kickedFakeKubby.transform.position = posForKickedFakeKubby.position;
			kickedFakeKubby.GetComponent<Rigidbody2D>().AddForce(new Vector3(finalPower, 250, 0));
		}
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kicked == false)
				{
					anim.SetActive(true);
					kickedFakeKubby.SetActive(false);
					box.enabled = true;
				}
				if(kicked == true)
				{
					if(onFloor == false)
					{
						time = 0;
					}
					else
					{
						time += 1 * Time.deltaTime;
						if(time > 2)
						{
							transform.position = kickedFakeKubby.transform.position;
							kicked = false;
						}
					}
				}
    }
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "dam")
		{
			Debug.Log("ouch!");
			Damage(coll.GetComponent<Damage>().dir);
		}
	}
}
