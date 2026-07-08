using UnityEngine;
using UnityEngine.UI;
public class Windows2011 : MonoBehaviour
{
    Vector3 vec;
    Vector3 vec2;
    public Sprite left;
    public Sprite right;
    public Transform eyes;
    public GameObject pl;
    public SpriteRenderer img;
    public bool rightBool = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(rightBool == true)
        {
          img.sprite = right;
          eyes.localScale = new Vector3(-1.76398f, 1.76398f, 1.76398f);
        }
        else
        {
          img.sprite = left;
          eyes.localScale = new Vector3(1.76398f, 1.76398f, 1.76398f);
        }
    }
    public void Detected()
    {
      if(rightBool == false)
      {
        rightBool = true;
      }
      else
      {
        rightBool = false;
      }
    }
}
