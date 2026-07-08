using UnityEngine;
using UnityEngine.UI;
public class TranslatedContext : MonoBehaviour
{
  public Font ruFont;
  public Font enFont;
  public Text txt;
  public  string ruText;
  public  string enText;
  public string spanText;
  public string lang;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lang = PlayerPrefs.GetString("lang");
    }

    // Update is called once per frame
    void Update()
    {
        if(lang == "ru" || lang == "")
        {
          PlayerPrefs.SetString("lang", lang);
          txt.font = ruFont;
          txt.text = ruText;
        }
        if(lang == "en")
        {
          PlayerPrefs.SetString("lang", lang);
          txt.font = enFont;
          txt.text = enText;
        }
        if(lang == "span")
        {
          PlayerPrefs.SetString("lang", lang);
          txt.font = enFont;
          txt.text = spanText;
        }
    }
    public void ChangeLanguage(string whichlang)
    {
      lang = whichlang;
    }
}
