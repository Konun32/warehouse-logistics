using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveir1 : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Material mt;
    public float direction;
    // Start is called before the first frame update
    void FixedUpdate()
    {

        mt.mainTextureOffset = new Vector2(Time.time * 10 * Time.deltaTime, 0f);
        Vector3 pos = rb.position;
        rb.position += Vector3.right * speed * direction * Time.fixedDeltaTime;
        rb.MovePosition(pos);
        
    }
}