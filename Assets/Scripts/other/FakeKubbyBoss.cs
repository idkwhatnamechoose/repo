using UnityEngine;

public class FakeKubbyBoss : MonoBehaviour
{
	public int attack;
	//1 АТАКА
	public GameObject[] spawners; 
	public bool intoOneFake = false;
	public GameObject fake;
	int point = -1;
	
    public void SpawnFake()
	{
	    point += 1;
	    
		if(point > 1)
		{
		   attack = 2;
		}
		else
		{
		   spawners[point].SetActive(true);
		}
	}
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
