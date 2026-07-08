using UnityEngine;

public class idk : MonoBehaviour
{
	Rigidbody2D rb;
	public float force = 400f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
			force = 500f;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0f, force, 0f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
