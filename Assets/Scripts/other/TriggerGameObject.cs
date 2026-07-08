using UnityEngine;

public class TriggerGameObject : MonoBehaviour
{
	public GameObject obj;
	public bool hideAfterDeactivating;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Activate()
	{
		obj.SetActive(true);
		
	}
	public void Deactivate()
	{
		if(hideAfterDeactivating == true)
		{
			obj.SetActive(false);
		}
	}
}
