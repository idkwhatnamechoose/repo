using UnityEngine;

public class BoxInteractable : MonoBehaviour
{
	public GameObject drag;
	bool isUsing;
	public Transform hand;
	public GameObject trig;
	public void Drag(GameObject obj, GameObject trigg)
	{
		trig = trigg;
		drag = obj;
		trig.GetComponent<Use>().show = false;
		isUsing = true;
		
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isUsing == true)
		{
			drag.SetActive(false);
			if(Input.GetKeyDown(KeyCode.Q))
			{
				Drop();
			}
		}
		
    }
	public void Drop()
	{
		isUsing = false;
		drag.SetActive(true);
		drag.transform.position = hand.position;
		drag.transform.rotation = hand.rotation;
		trig.GetComponent<Use>().show = true;
	}
}
