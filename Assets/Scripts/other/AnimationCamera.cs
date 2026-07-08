using UnityEngine;

public class AnimationCamera : MonoBehaviour
{
    public GameObject originalCamera;
    public Transform endPoint;
    public float speedCamera = 7f;
    public bool deleteUI = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalCamera = GameObject.FindGameObjectWithTag("MainCamera");
        endPoint.position = transform.position;
        transform.position = originalCamera.transform.position;
        if (deleteUI == true)
        {
            originalCamera.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endPoint.position, speedCamera * Time.fixedDeltaTime);
        if (deleteUI == true)
        {
            originalCamera.SetActive(false);
        }
        else
        {
            originalCamera.SetActive(true);
        }
    }
}
