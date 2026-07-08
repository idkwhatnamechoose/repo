using UnityEngine;
using Unity.Cinemachine;

public class Use : MonoBehaviour
{
	public Animator chargingAnim;
	public GameObject button;
	public Dialog dial;
	public DialogRework dial2;
	public Animator buttonAnim;
	public string item;
	public bool deleteAfterUse;
	public bool detected;
	///свойства предмета
	public string itemName;
	public string itemNameEn;
	public string itemNameSpan;
	public string description;
	public Sprite itemPhoto;
	public ItemGot gotItem;
	public GameObject gotItemObj;
	GameObject inv;
	public AudioClip clip;
	public Dialog2 dial3;
	public GameObject mainObj;
	public GameObject yellowBoots;
    public bool show;
	bool startToTeleport;
	float timeToTeleport;
	///teleport properties
	public Transform point;
	public Animator uiTransition;
	public GameObject cam;
	public BoxTiktok boxTik;
	public BoxCollider2D newCamZone;
	BoxCollider2D box;
	public void Detect(bool state)
	{
		///button.SetActive(state);
		if(state == true && show == true)
		{
			buttonAnim.Play("detect");
			if(item == "emergencyDialog")
			{
				inv.GetComponent<UseHand>().use = true;
				dial3.Click();
				if(deleteAfterUse == true)
			    {
			    	Destroy(this.gameObject);
			    }
			}
		}
		else
		{
			buttonAnim.Play("undetect");
		}
	}
	public void Using()
	{
		if(item == "box")
		{
			inv.GetComponent<BoxInteractable>().Drag(mainObj, this.gameObject);
		}
		if(item == "dialog")
		{
			if(dial.endedDialog == false && show == true)
			{
				dial.Click();
				if(deleteAfterUse == true)
			    {
			    	Destroy(this.gameObject);
			    }
			}
			
			
			///button.SetActive(false);

		}
		if(item == "dial")
		{
			if(show == true)
			{
				dial3.Click();
			}
			if(deleteAfterUse == true)
			{
				Destroy(this.gameObject);
			}
		}
		if(item == "dialogNew")
		{
			if(dial2.endedDialog == false)
			{
				dial2.Click();
				if(deleteAfterUse == true)
			    {
			    	Destroy(this.gameObject);
			    }
			}
			
			
			///button.SetActive(false);

		}
		if(item == "item")
		{
			gotItemObj.GetComponent<ItemGot>().Name = itemName;
			gotItemObj.GetComponent<ItemGot>().Description = description;
			gotItemObj.GetComponent<ItemGot>().spr = itemPhoto;
			inv.GetComponent<Inventory>().spriteItem = itemPhoto;
			gotItemObj.GetComponent<ItemGot>().Show(clip);
			inv.GetComponent<Inventory>().HideItemForFuturePlans(mainObj);
			inv.GetComponent<Inventory>().AddItem(itemName);


			///Destroy(this.gameObject);
		}
		if(item == "teleport")
		{
			timeToTeleport = 0;
			startToTeleport = true;
			uiTransition.Play("show");
		}
		if(item == "drag")
		{
			inv.GetComponent<Drag>().Take(mainObj, box);
			Unused();
			
		}
		if(item == "tiktok1")
		{
			boxTik.HrukatIUbegat();
			
		}
		if (item == "energy")
		{
			if (yellowBoots.GetComponent<YellowBots>().enabled == true)
			{
				if (yellowBoots.GetComponent<YellowBots>().energy < 80)
				{
					chargingAnim.Play("recharge");
					yellowBoots.GetComponent<YellowBots>().energy = 100;
				}
				
			}
			
			
		}
	}
	public void Unused()
	{
		///button.SetActive(true);
		buttonAnim.Play("undetect");
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		gotItemObj = GameObject.FindGameObjectWithTag("itemgot");
		inv = GameObject.FindGameObjectWithTag("Player");
		yellowBoots = GameObject.FindGameObjectWithTag("Player");
		cam = GameObject.FindGameObjectWithTag("CameraSettings");
		box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if(startToTeleport == true)
		{
			timeToTeleport += 1 * Time.deltaTime;
			if(timeToTeleport > 2)
			{
				inv.transform.position = point.position;
				cam.GetComponent<CinemachineConfiner2D>().BoundingShape2D = newCamZone;
				startToTeleport = false;
			}
		}
         if(detected == false)
				 {

				 }
				 else
				 {

				 }
    }
	
}
