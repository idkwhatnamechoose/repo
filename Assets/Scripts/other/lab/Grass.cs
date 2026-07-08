using UnityEngine;

public class Grass : MonoBehaviour
{
	public bool isTouchingGrass;
	
    Animator anim;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
		
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("touching", isTouchingGrass);
    }
}
