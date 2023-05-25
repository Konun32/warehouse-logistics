using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Move1ForwardAndBack : MonoBehaviour
{
    public float distance = 5f;
    public float speed = 1f;
    private Vector3 startPosition;
    private bool movingBack = true;
    public int score = 4;


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingBack)
        {
            if (score == 1) 
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
                if (Vector3.Distance(transform.position, startPosition) >= distance)
                {
                    movingBack = false;
                }
            }
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, startPosition) <= 0.1f)
            {
                movingBack = true;
            }
            score = 4;
        }
    }
}*/

public class Move1ForwardAndBack : MonoBehaviour
{
    public int score = 4;
    public float distance = 5f;
    public float speed = 1f;
    private Vector3 startPosition;
    private bool movingBack = true;
    public int movementCount = 0; // Дополнительная переменная для отслеживания количества циклов движения

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingBack)
        {
            if (score == 1) 
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
                if (Vector3.Distance(transform.position, startPosition) >= distance)
                {
                    movingBack = false;
                    movementCount++; // Увеличиваем количество выполненных циклов движения
                }
            }
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, startPosition) <= 0.1f)
            {
                movingBack = true;
                movementCount++;
                score = 4;
            }
        }

        // Остановить объект после определенного количества циклов движения
        int maxMovements = 2; // Задайте желаемое количество циклов движения

        if (movementCount >= maxMovements)
        {
            enabled = false; // Отключаем компонент Move1ForwardAndBack
        }
    }
}
