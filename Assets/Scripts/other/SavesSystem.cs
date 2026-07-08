using UnityEngine;
using UnityEngine.UI;
public class SavesSystem : MonoBehaviour
{
	public string type = "level";
	public Animator saveIcon;
	public int slot = PlayerPrefs.GetInt("loadedSlot");
	public float loadedHealth;
	string varSave1;
	public int coins;
	public int sLot;
	public SlotUI currentSlotBusy;
	public GameObject characterWindow;
	public GameObject loadScreen;
	bool timerOn;
	float timer;
	public Text textCoins;
	int level;
	public int levels;
	public string levelTitle;
	public int whatTheLevel;
	public void ReloadSlotSetGameObject(SlotUI slot)
	{
		currentSlotBusy = slot;
	}
	public void ReloadSlot()
	{
		characterWindow.SetActive(true);
		currentSlotBusy.Reload();
	}
	public void DeleteSlot()
	{
		if(sLot == 1)
		{
			PlayerPrefs.SetInt("slot1", 0);
			PlayerPrefs.DeleteKey("slot1Character");
		}
		if(sLot == 2)
		{
			PlayerPrefs.SetInt("slot2", 0);
			PlayerPrefs.DeleteKey("slot2Character");
		}
		if(sLot == 3)
		{
			PlayerPrefs.SetInt("slot3", 0);
			PlayerPrefs.DeleteKey("slot3Character");
		}
		ReloadSlot();
	}
	public void NewSlotSave(bool fakeKubby)
	{
		if(sLot == 1)
		{
			PlayerPrefs.SetInt("escapedLevels1", 1);
			PlayerPrefs.SetInt("slot1", 1);
			if(fakeKubby == true)
			{
				PlayerPrefs.SetString("slot1Character", "faker");
			}
			else
			{
				PlayerPrefs.SetString("slot1Character", "kubby");
			}
		}
	    if(sLot == 2)
		{
			PlayerPrefs.SetInt("escapedLevels2", 1);
			PlayerPrefs.SetInt("slot2", 1);
			if(fakeKubby == true)
			{
				PlayerPrefs.SetString("slot2Character", "faker");
			}
			else
			{
				PlayerPrefs.SetString("slot2Character", "kubby");
			}
		}
		if(sLot == 3)
		{
			PlayerPrefs.SetInt("slot3", 1);
			PlayerPrefs.SetInt("escapedLevels3", 1);
			if(fakeKubby == true)
			{
				PlayerPrefs.SetString("slot3Character", "faker");
			}
			else
			{
				PlayerPrefs.SetString("slot3Character", "kubby");
			}
		}
		ReloadSlot();
		
	}
	public void StartLevel()
	{
		string levelName = "Level" + levels;
	   PlayerPrefs.SetInt("loadedSlot", sLot);
	   loadScreen.SetActive(true);
       timerOn = true;
	   timer = 0;
	   Application.LoadLevel(levelName);	   
	}
	public void StartCustomLevel(int selected)
	{
		string levelName = "Level" + selected;
	   PlayerPrefs.SetInt("loadedSlot", sLot);
	   loadScreen.SetActive(true);
       timerOn = true;
	   timer = 0;
	   Application.LoadLevel(levelName);
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		
		if(type == "level")
		{
			slot = PlayerPrefs.GetInt("loadedSlot");
			if(slot == 1)
			{
				coins = PlayerPrefs.GetInt("slot1Coins");
				levels = PlayerPrefs.GetInt("escapedLevels1");
				
			}
			if(slot == 2)
			{
				coins = PlayerPrefs.GetInt("slot2Coins");
				levels = PlayerPrefs.GetInt("escapedLevels2");
			}
			if(slot == 3)
			{
				coins = PlayerPrefs.GetInt("slot3Coins");
				levels = PlayerPrefs.GetInt("escapedLevels3");
			}
		}
		if(type == "menu")
		{
			if(slot == 1)
			{
				coins = PlayerPrefs.GetInt("slot1Coins");
			    levels = PlayerPrefs.GetInt("escapedLevels1");
			}
			if(slot == 2)
			{
				coins = PlayerPrefs.GetInt("slot2Coins");
				levels = PlayerPrefs.GetInt("escapedLevels2");
			}
			if(slot == 3)
			{
				coins = PlayerPrefs.GetInt("slot3Coins");
				levels = PlayerPrefs.GetInt("escapedLevels3");
			}
		}
        ///loadScreen = GameObject.FindGameObjectWithTag("Loading");
		
    }
	public void NextLevel()
	{
		string savePath;
		whatTheLevel += 1;
		if(whatTheLevel > levels)
		{
			savePath = "escapedLevels" + slot;
			PlayerPrefs.SetInt(savePath, whatTheLevel);
		}
	    Application.LoadLevel(levelTitle + whatTheLevel);
		
	}
    void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "coin")
		{
			coll.GetComponent<Coin>().Detected();
		}
	}
    // Update is called once per frame
    void Update()
    {
        if(timerOn == true)
		{
			timer += 1 * Time.deltaTime;
			if(timer > 1)
			{
				Application.LoadLevel("Level1");
				
			}
		}
		if(type == "level")
		{
			textCoins.text = "" + coins;
		}
    }
	public void SaveCoins()
	{
		if(slot == 1)
		{
			PlayerPrefs.SetInt("slot1Coins", coins);
		}
		if(slot == 2)
		{
			PlayerPrefs.SetInt("slot2Coins", coins);
		}
		if(slot == 3)
		{
			PlayerPrefs.SetInt("slot3Coins", coins);
		}
	}
}
