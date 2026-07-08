using UnityEngine;

public class OldKubby : MonoBehaviour
{
	public Animator eyes;
	public void Open(bool state)
	{
		if(state == true)
		{
			eyes.Play("open");
		}
		else
		{
			eyes.Play("close");
		}
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
