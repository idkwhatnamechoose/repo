using UnityEngine;

public class SynchRotation : MonoBehaviour
{
    public GameObject[] _objs;
    public Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in _objs)
        {
            obj.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
