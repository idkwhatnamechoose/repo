using UnityEngine;
using UnityEngine.UI;

public class VictoryWindow : MonoBehaviour
{
    public Texture[] kubbySprites;
    public Texture[] fakeKubbySprites;
    public RawImage kubby;
    public RawImage fakeKubby;
    public Health hp;
    public GameObject window;
    public Text txtHealth;
    public Text txtFake;
    public int killedFakeKubby;
    public int howManyFakeKubby = 1;
    int halfOfKilledFakeKubbyies;
    public bool continueGame;
    public string nextLevel;
    float time;
    public bool justOpen = false;
	public float gameTimeSeconds;
	public SavesSystem saves;
	public float gameTimeMinutes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = GetComponent<Health>();
		saves = GetComponent<SavesSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      gameTimeSeconds += 1 * Time.fixedDeltaTime;
	  if(gameTimeSeconds > 60)
	  {
		  gameTimeMinutes += 1;
		  gameTimeSeconds = 0;
	  }
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        ///Application.LoadLevel("MenuAndroid");
      }
        if(continueGame == true)
        {
          time += 1 * Time.deltaTime;
          if(time > 5)
          {
			  saves.NextLevel();
            ///Application.LoadLevel(nextLevel);
          }
        }
    }
    void Count()
    {
         halfOfKilledFakeKubbyies = howManyFakeKubby / 2;

    }
    void Show()
    {
      if(justOpen == false)
      {
        ShowWindow();
      }
      else
      {
        Load();
      }
    }
    void Load()
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
    }
    void ShowWindow()
    {
		GetComponent<JoystickScript>().Victory();
		///saves.SaveCoins();
        txtHealth.text = GetComponent<Health>().health + "%";
        txtFake.text = killedFakeKubby + "/" + howManyFakeKubby;
		Debug.Log("Хп игрока: " + GetComponent<Health>().health + "%, Убито: " + killedFakeKubby + "/" + howManyFakeKubby);
        int randomReaction;
        if(killedFakeKubby == 0)
        {
           fakeKubby.texture = fakeKubbySprites[0];
        }
        if(killedFakeKubby > 0)
        {
          if(killedFakeKubby < halfOfKilledFakeKubbyies)
          {
            randomReaction = Random.Range(1, 2);
            fakeKubby.texture = fakeKubbySprites[randomReaction];
          }
          else if(killedFakeKubby > halfOfKilledFakeKubbyies)
          {

            if(killedFakeKubby == howManyFakeKubby)
            {
              fakeKubby.texture = fakeKubbySprites[4];
            }
            else
            {
              fakeKubby.texture = fakeKubbySprites[3];
            }
          }

        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Finish")
        {
            continueGame = true;
            window.SetActive(true);
            Count();
            ShowWindow();
        }
    }
    public void KillFakeKubby()
    {
         killedFakeKubby += 1;
    }
}
