using UnityEngine;

public class AgroCleaner : MonoBehaviour
{
	public BoxCollider2D box;
	public Rigidbody2D rb;
	public bool isAngry = false;
	public Animator anim;
	public float speed = 2f;
	float realSpeed;
	public bool kubbyIsHere;
	public GameObject[] legs;
	public void ChangeDirection(bool currentDir)
	{
		///TRUE = лево, FALSE = право
		if(currentDir == true)
		{
			realSpeed = -speed;
		}
		if(currentDir == false)
		{
			realSpeed = speed;
		}
	}
    void Start()
    {
        
    }
    public void Detected()
    {
    	isAngry = true;
    }
    void FixedUpdate()
    {
        if(isAngry == true)
        {
			rb.bodyType = RigidbodyType2D.Dynamic;
			box.enabled = true;
        	transform.localPosition += transform.right * realSpeed * Time.fixedDeltaTime;
        	anim.SetBool("angry", true);
        	if(kubbyIsHere == true)
        	{
        		anim.SetTrigger("attack");
        		legs[0].SetActive(true);
				legs[1].SetActive(false);
        	}
        	else
        	{
        		
				legs[0].SetActive(false);
				legs[1].SetActive(true);
        	}
        }
        if(isAngry == false)
        {
			rb.bodyType = RigidbodyType2D.Kinematic;
			box.enabled = false;
        	anim.SetBool("angry", false);
        	legs[1].SetActive(false);
			legs[1].SetActive(false);
        }
    }
}
