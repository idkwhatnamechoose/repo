using UnityEngine;

public class Damage : MonoBehaviour
{
	public float minus;
	public float dir;
	public Transform obj;
	public string componentCode = "transform";
	GameObject objWithoutTransform;
	Vector3 vec;
	public string exclusiveThing = "punch";
	public GameObject parent; ///это должен быть обьект use(1)
  public float forceThrow;
  float forceThrowX;
  public float powerFloat;
  public string reason;
  public bool destroyAfterUse = false;
	public void Collided()
	{

		if(dir == 1)
		{
			forceThrowX = 1 * forceThrow;
		}
		else if(dir == -1)
		{
			forceThrowX = -1 * forceThrow;
			
		}
        powerFloat = powerFloat * dir;
		if(exclusiveThing == "thing")
		{
			parent.GetComponent<Rigidbody2D>().AddForce(new Vector3(forceThrowX, forceThrow, 0));
			GetComponent<BoxCollider2D>().enabled = false;
		}
		if(destroyAfterUse == true)
		{
			Destroy(this.gameObject);
		}

	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
			if(componentCode == "transformOnce")
			{
				vec = obj.localScale;
		dir = vec.x;
			}

		if(componentCode == "player")
		{
			objWithoutTransform = GameObject.FindGameObjectWithTag("Player");
			vec = objWithoutTransform.transform.localScale;
	dir = vec.x;
		}
    }

    // Update is called once per frame
    void Update()
    {
			if(componentCode == "transform")
			{
				vec = obj.localScale;
		        dir = vec.x;
			}

    }
		void OnCollisionEnter2D(Collision2D coll)
		{
			if(coll.gameObject.tag == "floor")
			{
				if(exclusiveThing == "thing")GetComponent<BoxCollider2D>().enabled = true;
			}
		}
}
