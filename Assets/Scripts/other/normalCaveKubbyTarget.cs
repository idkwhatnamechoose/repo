using UnityEngine;

public class normalCaveKubbyTarget : MonoBehaviour
{
	public normalCaveKubby caveKubby;
	
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(1 == 1)
		{
			
		}
    }
	
	
	void OnCollisionEnter2D(Collider2D coll)
	{
		Debug.Log("test");
		if(coll.tag == "CaveKubbyZone")
		{
			Debug.Log("пещерный кубби в зоне");
			caveKubby.isWorking = false;
		}
	}
	
}
