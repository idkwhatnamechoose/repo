using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
public class Dialog : MonoBehaviour
{
	public Font fontEn;
	public Font fontRu;
	public bool noImage = true;
	public Image face;
	public GameObject yappyDoor;
	public GameObject faceObj;
	public Animator animatedUI;
	public Sprite[] emotions;
	public string[] context;
	public string[] EnglishContext;
	public string[] SpanishContext;
	public int textCollection;
	int current = 0;
	public Text txt;
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

      if(animatedUI != null)
      {
          animatedUI.Play("idle");
      }

		lang = PlayerPrefs.GetString("lang");
	if(dialogWindow != null)
	{
		dialogWindow.SetActive(true);
	}
        if(txt != null) txt.text = "test";
        Next();

        if (lang == "")
        {
            lang = "ru";
        }
}

    // Update is called once per frame
    void Update()
    {
      bool nextPressed = false;
#if ENABLE_INPUT_SYSTEM
      if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
      {
          nextPressed = true;
      }
      if(Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
      {
          nextPressed = true;
      }
#endif
#if ENABLE_LEGACY_INPUT_MANAGER
      if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton3))
      {
          nextPressed = true;
      }
#endif
      if(nextPressed)
      {
          Next();
      }
			if(txt != null && txt.text == textToShowWarn)
			{
				if(nextWarn != null) nextWarn.SetActive(true);
				if(mouth != null) mouth.Play("mouthIdle");
			}
			else
			{
				if(nextWarn != null) nextWarn.SetActive(false);
			}
    }
	public void Click()
	{
		endedDialog = false;
		if(noImage == false)
		{
           if(animatedUI != null) animatedUI.Play("show"); 
		}
		else
		{
			if(animatedUI != null)
			{
				animatedUI.Play("showNoImage");
			}
		}
		current = 0;
		///dialogWindow.SetActive(true);
		Next2();
	}
	public void Next()
	{

		if(lang == "en")
		{
			if(txt.text == EnglishContext[current])
			{
				if(noImage == false)
				{
                           if(animatedUI != null) animatedUI.Play("next");
				}
				Next2();
			}
		}
		if(lang == "ru")
		{
			if(txt.text == context[current])
			{
				if(noImage == false)
				{
                           if(animatedUI != null) animatedUI.Play("next");
				}
				Next2();
			}
		}
		if(lang == "span")
		{
			if(txt.text == SpanishContext[current])
			{
				if(noImage == false)
				{
                           if(animatedUI != null) animatedUI.Play("next");
				}
				
				Next2();
			}
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
			    txt.text = "";
          if(lang == "en")
					{
						txt.font = fontEn;
						StartCoroutine(showText(EnglishContext[current]));
					}
					else if(lang == "ru" || lang == "")
					{
						txt.font = fontRu;
						StartCoroutine(showText(context[current]));
					}
          else if(lang == "span")
					{
						txt.font = fontEn;
						StartCoroutine(showText(SpanishContext[current]));
					}
		    }
		    else
		    {
					mouth.Play("mouthOpen");
					txt.text = "";
					face.sprite = emotions[current];
					if(lang == "en")
					{
						txt.font = fontEn;
						StartCoroutine(showText(EnglishContext[current]));
					}
					else if(lang == "ru" || lang == "")
					{
						txt.font = fontRu;
						StartCoroutine(showText(context[current]));
					}
          else if(lang == "span")
					{
						txt.font = fontEn;
						StartCoroutine(showText(SpanishContext[current]));
					}
		    }
		}
		if(current > textCollection)
		{
			///dialogWindow.SetActive(false);
			endedDialog = true;
			if(animatedUI != null) animatedUI.Play("hide");
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
            txt.text = text.Substring(0, i);
            i++;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
