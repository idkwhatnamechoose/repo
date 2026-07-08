using UnityEngine;
using EasyTextEffects.Editor.MyBoxCopy.Attributes;
using EasyTextEffects.Editor.MyBoxCopy.Extensions;
using EasyTextEffects.Effects;
public class TextEffectsApplier : MonoBehaviour
{
	public GameObject par;
	public void CallEnd()
	{
		par.GetComponent<Dialog2>().EndedTalk();
	}
	public void UAreMyParent(GameObject current)
	{
		par = current;
	}
	public Effect_Composite comp;

    void Start()
	{
		comp.HandleValueChanged();
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
