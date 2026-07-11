using UnityEngine;

public class normalCaveKubby : MonoBehaviour
{
	public float time;
	public Transform ownCamera;
	public GameObject ownCameraObject;
	public GameObject mainCamera;
	public GameObject player;
	public GameObject playerParent;
	public Transform pointForKubby;
	public float dropForce;
	public Transform pointForCamera;
	public float speed;
	public Animator anim;
	public Transform animTransform;
	public bool isWorking = false;
	bool hide = false;
	public Transform trigger;
	Vector3 playerPos;
	Vector3 triggerPos;
   
	public void Collided()
	{
		playerParent.SetActive(false);
		anim.Play("grab");
		time = 0;
		ownCameraObject.SetActive(true);
		hide = true;
		ownCamera.position = mainCamera.transform.position;
		animTransform.position = player.transform.position;
		isWorking = true;
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		player = GameObject.FindGameObjectWithTag("Player");
		playerParent = GameObject.FindGameObjectWithTag("PlayerParent");
		
    }

    // Update is called once per frame
    void Update()
    {
		if(isWorking == false)
		{
			if(hide == true)
			{
				anim.Play("hide");
				ownCamera.gameObject.SetActive(false);
				player.transform.position = pointForKubby.position;
				playerParent.SetActive(true);
				///camera.SetActive(true);
				GetComponent<Camera>().transform.position = pointForCamera.position;
				player.GetComponent<Rigidbody2D>().AddForce(new Vector3(dropForce, 100f, 0f));
				hide = false;
			}
		}	
        if(isWorking == true)
		{
			playerPos = pointForKubby.position;
			triggerPos = trigger.position;
			if(playerPos.y > triggerPos.y)
			{
				isWorking = false;
				Debug.Log("end");
			}
			
			time += 1 * Time.deltaTime;
			if(time > 0.5)
			{
				ownCamera.position = Vector3.Lerp(ownCamera.position, pointForCamera.position, 10f * Time.deltaTime);
				animTransform.position = Vector3.Lerp(animTransform.position, pointForKubby.position, 10f * Time.deltaTime);
			}
			if(time > 1.5)
			{
				pointForKubby.localPosition += transform.up * speed * Time.deltaTime;
			}
		}
    }
	
	
}
