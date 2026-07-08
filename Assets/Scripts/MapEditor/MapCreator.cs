using UnityEngine;
using System;
using System.IO;
public class MapCreator : MonoBehaviour
{
  public int currentObj = 1;
  public int howManyObj;

  void CreateObject2(string nameVar, string textVar)
  {
    string filePath = "C:/" + "serverFaceYou/" + nameVar; // имя файла
             string text = textVar; // текст для записи в файл

             // открываем файл (стираем содержимое файла)
             using (FileStream fileStream = File.Open(filePath, FileMode.Create))
             {
                  using (StreamWriter output = new StreamWriter(fileStream))
                  {
                       // записываем текст в поток
                       output.Write(text);
                       Debug.Log("some changes was created!");
                  }
             }
  }
  public void CreateObject(string type)
  {
    howManyObj += 1;
    currentObj = howManyObj;
      // Полный путь к папке, которую хотим создать
      // Application.dataPath возвращает путь к папке Assets вашего проекта
      string path = Path.Combine("C:/", "kubbyLevel");

      // Проверяем, существует ли уже такая папка
      if (!Directory.Exists(path))
      {
          // Создаем папку
          Directory.CreateDirectory(path);
          Debug.Log($"Папка создана по пути: {path}");
      }
      else
      {
          Debug.Log($"Папка уже существует по пути: {path}");
      }


      string subFolderPath = Path.Combine(path, Convert.ToString(currentObj));
      if (!Directory.Exists(subFolderPath))
      {
          Directory.CreateDirectory(subFolderPath);
          Debug.Log($"Вложенная папка создана по пути: {subFolderPath}");
          ///CreateObject2(type);
      }
  }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
