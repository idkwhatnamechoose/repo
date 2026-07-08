using UnityEngine;

public class Dynamite : MonoBehaviour
{
	public bool canBoom;
	public GameObject boomEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor" || coll.gameObject.tag == "fake")
		{
			if(canBoom == true)
			{
				Instantiate(boomEffect, transform.position, transform.rotation);
				Destroy(this.gameObject);
			}
		}
	}
}
