using UnityEngine;

public class JumpEnabler : MonoBehaviour
{
	public Jump legs;
	public void Enable(bool enableBool)
	{
		legs.enabled = enableBool;
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
