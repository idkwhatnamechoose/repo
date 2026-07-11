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
			var joystickNames = Input.GetJoystickNames();
			if (joystickNames.Length > 0)
			{
				Debug.Log("Connected joystics: " + joystickNames[0]);
			}
			
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
		if (ds4Gamepad != null)
		{
			ds4Gamepad.SetLightBarColor(Color.red);
			ds4Gamepad.SetLightBarColor(Color.red);
			ds4Gamepad.SetLightBarColor(Color.red);
		}
		time = 0;
		if (Gamepad.current != null)
		{
			Gamepad.current.SetMotorSpeeds(0.123f, 0.234f);
		}
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
		
		// Try to detect joystick movement using standard axes
		try
		{
			for (int i = 0; i < 4; i++)
			{
				try
				{
					if (Mathf.Abs(Input.GetAxis("Horizontal1")) > 0.2 ||
					    Mathf.Abs(Input.GetAxis("Vertical1")) > 0.2)
					{
						if(i < Input.GetJoystickNames().Length)
							Debug.Log(Input.GetJoystickNames()[i] + " is moved");
					}
				}
				catch { }
			}
		}
		catch { }
		if(resume == true)
		{
			time += 1 * Time.deltaTime;
			if(time > 0.5)
		    {
				if (ds4Gamepad != null)
				{
					ds4Gamepad.SetLightBarColor(Color.white);
				}
				if (Gamepad.current != null)
				{
					Gamepad.current.SetMotorSpeeds(0f, 0f);
				}
			   resume = false;
		    }
		    else
			{
				if (ds4Gamepad != null)
				{
					ds4Gamepad.SetLightBarColor(Color.red);
				}
				if (Gamepad.current != null)
				{
					Gamepad.current.SetMotorSpeeds(0.123f, 0.234f);
				}
			}
		}
		
        
    }
}
