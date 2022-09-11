using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        if (Input.GetKey (KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.DownArrow)) 
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.LeftArrow)) 
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if(Input.GetMouseButton(0))
        { 
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y = 0;
            this.transform.position = pos;
        
        }
    }
}
