using UnityEngine;

public class Drag : MonoBehaviour
{
	public GameObject obj;
	public bool dragNow;
	public bool pc;
	public Transform handPoint;
	public Transform dropPoint;
	public float force;
	public float forceY;
	bool forcing;
	BoxCollider2D trig;
	public GameObject size;
	float realForce;
	public GameObject boomEffect;
	
	public void Boom()
	{
		
	}
	public void StartForcing()
	{
		
	}
	public void StopForcing()
	{
		
	}

	public void Drop()
	{
		float scale;
		Vector3 transformSize;
		transformSize = size.transform.localScale;
		scale = transformSize.x;
		
		
		dragNow = false;
		obj.transform.position = dropPoint.position; 
        obj.transform.rotation = dropPoint.rotation;
		obj.GetComponent<BoxCollider2D>().enabled = true;
		realForce = force * scale;
		obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(realForce, forceY, 0));
		Debug.Log("Бросили предмет!");
		trig.GetComponent<BoxCollider2D>().enabled = true;
		obj.GetComponent<DragProperties>().Dropped();
		if(obj.GetComponent<Dynamite>().enabled == true)
		{
			obj.GetComponent<Dynamite>().canBoom = true;
		}
		
		trig = null;
        obj = null;	
	}
	public void Take(GameObject takeObj, BoxCollider2D trigg)
	{
		if(dragNow == true)
		{
			Drop();
		}
		
		trig = trigg;
		trig.GetComponent<BoxCollider2D>().enabled = false;
		obj = takeObj;
		
		obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
	    obj.GetComponent<BoxCollider2D>().enabled = false;
	    obj.transform.position = handPoint.position;
	    obj.transform.rotation = handPoint.rotation;
		dragNow = true;
	}
	void FixedUpdate()
	{
		if(dragNow == true)
		{
			obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			obj.GetComponent<BoxCollider2D>().enabled = false;
			obj.transform.position = handPoint.position;
			obj.transform.rotation = handPoint.rotation;
			if(Input.GetKeyDown(KeyCode.Q))
			{
				Drop();
			}
		}
	}
}
