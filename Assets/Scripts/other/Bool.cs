using UnityEngine;
using UnityEngine.UI;
public class Bool : MonoBehaviour
{
  public int state = 0;
  int getstate;
  public string saveVariable;
  public Image boolImg;
  public Sprite spriteOn;
  public Sprite spriteOff;
  public bool testBool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getstate = PlayerPrefs.GetInt(saveVariable);
        if(getstate != 1)
        {
          state = 0;
        }
        else
        {
          state = 1;
        }
    }
    void FixedUpdate()
    {
      if(state == 0)
      {
        boolImg.sprite = spriteOff;
      }
      if(state == 1)
      {
        boolImg.sprite = spriteOn;
      }
    }
    public void Click()
    {
      state += 1;
      if(state == 0)
      {
        Debug.Log("параметр " + saveVariable + " включён");
        Debug.Log("porn");
        state = 1;


      }
      if(state == 2)
      {
        state = 0;
        Debug.Log("параметр " + saveVariable + " отключен");
      }
      //сохранение значения
      PlayerPrefs.SetInt(saveVariable, state);
    }

}
