using UnityEngine;

public class AgroCityImportantHead : MonoBehaviour
{
	public GameObject mainObj;
	public GameObject deathObj;
	
	
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
		if(coll.gameObject.tag == "Player")
		{
			HeadTouched();
		}
	}
	public void HeadTouched()
	{
		Debug.Log("голова тронута!!");
		deathObj.SetActive(true);
		deathObj.transform.position = mainObj.transform.position;
		mainObj.SetActive(false);
	}
}
