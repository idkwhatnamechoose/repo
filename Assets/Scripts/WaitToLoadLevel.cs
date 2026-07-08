using UnityEngine;

public class WaitToLoadLevel : MonoBehaviour
{
  public float time;
  public float maxTime = 2;
  public string whichLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        if(time > maxTime)
        {
          Application.LoadLevel(whichLevel);
        }
    }
}
