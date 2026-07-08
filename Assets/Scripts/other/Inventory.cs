using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
	bool joystick = false;
	public  GameObject cursor;
  public int itemsCollected;
  public Transform[] pointsWhereUIItems;
  public GameObject[] uiElement;
  public Sprite spriteItem;
  public string[] typeOfItems;
  public Animator anim;
  public string[] WhatCorrectlyIsThisItems;
  ///public bool sayAllInteractableThings = false;
  ///public string whatToSatAllInteractableThings;
  public string currentThingOnMyHand;
  public Sprite[] spriteItems;
  public GameObject item;
  public Animator animOfTablets;
  Health hp;
  public Damage dam;
  public GameObject buttonUse;
  int currentItemNeedNow;
  public GameObject[] dropObjs;
  public GameObject unknownObj;
  Vector3 playerSize;
  public GameObject plSize;
  public float throwForce;
  public Transform handPosition;
  public BootsController boots;
  bool open;
  
  public void ChooseItem(int itemNum)
  {
    currentItemNeedNow = itemNum;
    if(typeOfItems[itemNum] != "nothing")
    {
      if(WhatCorrectlyIsThisItems[itemNum] == "Таблетки")
      {
         animOfTablets.Play("animTabletsIdle");
         animOfTablets.Play("animTablets");
         currentItemNeedNow = itemNum;
         currentItemNeedNow -= 1;
         typeOfItems[itemNum] = "nothing";
         itemsCollected = currentItemNeedNow;
         uiElement[itemNum].SetActive(false);
         hp.health = 110;
         dam.gameObject.SetActive(true);
         dam.minus += 10;
         dam.gameObject.SetActive(false);
         currentItemNeedNow = 0;
      }
      else
      {
        item.GetComponent<SpriteRenderer>().enabled = true;
        item.GetComponent<SpriteRenderer>().sprite = spriteItems[itemNum];
        buttonUse.SetActive(true);
      }
    }
    else
    {
        item.GetComponent<SpriteRenderer>().enabled = false;
        boots.type = "nothing";
    }
  }
  public void Throw()
  {
    if(currentItemNeedNow != 0)
    {
      item.GetComponent<SpriteRenderer>().enabled = false;
        buttonUse.SetActive(false);

        uiElement[currentItemNeedNow].SetActive(false);
        dropObjs[currentItemNeedNow].SetActive(true);
        if(playerSize.x == 1)
        {
          dropObjs[currentItemNeedNow].transform.position = handPosition.position;
          dropObjs[currentItemNeedNow].GetComponent<Rigidbody2D>().AddForce(new Vector3(throwForce, 100, 0));
        }
        if(playerSize.x == -1)
        {
          dropObjs[currentItemNeedNow].transform.position = handPosition.position;
          dropObjs[currentItemNeedNow].GetComponent<Rigidbody2D>().AddForce(new Vector3(-throwForce, 100, 0));
        }
        currentItemNeedNow -= 1;
        typeOfItems[currentItemNeedNow] = "nothing";
        itemsCollected = currentItemNeedNow;
        //
        currentItemNeedNow = 0;
    }

  }
  public void AddItem(string itemType)
  {
    string currentItemType = itemType;
    if(itemsCollected < 5)
    {
      itemsCollected += 1;
      if(typeOfItems[itemsCollected] != "busy")
      {
        if(itemType == "Зелёные ботинки")
        {
           boots.type = "green";
           Destroy(unknownObj);

        }
        else if(itemType == "Жёлтые перчатки")
        {
           boots.type = "yellow";
           Destroy(unknownObj);

        }
		else if(itemType == "Фиолетовые ботинки")
        {
           boots.type = "purple";
           Destroy(unknownObj);

        }
		else if(itemType == "Бордовые перчатки")
        {
		   dam.gameObject.SetActive(true);
		   dam.minus = 25;
           boots.type = "bord";
           Destroy(unknownObj);

        }
        else
        {
          uiElement[itemsCollected].SetActive(true);
          uiElement[itemsCollected].GetComponent<Image>().sprite = spriteItem;
          spriteItems[itemsCollected] = spriteItem;
          WhatCorrectlyIsThisItems[itemsCollected] = itemType;
          dropObjs[itemsCollected] = unknownObj;
          unknownObj = null;
          dropObjs[itemsCollected].SetActive(false);
          typeOfItems[itemsCollected] = "busy";
        }

      }
      else
      {
        AddItem(currentItemType);
      }
    }

  }
  public void HideItemForFuturePlans(GameObject whatObj)
  {
    unknownObj = whatObj;
  }
  public void AddItem()
  {

  }
  public void UseItem()
  {

  }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		
      hp = GetComponent<Health>();
    }
    
    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.JoystickButton2))
		{
			Throw();
			
			
			
			
		}
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			Debug.Log("tab keycode has been pressed");
			if(open == false)
			{
				open = true;
				anim.Play("inventoryShow");
			}
			else
			{
				open = false;
				anim.Play("inventoryHide");
				
			}
		}
		
		if(Input.GetJoystickNames()[0] != "")
		{
			anim.Play("inventoryShow");
			joystick = true;
		}
		if(joystick == true)
		{
			cursor.SetActive(true);
		}
		
        playerSize = plSize.transform.localScale;
    }
}
