using UnityEngine;
using UnityEngine.UI;
public class SoundSettings : MonoBehaviour
{
	public GameObject[] uiParts;
	float volume;
	float realVol;
	public bool imSound;
	AudioSource aud;
	public AudioClip clip;
	Animator anim;
	int checkGame;
	GameObject par;
	public Texture[] fakeKubbyReactions;
	public RawImage fakeKubby;
	float volumeForText;
	public Text txt;
	void Start()
	{
		if(imSound == true)
		{
			par = GameObject.FindGameObjectWithTag("sound");
		}
		anim = GetComponent<Animator>();
		aud = GetComponent<AudioSource>();
		volume = PlayerPrefs.GetFloat("vol");
		if(volume == 0)
		{
			checkGame = PlayerPrefs.GetInt("volChanged");
			if(checkGame == 0)
			{
				PlayerPrefs.SetInt("volChanged", 1);
				PlayerPrefs.GetInt("vol", 10);
				volume = 10;
			}
		}
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
		{
			if(imSound == false)
			{
				volume -= 1;
				anim.SetBool("ch", true);
				CleanParts();
				aud.PlayOneShot(clip);
				PlayerPrefs.SetFloat("vol", volume);
	            Debug.Log("Громкость уменьшена на 1. Громкость: " + volume);
			    if(volume == -1)
			    {
					volume = 0;
				    Debug.Log("Громкость установлена на 0. Громкость: " + volume);
			    }
			}
				
		}
		if(Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals))
		{
			if(imSound == false)
			{
				volume += 1;
			aud.PlayOneShot(clip);
			CleanParts();
			PlayerPrefs.SetFloat("vol", volume);
			anim.SetBool("ch", true);
			
	           Debug.Log("Громкость увеличена на 1. Громкость: " + volume);
			   if(volume == 11)
			   {
				volume = 10;
				 Debug.Log("Громкость установлена на 10. Громкость: " + volume);
			   }
			}
			
		}
	}
	void FixedUpdate()
	{
		volumeForText = volume * 10;
		txt.text = volumeForText + "%";
		realVol = volume / 10;
		aud.volume = realVol;
		if(imSound == true)
		{
			volume = par.GetComponent<SoundSettings>().volume;
		}
		
		if(imSound == false)
		{
			
		}
	}
    void CleanParts()
	{
		if(volume == 10)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(true);
				uiParts[3].SetActive(true);
				uiParts[4].SetActive(true);
				uiParts[5].SetActive(true);
				uiParts[6].SetActive(true);
				uiParts[7].SetActive(true);
				uiParts[8].SetActive(true);
				uiParts[9].SetActive(true);
				fakeKubby.texture = fakeKubbyReactions[5];
				
			}
			if(volume == 9)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(true);
				uiParts[3].SetActive(true);
				uiParts[4].SetActive(true);
				uiParts[5].SetActive(true);
				uiParts[6].SetActive(true);
				uiParts[7].SetActive(true);
				uiParts[8].SetActive(true);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[4];
			}
			if(volume == 8)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(true);
				uiParts[3].SetActive(true);
				uiParts[4].SetActive(true);
				uiParts[5].SetActive(true);
				uiParts[6].SetActive(true);
				uiParts[7].SetActive(true);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[4];
			}
			if(volume == 7)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(true);
				uiParts[3].SetActive(true);
				uiParts[4].SetActive(true);
				uiParts[5].SetActive(true);
				uiParts[6].SetActive(true);
				uiParts[7].SetActive(false);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[3];
			}
			if(volume == 6)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(true);
				uiParts[3].SetActive(true);
				uiParts[4].SetActive(true);
				uiParts[5].SetActive(true);
				uiParts[6].SetActive(false);
				uiParts[7].SetActive(false);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[3];
			}
			if(volume == 5)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(true);
				uiParts[3].SetActive(true);
				uiParts[4].SetActive(true);
				uiParts[5].SetActive(false);
				uiParts[6].SetActive(false);
				uiParts[7].SetActive(false);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[2];
			}
			if(volume == 4)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(true);
				uiParts[3].SetActive(true);
				uiParts[4].SetActive(false);
				uiParts[5].SetActive(false);
				uiParts[6].SetActive(false);
				uiParts[7].SetActive(false);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[2];
			}
			if(volume == 3)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(true);
				uiParts[3].SetActive(false);
				uiParts[4].SetActive(false);
				uiParts[5].SetActive(false);
				uiParts[6].SetActive(false);
				uiParts[7].SetActive(false);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[1];
			}
			if(volume == 2)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(true);
				uiParts[2].SetActive(false);
				uiParts[3].SetActive(false);
				uiParts[4].SetActive(false);
				uiParts[5].SetActive(false);
				uiParts[6].SetActive(false);
				uiParts[7].SetActive(false);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[1];
			}
			if(volume == 1)
			{
				uiParts[0].SetActive(true);
				uiParts[1].SetActive(false);
				uiParts[2].SetActive(false);
				uiParts[3].SetActive(false);
				uiParts[4].SetActive(false);
				uiParts[5].SetActive(false);
				uiParts[6].SetActive(false);
				uiParts[7].SetActive(false);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[1];
			}
			if(volume == 0)
			{
				uiParts[0].SetActive(false);
				uiParts[1].SetActive(false);
				uiParts[2].SetActive(false);
				uiParts[3].SetActive(false);
				uiParts[4].SetActive(false);
				uiParts[5].SetActive(false);
				uiParts[6].SetActive(false);
				uiParts[7].SetActive(false);
				uiParts[8].SetActive(false);
				uiParts[9].SetActive(false);
				fakeKubby.texture = fakeKubbyReactions[0];
			}
	}
}
