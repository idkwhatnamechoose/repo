using UnityEngine;
using UnityEngine.UI;
public class Dreams : MonoBehaviour
{
	public Text txt;
	public Animator dreamUI;
	
	void Dream(string context)
	{
		dreamUI.Play("idle");
		dreamUI.Play("dream");
		txt.text = context;
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "dream")
		{
			Dream(coll.GetComponent<DreamsTrigger>().dreamcontext);
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "dream")
		{
			StopDreaming();
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
	void StopDreaming()
	{
		dreamUI.Play("stop");
	}
}
