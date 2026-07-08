using UnityEngine;

public class Shadow : MonoBehaviour
{
	public GameObject[] bodyParts;
	public bool inShadow;
	public Color shadowColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inShadow == true)
		{
			
		}
		else
		{
			
		}
    }
	public void ImInShadow()
	{
		bodyParts[0].GetComponent<SpriteRenderer>().color = shadowColor;
			bodyParts[1].GetComponent<SpriteRenderer>().color = shadowColor;
			bodyParts[2].GetComponent<SpriteRenderer>().color = shadowColor;
			bodyParts[3].GetComponent<SpriteRenderer>().color = shadowColor;
			bodyParts[4].GetComponent<SpriteRenderer>().color = shadowColor;
	}
	public void QuitShadow()
	{
		bodyParts[0].GetComponent<SpriteRenderer>().color = Color.white;
			bodyParts[1].GetComponent<SpriteRenderer>().color = Color.white;
			bodyParts[2].GetComponent<SpriteRenderer>().color = Color.white;
			bodyParts[3].GetComponent<SpriteRenderer>().color = Color.white;
			bodyParts[4].GetComponent<SpriteRenderer>().color = Color.white;
	}
}
