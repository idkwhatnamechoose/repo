using UnityEngine;
using UnityEngine.UI;
public class ItemGot : MonoBehaviour
{
  public string Name;
  public string Description;
  public Sprite spr;
  public Image img;
  public Text nameTxt;
  public Text descriptionTxt;
  Animator an;
  AudioSource audio;
  Inventory inv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      inv = GetComponent<Inventory>();
        an = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Show(AudioClip clipaudio)
    {
      audio.clip = clipaudio;

      audio.Play();
      an.Play("itemGotIdle");
      an.Play("itemGot");
      nameTxt.text = Name;
      descriptionTxt.text = Description;
      img.sprite = spr;
    }
}
