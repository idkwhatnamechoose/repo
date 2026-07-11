using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapButton : MonoBehaviour
{
    string state = "unactive"; //unactive - уровень закрыт, completed - уровень уже пройден и всё ещё открыт, inprogress - уровень ещё не прошли, но он открыт
    public RawImage icon;
    public Texture completedSprite;
    public Texture unactiveSprite;
    public Texture inprogressSprite;
    bool canPlay = false;
    public int levelNumber;
    public bool isForAgrocity = false;
    public void Play()
    {
        string prefix;
        string levelName;
        if(isForAgrocity == false)
        {
            prefix = "Level";
        } else 
        {
            prefix = "City";
        }

        if(canPlay != false)
        {
        levelName = prefix + levelNumber;
        SceneManager.LoadScene(levelName);
        } else 
        {
            Debug.Log("Уровень ещё закрыт -_-");
        }
    }
    public void Set(string newState)
    {
         state = newState;
         if(state == "completed") 
         {
             icon.texture = completedSprite;
             canPlay = true; 
         }
         if(state == "unactive")
         {
             icon.texture = unactiveSprite;
             canPlay = false;
         }
         if(state == "inprogress")
         {
            icon.texture = inprogressSprite;
            canPlay = true;
         }
    }
}
