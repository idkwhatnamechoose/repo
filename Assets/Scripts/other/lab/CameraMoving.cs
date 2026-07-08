using UnityEngine;

public class CameraMoving : MonoBehaviour
{
	Animator anim;
	bool moving;
	Quaternion rotate1;
	Quaternion rotate2;
	public float speed = 3f;
	public Transform helper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal"))
		{
			moving = true;
		}
		else if(Input.GetButtonUp("Horizontal"))
		{
			moving = false;
		}
		if(moving == true)
		{
			
		}
		Rotating();
    }
    void Rotating()
	{
		float dir = Input.GetAxis("Horizontal") * 10f;
		helper.rotation = Quaternion.Euler(0f, 0f, dir);
		Quaternion rot;
		rot = helper.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed);		
	}
}
