using UnityEngine;

public class JoyStickButtonHelp : MonoBehaviour
{
	bool show;
	public GameObject sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetJoystickNames()[1] == "")
		{
			sprite.SetActive(false);
		}
    }
}
