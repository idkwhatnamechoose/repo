using UnityEngine;

public class PlayerOuch : MonoBehaviour
{
	float dir;
	Transform tr;
	Vector3 vec;
	float force;
	Shadow shad;
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "dam")
		{
			Debug.Log("ai");
			tr = coll.GetComponent<Damage>().obj;
			
			vec = tr.localScale;
			dir = vec.x;
			
			force = dir * coll.GetComponent<Damage>().forceThrow;
			force = force;
			Debug.Log("ai" + force);
			transform.localPosition += transform.right * force * Time.deltaTime;
		}
		if(coll.tag == "oldKubbyTrigger")
		{
			coll.GetComponent<OldKubby>().Open(true);
		}
		if(coll.tag == "Shadow")
		{
			shad.ImInShadow();
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "oldKubbyTrigger")
		{
			coll.GetComponent<OldKubby>().Open(false);
		}
		if(coll.tag == "Shadow")
		{
			shad.QuitShadow();
			
		}
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shad = GetComponent<Shadow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
