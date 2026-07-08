using UnityEngine;
using System;
using System.IO;
public class MapLoader : MonoBehaviour
{
    void Test()
    {
      string filePath = "G:/1.txt"; // имя файла
               string text = "Hello!"; // текст для записи в файл

               // открываем файл (стираем содержимое файла)
               using (FileStream fileStream = File.Open(filePath, FileMode.Create))
               {
                    using (StreamWriter output = new StreamWriter(fileStream))
                    {
                         // записываем текст в поток
                         output.Write(text);
                    }
               }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Test();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
