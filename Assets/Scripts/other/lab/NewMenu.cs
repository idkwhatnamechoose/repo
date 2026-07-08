using UnityEngine;
using UnityEngine.UI;
public class NewMenu : MonoBehaviour
{
	public string[] buttonCommand;
	public GameObject[] buttonVariable1;
	Animator anim; 
	public bool turnOff = false;
	
	public void Click(int but)
	{
	    if(turnOff == false)
	    {
		   if(buttonCommand[but] == "OpenOtherMenu")
		    {
		    	anim.Play("menuHide");
			    buttonVariable1[but].GetComponent<Animator>().Play("menuShow");
				turnOff = true;
				buttonVariable1[but].GetComponent<NewMenu>().turnOff = false;
		    }
	    }
		
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        anim = GetComponent<Animator>();
		if(turnOff == true)
		{
			anim.Play("menuHide");
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
