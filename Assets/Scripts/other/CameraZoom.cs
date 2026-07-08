using UnityEngine;
using Unity.Cinemachine;
public class CameraZoom : MonoBehaviour
{
	public float zoom = 0f;
	float scroll;
	public Camera cam;
	///public CinemachineCamera camCinemat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Joystick()
	{
		
		if (Input.GetKey(KeyCode.JoystickButton4))
        {
			if(zoom < 100f)
			{
				zoom += 2f;
			}
			
            Debug.Log("Scrolled up!");
        }
        else if (Input.GetKey(KeyCode.JoystickButton5))
        {
            Debug.Log("Scrolled down!");
			if(zoom > 60)
			{
				zoom -= 2f;
				
			}
        }
	}
    // Update is called once per frame
    void FixedUpdate()
    {
		Joystick();
		///cam.fieldOfView = zoom;
        scroll = Input.mouseScrollDelta.y;
        
        if (scroll > 0f)
        {
			if(zoom < 90f)
			{
				zoom += 20f;
			}
			
            Debug.Log("Scrolled up!");
        }
        else if (scroll < 0f)
        {
            Debug.Log("Scrolled down!");
			if(zoom > 60)
			{
				zoom -= 20f;
				
			}
        }
    }
}
