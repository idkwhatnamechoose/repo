using UnityEngine;

public class DragProperties : MonoBehaviour
{
    public bool isGarbage;
    public AgroCleaner cleaner;

    void Start()
	{
		
	}
    public void Dropped()
	{
		if(isGarbage == true)
		{
			cleaner.Detected();
		}
	}	
}
