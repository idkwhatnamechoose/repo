using UnityEngine;
using UnityEngine.UI;
public class SavingClient : MonoBehaviour
{
	public GameObject saveBoss;
	public string result;
	SavingClient client;
	
	public void GetVariable(string varName)
	{
		saveBoss.GetComponent<SavingScript>().AskVariable(varName, client);
	}
	public void SetVariable(string varName, string varText)
	{
		saveBoss.GetComponent<SavingScript>().SetVariable(varName, varText);
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		client = GetComponent<SavingClient>();
        saveBoss = GameObject.FindGameObjectWithTag("saves");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
