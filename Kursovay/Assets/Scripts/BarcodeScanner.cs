using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class BarcodeScanner : MonoBehaviour
{
    List<Move1ForwardAndBack> moveComponents = new List<Move1ForwardAndBack>();
    List<Move2ForwardAndBack> move2Components = new List<Move2ForwardAndBack>();
    List<Move3ForwardAndBack> move3Components = new List<Move3ForwardAndBack>();
    int i = 0;
    int bk = 3;
    // Путь к исполняемому файлу Python
    string pythonPath = "python";
    // Путь к Python-скрипту
    string scriptPath = "C:/Users/LexaD/Documents/Kursovay/read.py";
    // Путь для сохранения фотографии
    string imagePath = "C:/Users/LexaD/Documents/Kursovay/img/image.png";
    // Путь к файлу с результатом
    string resultFilePath = "C:/Users/LexaD/Documents/Kursovay/result.txt";
    
    // Публичное поле для привязки камеры в Unity
    public Camera cameraToUse;

    void Start()
    {
        GameObject playerCamera = GameObject.FindGameObjectWithTag("Player");
        if (playerCamera != null)
        {
            cameraToUse = playerCamera.GetComponent<Camera>();
        }
        else
        {
            print("Камера с тегом 'Player' не найдена. Убедитесь, что камера имеет правильный тег.");
        }
        // Находим все объекты с компонентом Move1ForwardAndBack и сохраняем их в списке
        Move1ForwardAndBack[] foundComponents = FindObjectsOfType<Move1ForwardAndBack>();
        moveComponents.AddRange(foundComponents);

        Move2ForwardAndBack[] found2Components = FindObjectsOfType<Move2ForwardAndBack>();
        move2Components.AddRange(found2Components);

        Move3ForwardAndBack[] found3Components = FindObjectsOfType<Move3ForwardAndBack>();
        move3Components.AddRange(found3Components);
    }

    void Update()
    {
        //блокируем камеру
        Camera additionalCamera = cameraToUse.GetComponent<Camera>();
        additionalCamera.enabled = false;

        if(transform.position.x >= -71f && transform.position.x <= -70.7f && i == 0)
        {
            i = 1;
            TakePhoto();
        }
        if(transform.position.x >= -79 && transform.position.x <= -75.5f && i == 1)
        {
            i = 0;
        }
        if(transform.position.x >= -85 && transform.position.x <= -82.5f && bk == 1)
        {
            //moveComponent.enabled = true;
            Scr1();
        }
        else if(transform.position.x >= -110 && transform.position.x <= -107.7f && bk == 2)
        {
            //moveComponent.enabled = true;
            Scr2();
        }
        else if(transform.position.x >= -136 && transform.position.x <= -132.8f && bk == 3)
        {
            //moveComponent.enabled = true;
            Scr3();
        }
        // Проверяем нажатие на клавишу пробел
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            // Запускаем съемку фотографии
            TakePhoto();
        }*/
    }

    void Scr1()
    {
        // Изменяем score во всех объектах Move1ForwardAndBack
        foreach (Move1ForwardAndBack moveComponent in moveComponents)
        {
            bk = 0;
            moveComponent.enabled = true;
            moveComponent.movementCount = 0;
            moveComponent.score = 1;
        }
    }

    void Scr2()
    {
        // Изменяем score во всех объектах Move2ForwardAndBack
        foreach (Move2ForwardAndBack moveComponent in move2Components)
        {
            bk = 0;
            moveComponent.enabled = true;
            moveComponent.movementCount = 0;
            moveComponent.score = 1;
        }
    }

    void Scr3()
    {
        // Изменяем score во всех объектах Move3ForwardAndBack
        foreach (Move3ForwardAndBack moveComponent in move3Components)
        {
            bk = 0;
            moveComponent.enabled = true;
            moveComponent.movementCount = 0;
            moveComponent.score = 1;
        }
    }

    void TakePhoto()
    {
        // Создаем временный рендер-текстур для сохранения снимка экрана
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraToUse.targetTexture = renderTexture;
        Texture2D photo = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        cameraToUse.Render();
        RenderTexture.active = renderTexture;
        photo.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        cameraToUse.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        //additionalCamera.enabled = true;

        // Сохраняем фотографию на диск
        byte[] bytes = photo.EncodeToPNG();
        File.WriteAllBytes(imagePath, bytes);

        // Запускаем Python-скрипт для обработки фотографии
        //print(1);
        Process process = new Process();
        process.StartInfo.FileName = pythonPath;
        process.StartInfo.Arguments = scriptPath;// + " " + imagePath;
        // Выводим команду в консоль Unity
        //print("Command: " + process.StartInfo.FileName + " " + process.StartInfo.Arguments);
        process.StartInfo.UseShellExecute = false;
        //process.StartInfo.RedirectStandardOutput = true; // Перенаправляем вывод командной строки
        process.Start();
        //print(2);//---------------

        // Получаем вывод командной строки
        //string output = process.StandardOutput.ReadToEnd();


        // Ожидаем завершения выполнения Python-скрипта
        process.WaitForExit();

        // Выводим результат в консоль Unity
        //print(output);

        // Читаем результат обработки фотографии из файла
        string result = File.ReadAllText(resultFilePath);

        // Результат обработки штрихкода
        //Debug.Log(result);
        //print(5);//---------------

        // Отправляем сигнал в Unity
        ProcessUnitySignal(result);
    }

    void ProcessUnitySignal(string result)
    {
        // Обработка полученного сигнала в Unity
        // Добавьте необходимый код для выполнения действий в Unity на основе результата
        Renderer renderer = GetComponent<Renderer>();

        if (result == "1234567891026")
        {
            bk = 1;
            print("1234567891026");
        }
        else if (result == "2345678910212")
        {
            bk = 2;
            print("2345678910212");
        }
        else if (result == "3456789102126")
        {
            bk = 3;
            print("3456789102126");
        }
        else
        {
            print("Ха лох");
        }
    }
}

