using UnityEngine;

public class SavingScript : MonoBehaviour
{
	
	public int slotLoaded;
    
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void AskVariable(string variableName, SavingClient client)
	{
		string gotText;
		gotText = PlayerPrefs.GetString(variableName);
		client.result = gotText;
	}
	public void SetVariable(string variableName, string variableText)
	{
		PlayerPrefs.SetString(variableName, variableText);
	    Debug.Log("saved!");
	}
}
