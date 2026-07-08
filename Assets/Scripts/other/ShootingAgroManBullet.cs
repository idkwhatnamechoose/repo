using UnityEngine;

public class ShootingAgroManBullet : MonoBehaviour
{
	float realSpeed;
	public float speed;
	public float size;
	public bool forFakeKubby = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(forFakeKubby == true)
		{
			realSpeed = speed * size;
			transform.localPosition += -transform.right * realSpeed *  Time.deltaTime;
			
		}
		else
		{
			transform.localPosition += -transform.right * speed *  Time.deltaTime;
		}
		///transform.localScale = new Vector3(size, 1, 1);
        
    }
}
