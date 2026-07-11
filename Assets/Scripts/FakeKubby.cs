using UnityEngine;

public class FakeKubby : MonoBehaviour
{
	public Transform enemy;
    public Transform[] points;
	public Animator[] triggers;
	public Animator anim;
	GameObject pl;
	int whichPoint;
	Rigidbody2D rb;
	public float speed;
	public float timeout;
	public float time;
	Vector3 vect;
	public AudioSource audioSource;
	public bool detect;
	public Transform posPlayer;
	public float runSpeed = 5f;
	public GameObject dirTrig;
	public float maxTime = 1;
	public GameObject triggerDetector;
  public float jumpForce;
  Vector3 point1Vec;
  Vector3 point2Vec;
  Vector3 fake;
  bool haveABreak = true;
  public Transform sizeAnim;
 
  ///БОСС
  public GameObject parent;
  public bool forBoss;
  bool readyToFight;
  ///НОВЫЙ СКРИПТ
  public bool turnOnFix = false; //Исправляет баги такие как, повороты и атаку 
  ///ИСПРАВЛЕННЫЙ ПОВОРОТ. Без триггеров
  Vector3 playerVector;
  Vector3 myVector;
  float xPlayer;
  float xMe;
  public bool turnOffOnStart = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
	    void Awake()
	    {
		    audioSource = GetComponent<AudioSource>();
		pl = GameObject.FindGameObjectWithTag("Player");
        whichPoint = 0;
		anim.SetBool("walk", true);
		rb = GetComponent<Rigidbody2D>();
		enemy.position = points[1].position;
		fake = transform.position;
		point1Vec = points[0].position;
		point2Vec = points[1].position;
		point1Vec.y = fake.y;
		point2Vec.y = fake.y;
		points[0].position = point1Vec;
		points[1].position = point2Vec;
		if(turnOffOnStart == true)
		{
			parent.SetActive(false);
		}
    }
	public void ChangeDirection(float dir)
	{
		pl = GameObject.FindGameObjectWithTag("Player");

		if(turnOnFix == false)
		{
			
			sizeAnim.localScale = new Vector3(dir, 1f, 1f);

		}
		
	}
	public void Detected()
	{
		time = 0;
		detect = true;
		dirTrig.SetActive(true);
		anim.SetBool("walk", true);
		anim.Play("wowFakeKubby");

	}
	public void Boss()
	{
	    readyToFight = true;
	}
	void FixedUpdate()
	{
		fake = transform.position;
		point1Vec = points[0].position;
		point2Vec = points[1].position;
		point1Vec.y = fake.y;
		myVector = transform.position;
		playerVector = pl.transform.position;
		xMe = myVector.x;
		xPlayer = playerVector.x;
		point2Vec.y = fake.y;
		points[0].position = point1Vec;
		points[1].position = point2Vec;
		if(detect == false && forBoss == false)
		{
			anim.SetBool("falling", false);
			NoDetected();
		}
		if(forBoss == true)
		{
		    if(readyToFight == true)
			{
			   anim.SetBool("walk", true);
			   enemy.localPosition += transform.right * runSpeed * Time.deltaTime;
			}
		}
		if(detect == true && forBoss == false)
		{
			rb.bodyType = RigidbodyType2D.Dynamic;
			time += 1 * Time.deltaTime;
			if(time > maxTime)
			{
			    if(turnOnFix == true)
				{
					myVector = transform.position;
					playerVector = pl.transform.position;
					
				    if(xMe < xPlayer)
					{
						ChangeDirection(1);
					}
					if(xMe > xPlayer)
					{
						ChangeDirection(-1);
					}
					anim.SetBool("walk", true);
				    ///enemy.localPosition += transform.right * runSpeed * Time.deltaTime;
				} 
				else
				{
					anim.SetBool("walk", true);
				    enemy.localPosition += transform.right * runSpeed * Time.deltaTime;
				}
				
			}
		}
		
	}
	void Detecting()
	{


	}
    void CallTrigger()
	{
		triggers[whichPoint].Play("size");
	}
    void NoDetected()
    {
		time += 1 * Time.fixedDeltaTime;
        ///enemy.position = Vector3.Lerp(enemy.position, points[whichPoint].position, speed);
		enemy.position = Vector3.MoveTowards(enemy.position, points[whichPoint].position, speed);
		///vect = points[whichPoint].position;
		///enemy.Translate(Time.deltaTime, 0, 0, points[whichPoint]);
		if(whichPoint == 0)
		{
			sizeAnim.localScale = new Vector3(-1, 1, 1);
		}
		else
		{
			sizeAnim.localScale = new Vector3(1, 1, 1);

		}
		///проверка позиции
		if(enemy.position == points[whichPoint].position)
		{
			if(haveABreak == false)
			{
				time = timeout;
			}
			else if(haveABreak == true)
			{
				anim.SetBool("walk", false);
			    anim.SetBool("falling", false);
				rb.bodyType = RigidbodyType2D.Kinematic;
			}
			
			///anim.SetBool("looking", true);

	    }
		if(time > timeout)
		{
			whichPoint += 1;
			if(whichPoint == 2)
			{
				whichPoint = 0;
			}
			///CallTrigger();
			rb.bodyType = RigidbodyType2D.Dynamic;
			anim.SetBool("walk", true);
			time = 0;
		}
    }
		void OnCollisionEnter2D(Collision2D coll)
		{
			if(coll.gameObject.tag == "floor")
			{

				anim.SetBool("falling", false);
			}
		}
		void OnCollisionExit2D(Collision2D coll)
		{
			if(coll.gameObject.tag == "floor")
			{
				if(detect == true)anim.SetBool("falling", true);
			}
		}
		void OnTriggerEnter2D(Collider2D coll)
		{
		}
}
