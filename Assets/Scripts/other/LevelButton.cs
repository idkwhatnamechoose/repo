using UnityEngine;
using UnityEngine.UI;
public class LevelButton : MonoBehaviour
{
    int gotLevel;
    public int numberOfLevel;
    public Texture escapedLevelButtonSprite;
    public Texture notEscapedLevelButtonSprite;
    public Texture newLevelButtonSprite;
    public RawImage button;
	public int slotNumber;
	public GameObject cursor;
	
	public void Load()
	{
		string levelName;
		levelName = "Level";
		levelName = levelName + numberOfLevel;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		button = GetComponent<RawImage>();
        gotLevel = PlayerPrefs.GetInt("escapedLevels" + slotNumber);
        if (gotLevel == 0)
        {
            PlayerPrefs.SetInt("escapedLevels" + slotNumber, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gotLevel > numberOfLevel)
        {
            button.texture = notEscapedLevelButtonSprite;
        }
        if (gotLevel == numberOfLevel)
        {
            button.texture = newLevelButtonSprite;
        }
        if (gotLevel < numberOfLevel)
        {
           button.texture = escapedLevelButtonSprite;
        }
    }
    
}
