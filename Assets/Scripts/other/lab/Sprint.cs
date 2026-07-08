using UnityEngine;

public class Sprint : MonoBehaviour
{
	Movement move;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
	    {
		    move.staminaActivated = true;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			move.staminaActivated = false;
		}
    }
}
