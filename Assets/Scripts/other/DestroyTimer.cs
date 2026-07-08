using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
	public float timer;
	float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += 1 * Time.fixedDeltaTime;
		if(time > timer)
		{
			Destroy(this.gameObject);
		}
    }
}
