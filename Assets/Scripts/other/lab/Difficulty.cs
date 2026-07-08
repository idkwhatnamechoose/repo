using UnityEngine;

public class Difficulty : MonoBehaviour
{
	public string type = "EASY"; ///EASY, MEDIUM, HARD
    public float[] fakeSpeed;
	public bool[] fakeDisturbing;
	public int typeInt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(type == "EASY")
		{
			typeInt = 0;
		}
		if(type == "MEDIUM")
		{
			typeInt = 1;
		}
		if(type == "HARD")
		{
			typeInt = 2;
		}
    }
}
