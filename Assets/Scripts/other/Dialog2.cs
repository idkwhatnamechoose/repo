using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using EasyTextEffects.Editor.MyBoxCopy.Attributes;
using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using EasyTextEffects.Effects;
using System.Collections.Generic;
using System.Linq;
public class Dialog2 : MonoBehaviour
{
	public bool[] leftSide;
	public RawImage face;
	public RawImage face2;
	public Texture[] emotions;
	public bool noImage = true;
	public GameObject warnToNext;
	public AudioClip[] voices;
	public AudioSource voiceAudio;
	public Transform parentOfTexts;
	///public TextMeshProUGUI text;
	public GameObject textObj;
	public string[] context;
	public string[] contextEn;
	public string[] contextSp;
	public int collection;
	public GameObject pl;
	public GameObject[] charactersUI;
	public int current;
	public Color invisible;
	public Color def;
	public Animator animUI;
	public bool started;
	GameObject previousText;
	public GameObject text;
	bool endedTalk = true;
	public AudioSource audioSource;
	float time;
	public Text txt;
	public AudioClip mediafile;
	public bool startDialog;
	bool endedTalk2 = true;
	public GameObject[] mouth;
	///выбор
	public Dialog2 choice1;
	public Dialog2 choice2;
	bool hasChoices = false;
	public GameObject buttons;
	///работа при старте
	public bool isStarting = false; 
	///катсцена после проигрывания диалога
	public bool startCutsceneAfterDialog = false;
	public Animator cutscene;
	///фикс с лицами(переменная с прошлым номером текста)
	int last;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
		if(startDialog == true)
		{
			Click();
		}
		if(choice1 != null || choice2 != null)
		{
			hasChoices = true;
		}
		
    }
	void Awake()
	{
		pl = GameObject.FindGameObjectWithTag("Player");
		if(isStarting == true)
		{
			Click();
		}
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton3))
		{
			if(started == true)
			{
				Next();
			}
		}
		if(started == true)
		{
			if(endedTalk2 == false)
			{
				
			}
			
			if(endedTalk == false)
			{
				
				warnToNext.SetActive(false);
				time += 1 * Time.fixedDeltaTime;
					if(time > 0.1 && noImage == true)
				{
					audioSource.PlayOneShot(mediafile);
					///tantiate(audio, transform.position, transform.rotation);
					time = 0;
				}
				if(time < 0.0000000001 && noImage == true)
				{
					///voiceAudio.Play(voices[current]);
					///tantiate(audio, transform.position, transform.rotation);
					///time = 0;
				}
			}
			else
			{
				warnToNext.SetActive(true);
			}
		}
    }
	public void EndedTalk()
	{
		endedTalk = true;
	}
	public void EndedTalk2()
	{
		endedTalk2 = true;
	}
	public void Click()
	{
		if(started == false)
		{
			if(noImage == true)
		    {
		    	animUI.Play("showUIDialogNoImage");
		    }
		    else
		    {
		    	animUI.Play("showUIDialog");
		    }
		    
		    current = 0;
			
			Next();
		}
		
	}
	public void Next()
	{
		if(noImage == false)
		{
			endedTalk2 = true;
			///mouth[current].SetActive(false);
		} else {
			
		}
		current += 1;
		if(current <= collection)
		{
			started = true;
			
			previousText = text;
			text = null;
			text = Instantiate(textObj, parentOfTexts);
			///text.transform.SetParent(parentOfTexts.transform);
			Destroy(previousText);
			text.GetComponent<TextMeshProUGUI>().SetText(context[current]);
			text.GetComponent<TextEffectsApplier>().UAreMyParent(this.gameObject);
			///text.GetComponent<TextEffect>().enabled = false;
			///text.GetComponent<TextEffect>().enabled = true;
			endedTalk = false;
			if(noImage == false)
			{    ///mouth[current].SetActive(false);
				face.texture = emotions[current];
				///mouth[current].SetActive(true);
				///voiceAudio.PlayOneShot(voices[current]);
				endedTalk2 = false;
			}
		}
		else
		{
			
			if(hasChoices == true)
			{
				warnToNext.SetActive(false);
				text.SetActive(false);
				buttons.SetActive(true);
			}
			else
			{
				animUI.Play("hideUIDialog");
				pl.GetComponent<UseHand>().use = false;
			    started = false;
			    current = 0;
			}
		}
	}
	public void Choose(int selected)
	{
		
		if(selected == 1)
		{
			choice1.Click();
			animUI.Play("hideUIDialog");
			started = false;
		}
		if(selected == 2)
		{
			choice2.Click();
			animUI.Play("hideUIDialog");
			started =false;
		}
	}
}
