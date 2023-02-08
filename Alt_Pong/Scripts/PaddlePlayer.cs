using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class PaddlePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] [Range(5, 15)] private float speed = 5f;

    SerialPort stream = new SerialPort ("/dev/cu.usbmodem11101", 9600);
    int buttonValue = 0;
    string value;

    void Start()
    {
        stream.Open();
        stream.ReadTimeout = 100;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(stream.IsOpen)
        {
            try
            {
                value = stream.ReadLine();
                buttonValue = int.Parse(value);
            }
            catch(System.Exception){}
        }

        //move left
        if(buttonValue == 1 || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-1f * speed * GameObject.Find("Field").transform.localScale.x, 0);
        }

        //move right
        if(buttonValue == 2 || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed * GameObject.Find("Field").transform.localScale.x, 0);
        }

        //stop moving
        if(buttonValue == 0 || Input.GetKeyUp(KeyCode.LeftArrow))
            rb.velocity = new Vector2(0, 0);

        //stop moving
        if(Input.GetKeyUp(KeyCode.RightArrow))
            rb.velocity = new Vector2(0, 0);
    }
}