using UnityEngine;

public class Menu : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		Time.timeScale = 1;
         Application.targetFrameRate = 60;
    }
    public void LoadPlayerLevel(string levelName)
    {
      PlayerPrefs.SetString("levelName", levelName);
      UnityEngine.SceneManagement.SceneManager.LoadScene("LevelLoader");
    }
    public void LoadLevel(string levelName)
    {

      UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
    public void ClickURL(string url)
    {
      Application.OpenURL(url);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
