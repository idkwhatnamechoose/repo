using UnityEngine;

public class KeyBoardButton : MonoBehaviour
{
	public string command;
	public string levelName;
	public GameObject gameObj;
	public Pause _pause;
	public Inventory inv;
	public int slotNumber;
	public Animator anim1;
	public Animator anim2;
	public string animation1String;
	public string animation2String;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Use()
	{
		if(command == "playTwoAnimations")
		{
			anim1.Play(animation1String);
			anim2.Play(animation2String);
		}
		if(command == "level")
		{
			Application.LoadLevel(levelName);
		}
		if(command == "hideGameObject")
		{
			gameObj.SetActive(false);
			
		}
		if(command == "unpause")
		{
			///gameObj.SetActive(false);
			_pause.Resume();
		}
		if(command == "restart")
		{
			_pause.RestartLevel();
		}
		if(command == "inventorySlot")
		{
			inv.ChooseItem(slotNumber);
		}
	}
}
