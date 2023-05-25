using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randombox : MonoBehaviour
{
    public GameObject[] boxes;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
        
    {
        if (Input.GetMouseButtonDown(0))
        {
            int randomnumber = Random.Range(0, boxes.Length);
            Instantiate(boxes[randomnumber],transform.position,Quaternion.identity);
        }
    }
}
