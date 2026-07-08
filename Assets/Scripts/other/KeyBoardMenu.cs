using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.Events;
public class KeyBoardMenu : MonoBehaviour
{
	int current;
	public int howManyButtons;
	public GameObject[] buttons;
	public GameObject cursor;
	public bool useKeyBoard = true;
	bool move;
	public string dir = "Horizontal";
	public float dirSpeed = 1f;
	public KeyCode key = KeyCode.JoystickButton6;
	public bool useMyKeycode;
	public bool hideCursorIfControllerIsInvalid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(hideCursorIfControllerIsInvalid == true)
		{
			if(Input.GetJoystickNames()[0] != "")
		    {
		    	cursor.SetActive(true);
		    }
		    else
		    {
		    	cursor.SetActive(false);
		    }
		}
    }
    void JoystickControll()
	{
		float hor = Input.GetAxis(dir) * dirSpeed;
		
		
		if(hor != 0)
		{
			
			if(hor > 0)
		    {
				if(move == true)
				{
					current -= 1;
			        if(current < 0)
			        {
				       current = howManyButtons;
			        }
					move = false;
				}
		    	
		    }
		    if(hor < 0)
		    {
				if(move == true)
				{
					current += 1;
			        if(current > howManyButtons)
			        {
			        	current = 0;
			        }
					move = false;
				}
		    	
		    }
		}
		else
		{
			move = true;
		}
	}
    // Update is called once per frame
    void Update()
    {
		
		
		JoystickControll();
		cursor.transform.position = Vector3.Lerp(cursor.transform.position, buttons[current].transform.position, 10f * Time.fixedDeltaTime);
		
        if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			current -= 1;
			if(current < 0)
			{
				current = howManyButtons;
			}
		}
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.JoystickButton3))
		{
			current += 1;
			if(current > howManyButtons)
			{
				current = 0;
			}
		}	
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton1))
		{
			Click();
		}
        if(Input.GetKeyDown(key))
		{
			if(useMyKeycode == true)
			{
				Click();
			}
		}		
    }
	void Click()
	{
		 buttons[current].GetComponent<KeyBoardButton>().Use();
	}
}
