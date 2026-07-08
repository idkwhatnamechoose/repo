using UnityEngine;
using UnityEngine.UI;
public class HealthReaction : MonoBehaviour
{
	public Transform pl;
  public Health healt;
  public Texture[] reactions;
  public RawImage img;
  public Animator imgAnimator;
  public bool varBool;
  float force;
  Vector3 vec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
	
    public void DamageUIAnimate(float damageforce)
    {
		Debug.Log("ai");
      imgAnimator.Play("healthUIIdle");
      imgAnimator.Play("healthUIReact");
	  
    }
    // Update is called once per frame
    void Update()
    {
		if(varBool == true)
		{
			vec = pl.localScale;
		    Debug.Log("ай");
		
	        force = -vec.x * 20f;
		    pl.localPosition += transform.right * force * Time.deltaTime;
		}
        if(healt.health == 100)
        {
          img.texture = reactions[0];
        }
        if(healt.health < 100)
        {
          if(healt.health < 90)
          {
            img.texture = reactions[1];
          }
          if(healt.health < 50)
          {
            img.texture = reactions[2];
          }
          if(healt.health < 20)
          {
            img.texture = reactions[3];
          }
        }

    }
}
