using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
	public GameObject objToDestroy;

	public void Destroy(GameObject obj)
	{
		Destroy(obj);
	}
	public void DestroyItself()
	{
		Destroy(this.gameObject);
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		
	    objToDestroy.GetComponent<Animator>().enabled = false;
        GetComponent<Animator>().enabled = false;
		Debug.Log("Компоненты Animator выключены!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
