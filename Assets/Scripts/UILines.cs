using UnityEngine;

public class UILines : MonoBehaviour
{
    public  float speed;
    public Transform defaultPoint;
    Vector3 vec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += -transform.up * speed * Time.deltaTime;
        vec = transform.position;
        if(vec.y <= 580)
        {
          transform.position = defaultPoint.position;
        }
    }
}
