using UnityEngine;
using UnityEngine.UI;
public class YellowBots : MonoBehaviour
{
  //дап, тут ошибка в названии скрипта
  public Animator anim;
  public Transform shootPoint;
  public GameObject ammo;
  public float energy;
  public Image bar;
  float energyBar;
  public GameObject plSize;
  public Text energyText;
  public void Shoot()
  {
    Vector3 siz = plSize.transform.localScale;
    GameObject createdObject;
    if (energy > 19)
    {
      createdObject = Instantiate(ammo);
      createdObject.transform.position = shootPoint.position;
      createdObject.GetComponent<ShockAmmo>().size = siz.x;
      energy -= 20;
    }
  }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    energyText.text = energy + "%";
        energyBar = energy / 100;
        bar.fillAmount = energyBar;
    }
}
