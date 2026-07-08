using UnityEngine;

public class KubbySounds : MonoBehaviour
{
  public AudioClip walkSound;
  public AudioClip runSound;
  public AudioSource audio;
  public bool sit = false;
  public bool run = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
	public void Step()
	{
		audio.PlayOneShot(walkSound);
	}
	public void JustPlaySound(AudioClip sound)
	{
        audio.PlayOneShot(sound);		
	}
}
