using UnityEngine;

public class SaveCaveKubby : MonoBehaviour
{
  public GameObject player;
  public GameObject playerParent;
  public GameObject anim;
  public float speed;
  public float maxTime;
  float maxTime2;
  float time;
  bool enabl;
  public float dropForce;
  public Transform startPoint;
  public void Detected()
  {
    time = 0;
    anim.SetActive(true);
    anim.GetComponent<Animator>().Play("grab2");
    player.GetComponent<AnimatorKubby>().anim.SetBool("walking", false);
    player.GetComponent<AnimatorKubby>().anim.SetBool("sit", false);
    player.GetComponent<AnimatorKubby>().anim.Play("idleKubby");

    player.GetComponent<Rigidbody2D>().isKinematic = true;
    ///player.GetComponent<BoxCollider2D>().enabled = false;
    enabl = true;

  }
  void Start()
  {
    maxTime2 = maxTime;
    maxTime2 += 2;
    player = GameObject.FindGameObjectWithTag("Player");
    playerParent = GameObject.FindGameObjectWithTag("PlayerParent");
    startPoint.position = anim.transform.position;
    anim.SetActive(false);
  }
  void FixedUpdate()
  {
    time += 1 * Time.fixedDeltaTime;
    if(enabl == true)
    {
      if(time > 1)
      {
        anim.transform.localPosition += transform.up * speed * Time.fixedDeltaTime;
      }
      if(time > maxTime)
      {
        Drop();

      }

    }
    if(time > maxTime2)
    {
      anim.SetActive(false);
      enabl = false;
    }
  }
  void Drop()
  {
    enabl = false;
    playerParent.SetActive(true);
    player.transform.position = anim.transform.position;
    player.GetComponent<Rigidbody2D>().isKinematic = false;
    ///player.GetComponent<BoxCollider2D>().enabled = true;
    player.GetComponent<Rigidbody2D>().AddForce(new Vector3(dropForce, 0, 0));
    anim.GetComponent<Animator>().Play("throw");
    player.GetComponent<AnimatorKubby>().enabled = true;
  }
}
