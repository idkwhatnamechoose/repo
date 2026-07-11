using UnityEngine;

public class SoundLow : MonoBehaviour
{
	AudioSource audioSource;
	float pitchFloat;
	public bool gettingLow = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gettingLow == true)
		{
			if(pitchFloat < 1f)
			{
				
			}
			else
			{
				pitchFloat -= 0.5f * Time.fixedDeltaTime;
			    GetComponent<AudioSource>().pitch = pitchFloat;
			}
			
		}
    }
}
