using UnityEngine;

public class AgroCityMan : MonoBehaviour
{
	public Dialog dial;
	public bool walkAway = false; //будет ли у жителя цель уйти
	public bool willHeWalkAwayAfterTalk = false; //будет ли житель уходить к endPointToGo после разговора с игроком?
	public Transform startPointToGo; //до разговора
	public Transform endPointToGo; //после разговора
	public float speed;
	public Transform animParent;
	public bool turnLeftAfterTalk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		if(walkAway == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, startPointToGo.position, speed);
		}
        
    }

    // Update is called once per frame
    void Update()
    {
        if(willHeWalkAwayAfterTalk == true)
		{
			if(dial.endedDialog == true)
			{
				if(turnLeftAfterTalk == false)
				{
					animParent.localScale = new Vector3(-1, 1, 1);
				}
				else
				{
					animParent.localScale = new Vector3(1, 1, 1);
				}
				transform.position = Vector3.MoveTowards(transform.position, endPointToGo.position, speed);
			}
		}
    }
}
