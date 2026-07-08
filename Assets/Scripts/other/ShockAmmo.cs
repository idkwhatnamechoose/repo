using UnityEngine;

public class ShockAmmo : MonoBehaviour
{
  public float size;
  public float speed;
  float realSpeed;
  public bool startFly = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if(startFly == true)
       {
         realSpeed = speed;
         realSpeed = realSpeed * size;
         transform.localPosition += transform.right * realSpeed * Time.deltaTime;
       }
    }
}
