using UnityEngine;

public class Elevator : MonoBehaviour
{
	public GameObject parent;
	public Animator anim;
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			anim.SetBool("up", true);
		}
		
	}
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("PlayerParent");
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
