using UnityEngine;

public class ShootingAgroMan : MonoBehaviour
{
	public bool walkingToKubby;
	public Transform gun;
	public Transform bulletSpawner;
	public Transform bulletSpawner2;
	public GameObject bullet;
	float time;
	GameObject player;
	public float defaultSpeed;
	float speed;
	float dir;
	public GameObject animNoWalking;
	public GameObject animWalking;
	public Transform rot;
	public Transform[] point;
	
	public int whatPoint = 0;
	float dir2;
	Vector3 point1Pos;
	Vector3 pos;
	Vector3 point2Pos;
	public bool kubbyIsHere = false;
	public float maxTimeShooting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	public void Detected()
	{
		walkingToKubby = true;
		time = 1;
		
	}
    void Shoot()
	{
		
		
		bulletSpawner.position = transform.position;
		bulletSpawner.LookAt(player.transform.position);
		
		
		GameObject bulletCreated = Instantiate(bullet, bulletSpawner2.position, bulletSpawner2.rotation);
		bulletCreated.transform.localScale = new Vector2(-dir2, 1);
		time = 0;
		Debug.Log("shoot!");
	}
	public void ChangeDirection(float currentDir)
	{
		dir = currentDir;
	}
    // Update is called once per frame
    void FixedUpdate()
    {
		if(walkingToKubby == false)
		{
			animNoWalking.SetActive(false);
			animWalking.SetActive(true);
			pos = transform.position;
			point1Pos = point[0].position;
			point2Pos = point[1].position;
			if(whatPoint == 1)
			{
				rot.localScale = new Vector3(-1, 1, 1);
				transform.localPosition += -transform.right * defaultSpeed * Time.fixedDeltaTime;
				if(point1Pos.x > pos.x)
				{
					whatPoint = 2;
				}
			}
			if(whatPoint == 2)
			{
				rot.localScale = new Vector3(1, 1, 1);
				transform.localPosition += transform.right * defaultSpeed * Time.fixedDeltaTime;
				if(point2Pos.x < pos.x)
				{
					whatPoint = 1;
				}
			}
		}
        if(walkingToKubby == true)
		{
			dir2 = 1 * dir;
			if(kubbyIsHere == false)
			{
				animNoWalking.SetActive(false);
			    animWalking.SetActive(true);
				transform.localPosition += transform.right * speed * Time.fixedDeltaTime;
			}
			else
			{
				animNoWalking.SetActive(true);
			    animWalking.SetActive(false);
			}
			
			rot.localScale = new Vector3(dir2, 1, 1);
			speed = defaultSpeed * dir;
			time += 1 * Time.deltaTime;
			
			
			
			if(time > maxTimeShooting)
			{
				///стреляет в игрока и сбрасывает таймер до нулей
				Shoot();
				time = 0;
			}
		}
    }
}
