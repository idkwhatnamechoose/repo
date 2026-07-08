using UnityEngine;

public class UnactiveObjectAnimation : MonoBehaviour
{
	public GameObject target;
	public bool isUnactived;
	
	public void SetState(bool act)
	{
		target.SetActive(act);
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
