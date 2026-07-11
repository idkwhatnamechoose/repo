using UnityEngine;

public class normalCaveKubbyTarget : MonoBehaviour
{
    public normalCaveKubby caveKubby;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (1 == 1)
        {

        }
    }

    void OnCollisionEnter2D(Collision2D collision)  // Изменено Collider2D на Collision2D
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "CaveKubbyZone")  // Добавлено .gameObject
        {
            Debug.Log("пещерный кубби в зоне");
            caveKubby.isWorking = false;
        }
    }
}