using UnityEngine;
using UnityEngine.UI;
public class FakeKubby1 : MonoBehaviour
{
	public GameObject anim;
	public GameObject player;
	public GameObject camer;
	float health;
	float killedhealth;
	public float speedToMoveUp; /// скорость поднимания на вверх
    public float forceToBeFree; /// переменная которая будет подниматься если нажимать
	public float throwAway; ///бросок в случае победы над пещерным Кубби
	bool grab = false;
	public Image bar;
	float barVar;
	public GameObject playerParent;
	float time;
	bool dead;
	public bool grabbing;
	float time2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerParent = GameObject.FindGameObjectWithTag("PlayerParent");
		player = GameObject.FindGameObjectWithTag("Player");

    }
    public void Detected()
	{
		time2 = 0;
		anim.GetComponent<Animator>().Play("grab");
		health = player.GetComponent<Health>().health;
		forceToBeFree = 50;
		GetComponent<BoxCollider2D>().enabled = false;
		barVar = forceToBeFree / 100;

		grab = true;
	}
    // Update is called once per frame
    void Update()
    {
			if(grab == true)
			{
				time2 += 1 * Time.deltaTime;
				if(time2 > 1)
		    {
			GetComponent<BoxCollider2D>().enabled = false;
			barVar = forceToBeFree / 100;
			bar.fillAmount = barVar;
			///playerParent.SetActive(false);
			anim.SetActive(true);
			anim.transform.localPosition += transform.up * speedToMoveUp * Time.deltaTime;
			killedhealth += 10 * Time.deltaTime;
			forceToBeFree -= 20 * Time.deltaTime;
			if(forceToBeFree < 0)
			{
				///anim.GetComponent<Animator>().Play("kill");
				///grab = false;
				killedhealth += 90;
			}
			if(killedhealth > 90)
			{
				anim.GetComponent<Animator>().Play("kill");
				playerParent.SetActive(false);
				grab = false;
				dead = true;
			}
			}

			if(forceToBeFree > 99)
			{
				forceToBeFree += 10;
				ThrowAway();
				killedhealth -= 10;
				grab = false;
			}
		}
		if(grab == false && dead == false)
		{
			time += 1 * Time.deltaTime;
			if(time > 1)
			{
				anim.SetActive(false);
				GetComponent<BoxCollider2D>().enabled = true;
			}
		}
    }
	void ThrowAway()
	{
		time = 0;
	    killedhealth = Mathf.Round(killedhealth);
		grab = false;
		///playerParent.SetActive(true);
		GetComponent<BoxCollider2D>().enabled = false;
		anim.GetComponent<Animator>().Play("throw");
		player.transform.position = anim.transform.position;
		player.GetComponent<Rigidbody2D>().AddForce(new Vector3(throwAway, 0, 0));
		player.GetComponent<Health>().health -= killedhealth;
	}
	public void Click()
	{
		forceToBeFree += 10;
		///anim.GetComponent<Animator>().Play("kubbyTrying");
	}
}
