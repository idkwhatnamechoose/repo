using UnityEngine;

public class BoolObj : MonoBehaviour
{
	GameObject obj;
	public string saveVariable;
	int result;
	public bool hideObjectIfStateIsOne; ///прятать обьект, если переменная равняется 1?
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		obj = this.gameObject;
		result = PlayerPrefs.GetInt(saveVariable);
        if(1 == 1)
		{
			if(result == 1)
			{
				if(hideObjectIfStateIsOne == true)
				{
					obj.SetActive(false);
				}
			}
			else
			{
				if(hideObjectIfStateIsOne == false)
				{
					obj.SetActive(false);
				}
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
