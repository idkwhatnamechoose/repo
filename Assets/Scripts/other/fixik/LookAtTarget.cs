using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
	///СКРИПТ ДЛЯ ФЕЙКА
    public GameObject target;
	public string tagOfTarget = "none"; 	//none - не будет искать target по тэгу, а использовать приложенный target

	Vector3 vect1;
	Vector3 vectTarget;
	float xMe;
	float xTarget;
	public FakeKubby fak;
	public GameObject anim;
	public bool turnOffOnStartup = false;
	LookAtTarget scr;
	
	void Start()
	{
		scr = GetComponent<LookAtTarget>();
		if(tagOfTarget != "none")
		{
			target = GameObject.FindGameObjectWithTag(tagOfTarget);
			if(turnOffOnStartup == true)
			{
				scr.enabled = false;
			}
		}
		else
		{
			if(turnOffOnStartup == true)
			{
				scr.enabled = false;
			}
		}
	}
	void FixedUpdate()
	{
		vect1 = transform.position;
		vectTarget = target.transform.position;
		xMe = vect1.x;
		xTarget = vectTarget.x;
		if(xMe > xTarget)
		{
			anim.transform.localScale = new Vector3(-1f, 1f, 1f);
			fak.runSpeed = -3f;
			
			
		}
		if(xMe < xTarget)
		{
			anim.transform.localScale = new Vector3(1f, 1f, 1f);
			fak.runSpeed = 3f;
			

		}
	}
}
