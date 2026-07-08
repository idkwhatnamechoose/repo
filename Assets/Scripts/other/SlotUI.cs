using UnityEngine;
using UnityEngine.UI;
public class SlotUI : MonoBehaviour
{
	public GameObject emptyPaper;
	public GameObject newPaper;
	public RawImage paper;
	public Texture[] faces;
	public GameObject[] writtenParts;
	public int slotNumber;
	int activated;
	string emergencyVar;
	int written;
	int worriedRightNow;
	public Text txt;
	bool writtenShowing = false;
	public GameObject selectTheKubbies;
	public GameObject slotInfo;
	string character;
	SlotUI slot;
	public int money;
	public Text moneyText;
	void Start()
	{
		
		slot = GetComponent<SlotUI>();
		if(slotNumber == 1)
		{
			written = PlayerPrefs.GetInt("slot1Written");
			money = PlayerPrefs.GetInt("slot1Money");
			activated = PlayerPrefs.GetInt("slot1");
			character = PlayerPrefs.GetString("slot1Character");
		    if(activated == 1)
		    {
		    	txt.text = "";
				WrittenShow();
				
		    }
			else
			{
				txt.text = "-EMPTY-";
			}
		}
		if(slotNumber == 2)
		{
			money = PlayerPrefs.GetInt("slot2Money");
			
			written = PlayerPrefs.GetInt("slot2Written");
			activated = PlayerPrefs.GetInt("slot2");
			character = PlayerPrefs.GetString("slot2Character");
		    if(activated == 1)
		    {
		    	txt.text = "";
				WrittenShow();
		    }
			else
			{
				txt.text = "-EMPTY-";
			}
		}
		if(slotNumber == 3)
		{
			money = PlayerPrefs.GetInt("slot3Money");
			written = PlayerPrefs.GetInt("slot3Written");
			activated = PlayerPrefs.GetInt("slot3");
			character = PlayerPrefs.GetString("slot3Character");
		    if(activated == 1)
		    {
		    	txt.text = "";
				WrittenShow();
		    }
			else
			{
				txt.text = "-EMPTY-";
			}
		}
	}
	void WrittenShow()
	{
		newPaper.SetActive(true);
		writtenShowing = true;
	}
	public void Reload()
	{
		slotInfo.SetActive(false);
		if(slotNumber == 1)
		{
			written = PlayerPrefs.GetInt("slot1Written");
			money = PlayerPrefs.GetInt("slot1Money");
			activated = PlayerPrefs.GetInt("slot1");
			character = PlayerPrefs.GetString("slot1Character");
		    if(activated == 1)
		    {
		    	txt.text = "";
				WrittenShow();
		    }
			else
			{
				txt.text = "-EMPTY-";
				WrittenHide();
			}
		}
		if(slotNumber == 2)
		{
			money = PlayerPrefs.GetInt("slot2Money");
			written = PlayerPrefs.GetInt("slot2Written");
			activated = PlayerPrefs.GetInt("slot2");
			character = PlayerPrefs.GetString("slot2Character");
		    if(activated == 1)
		    {
		    	txt.text = "";
				WrittenShow();
		    }
			else
			{
				txt.text = "-EMPTY-";
				WrittenHide();
			}
		}
		if(slotNumber == 3)
		{
			money = PlayerPrefs.GetInt("slot3Money");
			written = PlayerPrefs.GetInt("slot3Written");
			activated = PlayerPrefs.GetInt("slot3");
			character = PlayerPrefs.GetString("slot3Character");
		    if(activated == 1)
		    {
		    	txt.text = "";
				WrittenShow();
		    }
			else
			{
				txt.text = "-EMPTY-";
				WrittenHide();
			}
		}
	}
	public void Load()
	{
		if(activated == 1)
		{
			slotInfo.SetActive(true);
			moneyText.text = "" + money;
			slotInfo.GetComponent<SavesSystem>().sLot = slotNumber;
			slotInfo.GetComponent<SavesSystem>().ReloadSlotSetGameObject(slot);
			
		}
		else
		{
		    selectTheKubbies.SetActive(true);
			selectTheKubbies.GetComponent<SavesSystem>().sLot = slotNumber;
			selectTheKubbies.GetComponent<SavesSystem>().ReloadSlotSetGameObject(slot);
		}
	}
	void FixedUpdate()
	{
		
		if(writtenShowing == true)
		{
			if(character == "faker")
			{
				paper.texture = faces[0];
			}
			else
			{
				paper.texture = faces[1];
			}
			worriedRightNow += 1;
			if(worriedRightNow > written)
			{
				writtenShowing = false;
			}
			else
			{
				writtenParts[worriedRightNow].SetActive(true);
			}
		}
	}
	void WrittenHide()
	{
		newPaper.SetActive(false);
		writtenParts[0].SetActive(false);
		writtenParts[1].SetActive(false);
		writtenParts[2].SetActive(false);
		writtenParts[3].SetActive(false);
		writtenParts[4].SetActive(false);
		writtenParts[5].SetActive(false);
		writtenParts[6].SetActive(false);
		writtenParts[7].SetActive(false);
		writtenParts[8].SetActive(false);
		writtenParts[9].SetActive(false);
	}
}
