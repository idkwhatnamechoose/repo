using UnityEngine;

public class FakeKubbyBody : MonoBehaviour
{
    public FakeKubbyHealth health;
    bool isGrounded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health.onFloor = isGrounded;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
      if(coll.gameObject.tag == "floor")
      {
        isGrounded = true;
      }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
      if(coll.gameObject.tag == "floor")
      {
        isGrounded = false;
      }
    }
}
