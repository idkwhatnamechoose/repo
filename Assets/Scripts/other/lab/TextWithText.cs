using UnityEngine;
using UnityEngine.UI;
public class TextWithText : MonoBehaviour
{
    public Text textParent;
	Text txt;
	
	void Start()
	{
	   txt = GetComponent<Text>();
	   
	}
	void FixedUpdate()
	{
	   txt.text = textParent.text;
	}
}
