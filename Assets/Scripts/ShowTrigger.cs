using UnityEngine;

public class ShowTrigger : MonoBehaviour
{
  public GameObject objToShow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void Show()
    {
      objToShow.SetActive(true); ///test
    }
    // Update is called once per frame
    void Update()
    {

    }
}
