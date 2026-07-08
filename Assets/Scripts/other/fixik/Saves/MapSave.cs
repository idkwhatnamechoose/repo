using UnityEngine;

public class MapSave : MonoBehaviour
{
    public bool inLevel = false;
    string levelName;
    public GameObject[] levelButtons1; //лес
    public GameObject[] levelButtons2; //агросити
    public int completed; //кол-во завершённых уровней
    
    //загрузка карты с сохранёнными лвл
    public void LoadSave() 
    {
        completed = PlayerPrefs.GetInt("completed", 1); // на всякий случай
        renderLvlButtons();
    } 
    //рендер кнопок лвл. чтобы можно было по ним понять, какой уровень уже пройден, а какой нет.
    void renderLvlButtons()
    {
        int rendered = 0;
        while(rendered <= completed)
        {
            
            rendered += 1;
        }
    }
}
