using UnityEngine;

public class BootsController : MonoBehaviour
{
  public bool legs;
  public bool hands;
  public string type = "nothing";
  public GameObject[] greenBootsAndGloves;
    public GameObject[] yellowGloves;
	public GameObject[] purpleBoots;
	public GameObject[] bordGloves;
	
  public YellowBots yellowBots;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    if (type == "nothing")
    {
      greenBootsAndGloves[0].SetActive(false);
      greenBootsAndGloves[1].SetActive(false);
      greenBootsAndGloves[2].SetActive(false);
      greenBootsAndGloves[3].SetActive(false);
      yellowGloves[0].SetActive(false);
      yellowGloves[1].SetActive(false);
	  bordGloves[0].SetActive(false);
      bordGloves[1].SetActive(false);
	  purpleBoots[0].SetActive(false);
      purpleBoots[1].SetActive(false);
      legs = false;
      hands = false;
      GetComponent<YellowBots>().enabled = false;
        }
    if (type == "green")
    {
      greenBootsAndGloves[0].SetActive(true);
      greenBootsAndGloves[1].SetActive(true);
      greenBootsAndGloves[2].SetActive(true);
      greenBootsAndGloves[3].SetActive(true);
      yellowGloves[0].SetActive(false);
      yellowGloves[1].SetActive(false);
	  bordGloves[0].SetActive(false);
      bordGloves[1].SetActive(false);
	  purpleBoots[0].SetActive(false);
      purpleBoots[1].SetActive(false);
          GetComponent<YellowBots>().enabled = false;
		  GetComponent<Jump>().jumpForce = 1400f;

        }
    if (type == "yellow")
    {
      greenBootsAndGloves[0].SetActive(false);
      greenBootsAndGloves[1].SetActive(false);
      greenBootsAndGloves[2].SetActive(false);
      greenBootsAndGloves[3].SetActive(false);
	  yellowGloves[2].SetActive(true);
      yellowGloves[0].SetActive(true);
      yellowGloves[1].SetActive(true);
	  purpleBoots[0].SetActive(false);
      purpleBoots[1].SetActive(false);
	  bordGloves[0].SetActive(false);
      bordGloves[1].SetActive(false);
      GetComponent<YellowBots>().enabled = true;
          
        }
    if (type == "purple")
    {
      greenBootsAndGloves[0].SetActive(false);
      greenBootsAndGloves[1].SetActive(false);
      greenBootsAndGloves[2].SetActive(false);
      greenBootsAndGloves[3].SetActive(false);
      yellowGloves[0].SetActive(false);
      yellowGloves[1].SetActive(false);
	  purpleBoots[0].SetActive(true);
      purpleBoots[1].SetActive(true);
	  bordGloves[0].SetActive(false);
      bordGloves[1].SetActive(false);
      GetComponent<YellowBots>().enabled = true;
          
        }
		if (type == "bord")
    {
      greenBootsAndGloves[0].SetActive(false);
      greenBootsAndGloves[1].SetActive(false);
      greenBootsAndGloves[2].SetActive(false);
      greenBootsAndGloves[3].SetActive(false);
      yellowGloves[0].SetActive(false);
      yellowGloves[1].SetActive(false);
	  purpleBoots[0].SetActive(false);
      purpleBoots[1].SetActive(false);
	  bordGloves[0].SetActive(true);
      bordGloves[1].SetActive(true);
      GetComponent<YellowBots>().enabled = false;
          
        }
    }
}
