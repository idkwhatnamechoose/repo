using UnityEngine;

public class CameraPosition : MonoBehaviour
{
	public Transform target;
	public float speed = 2f;
	public int smoothNeeded = 1;
	public bool smoothAtTheStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
			smoothNeeded = PlayerPrefs.GetInt("smoothCamera");
			speed = 0.5f;
        if(smoothAtTheStart == false)transform.position = target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
			if(smoothNeeded == 0)
			{
				transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.fixedDeltaTime);
			}
      else
			{
				transform.position = target.position;
			}
    }
}
