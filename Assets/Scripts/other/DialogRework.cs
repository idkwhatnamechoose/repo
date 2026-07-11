using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
public class DialogRework : MonoBehaviour
{
    public TMP_FontAsset fontEn;
	public TMP_FontAsset fontRu;
	public TextMeshProUGUI textMesh;
	public bool noImage = true;
	public Image face;
	public GameObject faceObj;
	public Animator animatedUI;
	public Sprite[] emotions;
	public string[] context;
	public string[] EnglishContext;
	public string[] SpanishContext;
	public int textCollection;
	int current = 0;
	///public Text txt;
	public TextMeshProUGUI txt;
	public float letterDelay = 0.1f;
	public GameObject pl;
	public GameObject dialogWindow;
	AudioSource audioSource;
	public AudioClip mediaFile;
	float pitchForAudio;
	double d;
	public string lang = "ru";
	public bool startCutsceneAfterTalk;
	public Animator cutscene;
	public bool startRightNow = false;
	public GameObject nextWarn;
	public string textToShowWarn = "notyet";
	public Sprite openedMouth;
	public Sprite closedMouth;
	public Animator mouth;
	public bool endedDialog = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
			///just a message

      animatedUI.Play("idle");

			lang = PlayerPrefs.GetString("lang");
dialogWindow.SetActive(true);
        pl = GameObject.FindGameObjectWithTag("Player");
		audioSource = GetComponent<AudioSource>();
		if(startRightNow == true)
		{
			txt.SetText("test");
			textMesh.SetText("test");
			Next();
		}
		if(lang == "")
		{
			lang = "ru";
		}
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton3))
			{
				Next3();
				
			}
			if(txt.text == textToShowWarn)
			{
				nextWarn.SetActive(true);
				mouth.Play("mouthIdle");
			}
			else
			{
				nextWarn.SetActive(false);
			}
    }
	public void Click()
	{
		///endedDialog = false;
		if(noImage == false)
		{
           animatedUI.Play("show"); 
		}
		else
		{
			animatedUI.Play("showNoImage"); 
		}
		current = 0;
		///dialogWindow.SetActive(true);
		Next3();
	}
	public void Next()
	{

		if(lang == "en")
		{
			if(txt.text == EnglishContext[current])
			{
				if(noImage == false)
				{
                           animatedUI.Play("next");
				}
				Next3();
			}
		}
		if(lang == "ru")
		{
			if(txt.text == context[current])
			{
				if(noImage == false)
				{
                           animatedUI.Play("next");
				}
				Next3();
			}
		}
		if(lang == "span")
		{
			if(txt.text == SpanishContext[current])
			{
				if(noImage == false)
				{
                           animatedUI.Play("next");
				}
				
				Next3();
			}
		}
	}
	public void Next3()
	{
		current += 1;
		if(current > textCollection)
		{
			///dialogWindow.SetActive(false);
			
			animatedUI.Play("hide");
			pl.GetComponent<UseHand>().use = false;
			if(startCutsceneAfterTalk == true)
			{
				cutscene.Play("cutscene");
			}
			endedDialog = false;
			///current = -1;
		}
		else if(current <= textCollection)
		{
			endedDialog = true;
			///txt.enabled = false;
			txt.SetText("");
			txt.SetText(context[current]);
			txt.enabled = false;
			txt.enabled = true;
		}
		
	}
	public void NextAnimationUI()
	{
		if(noImage == false)
		{
                animatedUI.Play("next");
		}
	}
	public void Next2()
	{

		current += 1;
		if(current <= textCollection)
		{
			if(noImage == true)
		    {
					faceObj.GetComponent<Image>().enabled = false;
			    ///txt.text = "";
          if(lang == "en")
					{
						textMesh.font = fontEn;
						StartCoroutine(showText(EnglishContext[current]));
					}
					else if(lang == "ru" || lang == "")
					{
						textMesh.font = fontRu;
						StartCoroutine(showText(context[current]));
					}
          else if(lang == "span")
					{
						textMesh.font = fontEn;
						StartCoroutine(showText(SpanishContext[current]));
					}
		    }
		    else
		    {
					mouth.Play("mouthOpen");
					///txt.text = "";
					face.sprite = emotions[current];
					if(lang == "en")
					{
						textMesh.font = fontEn;
						StartCoroutine(showText(EnglishContext[current]));
					}
					else if(lang == "ru" || lang == "")
					{
						textMesh.font = fontRu;
						StartCoroutine(showText(context[current]));
					}
          else if(lang == "span")
					{
						textMesh.font = fontEn;
						StartCoroutine(showText(SpanishContext[current]));
					}
		    }
		}
		if(current > textCollection)
		{
			///dialogWindow.SetActive(false);
			endedDialog = true;
			animatedUI.Play("hide");
			pl.GetComponent<UseHand>().use = false;
			if(startCutsceneAfterTalk == true)
			{
				cutscene.Play("cutscene");
			}
		}
	}
	IEnumerator showText(string text)
    {
	if(noImage == false)
	{
         mouth.Play("mouthOpen");
	}
			
			textToShowWarn = text;
		pitchForAudio = UnityEngine.Random.Range(0.7f, 1f);
		double d = (double) pitchForAudio;
		///audioSource.pitch = pitchForAudio;
        int i = 0;

        while (i <= text.Length)
        {
			pitchForAudio = UnityEngine.Random.Range(0.999f, 1f);
			audioSource.PlayOneShot(mediaFile);
			///audioSource.clip = mediaFile;
			///audioSource.Play();
			///audioSource.volume = pitchForAudio;
            ///txt.text = text.Substring(0, i);
            i++;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
