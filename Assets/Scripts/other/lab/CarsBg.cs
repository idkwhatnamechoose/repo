using UnityEngine;

public class CarsBg : MonoBehaviour
{
	public Sprite[] sprites;
	SpriteRenderer render;
	float time;
	int randomSprite;
	public float maxTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        render = GetComponent<SpriteRenderer>(); 
        randomSprite = Random.Range(0, 1);
		render.sprite = sprites[randomSprite];
		time = 0;     		
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
		if(time > maxTime)
		{
			randomSprite = Random.Range(0, 1);
			render.sprite = sprites[randomSprite];
			time = 0;
		}
    }
}
