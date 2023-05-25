using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAndBack : MonoBehaviour
{
    public float distance = 5f;
    public float speed = 1f;
    public Transform[] objectsToPush;
    public Vector3 targetPosition;
    private Vector3 startPosition;
    private bool movingBack = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (System.IO.File.Exists("result.txt") && System.IO.File.ReadAllText("result.txt").Contains("1"))
        {
            if (movingBack)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
                foreach (Transform objectToPush in objectsToPush)
                {
                    if (Vector3.Distance(objectToPush.position, targetPosition) <= 0.1f)
                    {
                        continue;
                    }
                    objectToPush.position += transform.forward * speed * Time.deltaTime;
                }
                if (Vector3.Distance(transform.position, startPosition) >= distance)
                {
                    movingBack = false;
                }
            }
            else
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                foreach (Transform objectToPush in objectsToPush)
                {
                    if (Vector3.Distance(objectToPush.position, targetPosition) <= 0.1f)
                    {
                        continue;
                    }
                    objectToPush.position -= transform.forward * speed * Time.deltaTime;
                }
                if (Vector3.Distance(transform.position, startPosition) <= 0.1f)
                {
                    movingBack = true;
                }
            }
        }
    }
}