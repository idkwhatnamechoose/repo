using UnityEngine;

public class BoxTiktok : MonoBehaviour
{
	public float spid = 7f;
	public bool run;
	
	public void HrukatIUbegat()
	{
		GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, 600f, 0f));
		run = true;
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(run == true)
		{
			transform.localPosition += transform.right * spid * Time.deltaTime;
		}
    }
}
