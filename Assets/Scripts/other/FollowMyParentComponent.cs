using UnityEngine;
using UnityEngine.UI;
public class FollowMyParentComponent : MonoBehaviour
{
  public GameObject myParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(myParent.GetComponent<Image>().enabled == false)
        {
          GetComponent<Image>().enabled = false;
        }
        else
        {
          GetComponent<Image>().enabled = true;
        }
    }
}
