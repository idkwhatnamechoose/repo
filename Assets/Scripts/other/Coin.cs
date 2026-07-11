using UnityEngine;

public class Coin : MonoBehaviour
{
	public int cost;
	public GameObject saves;
	public AudioSource audioSource;
	public GameObject coinAnimGotLost;
	public void Detected()
	{
		audioSource.Play();
		saves.GetComponent<SavesSystem>().coins += cost;
		GetComponent<BoxCollider2D>().enabled = false;
		///GetComponent<Animator>().Play("gotCoin");
		Instantiate(coinAnimGotLost, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		saves = GameObject.FindGameObjectWithTag("Player");
	 audioSource = GetComponent<AudioSource>();   
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
