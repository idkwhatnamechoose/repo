using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
  public bool isPaused;
  public GameObject gameOverPanel;
  public AudioSource audio;
  public AudioSource audioPause;
  public AudioClip pauseSound;
  public AudioClip unpauseSound;
  public GameObject punches;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton9))
      {
        if(isPaused == false)
        {
          Debug.Log("игра на паузе!");
          isPaused = true;
          gameOverPanel.SetActive(true);
		  GetComponent<Movement>().enabled = false;
		  punches.GetComponent<Attack>().isActive = false;
		  GetComponent<Jump>().enabled = false;
          Time.timeScale = 0f;
          audio.Pause();
          audioPause.clip = pauseSound;
          audioPause.Play();
        }
        else
        {
	      
          Debug.Log("игра возобновлена!");
          isPaused = false;
          gameOverPanel.SetActive(false);
		  GetComponent<Movement>().enabled = true;
		   GetComponent<Jump>().enabled = true;
		  punches.GetComponent<Attack>().isActive = true;
          Time.timeScale = 1f;
          audio.Play();
          audioPause.clip = unpauseSound;
          audioPause.Play();
        }


      }


    }
    public void PressPause()
    {
      Debug.Log("игра на паузе!");
      isPaused = true;
      gameOverPanel.SetActive(true);
      Time.timeScale = 0f;
      audio.Pause();
      audioPause.clip = pauseSound;
      audioPause.Play();
    }
    public void RestartLevel()
    {
      Time.timeScale = 1f;
      Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Application.LoadLevel(sceneName);
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1f;
      Application.LoadLevel("Menu");
    }
    public void Resume()
    {
      isPaused = false;
      gameOverPanel.SetActive(false);
      Time.timeScale = 1f;
      audioPause.clip = unpauseSound;
      audioPause.Play();
      audio.Play();
    }
}
