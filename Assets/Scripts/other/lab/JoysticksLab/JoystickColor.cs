using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
public class JoystickColor : MonoBehaviour
{
	public Color startColor;
	public Color colorLight;
	public Animator anim;
	public int mode;
	private DualShock4GamepadHID ds4Gamepad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         ds4Gamepad = InputSystem.GetDevice<DualShock4GamepadHID>();

            if (ds4Gamepad == null)
            {
                Debug.LogWarning("DualShock 4 Gamepad not found.");
            }
			 if (ds4Gamepad != null)
             {
                 // Example: Set light bar to red
                 ds4Gamepad.SetLightBarColor(startColor);
         
                 // Example: Set light bar to blue if a specific button is pressed
                 
             }
    }

    // Update is called once per frame
    void Update()
    {
        if(mode != 0)
		{
			anim.Play("lightJoystick" + mode);
			ds4Gamepad.SetLightBarColor(colorLight);
		}
    }
}
