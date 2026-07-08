using UnityEngine;

public class UseHand : MonoBehaviour
{
	public bool use = false;
	public GameObject controllers;
	public bool pc = true;
	public GameObject buttonUse;
	public GameObject useObj;
	public Attack att;
	public GameObject joystickUse;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(use == true)
		{
			
			controllers.SetActive(false);
			GetComponent<Movement>().enabled = false;
			att.enabled = false;
			GetComponent<AnimatorKubby>().turnOff = true;
			GetComponent<JumpEnabler>().Enable(false);
			GetComponent<Inventory>().enabled = false;
		}
		if(use == false)
		{
			if(pc == false)
			{
				controllers.SetActive(true);
			}
			att.enabled = true;
			GetComponent<Movement>().enabled = true;
			GetComponent<AnimatorKubby>().turnOff = false;
			///GetComponent<JumpEnabler>().Enable(true);
			///GetComponent<Inventory>().enabled = true;
		}
		if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton3))
	  {
			if(use == false)
			{
				Click();
			}
		}
    }
	public void Click()
	{
		if(useObj.GetComponent<Use>().item == "dialog")
		{
			if(useObj.GetComponent<Use>().dial.endedDialog != true)
			{
				use = true;
				useObj.GetComponent<Use>().Using();
			}
		}
		if(useObj.GetComponent<Use>().item == "drag")
		{
			useObj.GetComponent<Use>().Using();
		}
		if(useObj.GetComponent<Use>().item == "emergencyDialog")
		{
			use = true;
		}
		if(useObj.GetComponent<Use>().item == "dialogNew")
		{
			if(useObj.GetComponent<Use>().dial2.endedDialog != true)
			{
				use = true;
				useObj.GetComponent<Use>().Using();
			}
		}
		if(useObj.GetComponent<Use>().item == "dial")
		{
			use = true;
			useObj.GetComponent<Use>().Using();
		}
		useObj.GetComponent<Use>().Using();
		
	}
    void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "use")
		{
			coll.gameObject.GetComponent<Use>().Detect(true);
			buttonUse.SetActive(true);
			useObj = coll.gameObject;
			joystickUse.SetActive(true);
		}
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.tag == "use")
		{
			coll.gameObject.GetComponent<Use>().Detect(false);
			buttonUse.SetActive(false);
			useObj = null;
			joystickUse.SetActive(false);
		}
	}
}
