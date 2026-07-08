using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
public class JoystickScript : MonoBehaviour
{
	float time;
	bool resume = false;
	Movement move;
	
	 private DualShock4GamepadHID ds4Gamepad;

        void Awake()
        {
			Debug.Log("Connected joystics: " + Input.GetJoystickNames()[0]);
			
			move = GetComponent<Movement>();
			
            // Find the first connected DualShock 4 gamepad
            ds4Gamepad = InputSystem.GetDevice<DualShock4GamepadHID>();

            if (ds4Gamepad == null)
            {
                Debug.LogWarning("DualShock 4 Gamepad not found.");
            }
			 if (ds4Gamepad != null)
             {
                 // Example: Set light bar to red
                 ds4Gamepad.SetLightBarColor(Color.grey);
         
                 // Example: Set light bar to blue if a specific button is pressed
                 if (ds4Gamepad.buttonWest.wasPressedThisFrame) // Assuming 'buttonWest' is the Square button
                 {
                     ds4Gamepad.SetLightBarColor(Color.blue);
                 }
             }
        }
		public void Victory()
		{
			ds4Gamepad.SetLightBarColor(Color.green);
		}
	public void OneSecondOfHeaven()
	{
		ds4Gamepad.SetLightBarColor(Color.red);
		ds4Gamepad.SetLightBarColor(Color.red);
		time = 0;
		Gamepad.current.SetMotorSpeeds(0.123f, 0.234f);
		ds4Gamepad.SetLightBarColor(Color.red);
		resume = true;
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ///Gamepad.current.SetLightBarColor(Color.red);
		move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey(KeyCode.JoystickButton7))
		{
			if(move.stamina < 2)move.staminaActivated = true;
			Debug.Log("stamina activated");
		}
		if(Input.GetKeyUp(KeyCode.JoystickButton7))
		{
			move.staminaActivated = false;
		}
		if(Input.GetKey(KeyCode.JoystickButton6))
		{
			if(move.stamina < 2)move.staminaActivated = true;
			Debug.Log("stamina activated");
		}
		if(Input.GetKeyUp(KeyCode.JoystickButton6))
		{
			move.staminaActivated = false;
		}
		
		for (int i = 0; i < 4; i++)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal1")) > 0.2 ||
                Mathf.Abs(Input.GetAxis("Vertical1")) > 0.2)
            {
                Debug.Log(Input.GetJoystickNames()[i] + " is moved");
            }
        }
		if(resume == true)
		{
			time += 1 * Time.deltaTime;
			if(time > 0.5)
		    {
				ds4Gamepad.SetLightBarColor(Color.white);
			   Gamepad.current.SetMotorSpeeds(0f, 0f);
			   resume = false;
		    }
		    else
			{
				ds4Gamepad.SetLightBarColor(Color.red);
				Gamepad.current.SetMotorSpeeds(0.123f, 0.234f);
			}
		}
		
        
    }
}
