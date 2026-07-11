using UnityEngine;

public class CutscenesTrigger : MonoBehaviour
{
    public Animator anim;
	bool alreadyUsed = false;
	
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
		   Activate();
		}
	}
    public void Activate()
	{
	   if(alreadyUsed == false)
	   {
	      anim.SetTrigger("start");
		  alreadyUsed = true;
		  Debug.Log("cutscene activated");
	   }
	}
}
