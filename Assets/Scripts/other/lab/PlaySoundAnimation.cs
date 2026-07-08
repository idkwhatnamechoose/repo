using UnityEngine;

public class PlaySoundAnimation : MonoBehaviour
{
	public void PlayAudioClip(AudioClip media)
	{
		GetComponent<AudioSource>().PlayOneShot(media);
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
