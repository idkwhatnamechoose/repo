using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
public float maxTime = 3;
float time;
public int fastRestartEnabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fastRestartEnabled = PlayerPrefs.GetInt("fastRestart");
    }

    // Update is called once per frame
    void Update()
    {
      if(fastRestartEnabled == 1)
      {
        RestartLevel();
      }
         time += 1 * Time.deltaTime;
         if(time > maxTime)
         {
           RestartLevel();
         }
    }
    public void RestartLevel()
    {
      Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Application.LoadLevel(sceneName);
    }
}
