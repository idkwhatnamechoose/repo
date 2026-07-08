using UnityEngine;

public class Tree : MonoBehaviour
{
	public GameObject leave;
	public Transform[] points;
	public Color[] leavesColor;
	float time;
	public float maxTime = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Spawn()
	{
		int num = Random.Range(0, 1);
		GameObject createdLeave = Instantiate(leave, points[num].position, points[num].rotation);
		createdLeave.GetComponent<SpriteRenderer>().color = leavesColor[num];
		time = -10;
	}
    // Update is called once per frame
    void Update()
    {
		time += 1 * Time.fixedDeltaTime;
        if(time > maxTime)
		{
			Spawn();
		}
    }
}
