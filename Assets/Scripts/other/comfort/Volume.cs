using UnityEngine;

public class Volume : MonoBehaviour
{
	public AudioSource audio;
	public string type = "sound"; //sound - звуки(берёт из слайдера для звука), music - музыка(берёт из слайдера для музыки)
	string keyName;
	float vol;
	
    void Start()
	{
		
		audio = GetComponent<AudioSource>();
		keyName = "volume" + type;
		 if (PlayerPrefs.HasKey(keyName))
        {
			vol = PlayerPrefs.GetFloat(keyName);
           audio.volume = vol;
        }
		else 
		{
			
			vol = 1;
			PlayerPrefs.SetFloat(keyName, 1);
           audio.volume = vol;
		}
	}
	void FixedUpdate()
	{
		vol = PlayerPrefs.GetFloat(keyName);
        audio.volume = vol;
	}
}
