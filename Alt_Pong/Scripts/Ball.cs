using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
/*    [SerializeField] [Range(3, 15)] */private float hspeed = 2f;
/*    [SerializeField] [Range(-3, 3)] */private float vspeed = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Kickoff", 1.5f);
    }

    //start the ball
    void Kickoff()
    {
        rb.velocity = new Vector2(hspeed, vspeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //ball hits right of player paddle
        if(col.tag == "paddlePlayerRight")
        {
            //if ball is moving left, flip vertical direction
            if(hspeed < 0)
                hspeed *= -1.0f;

            //if ball is moving right, increase hspeed
            else
                hspeed += 1.0f;

            //switch direction
            vspeed = Mathf.Abs(vspeed);

            //set new velocity
            rb.velocity = new Vector2(hspeed, vspeed);

            //increase speed
            vspeed += 0.4f;

            //play sound
            GameObject.Find("Paddle_Player").GetComponent<AudioSource>().Play();

            return;
        }

        //if ball hits middle of player paddle
        if(col.tag == "paddlePlayerMiddle")
        {
            //if ball is moving right, reduce horizontal angle
            if(hspeed > 2.0f)
                hspeed -= 1.0f;

            //if ball is moving left, reduce vertical angle
            if(hspeed < -2.0f)
                hspeed += 1.0f;

            //switch direction
            vspeed = Mathf.Abs(vspeed);

            //set new velocity
            rb.velocity = new Vector2(hspeed, vspeed);

            //increase speed
            vspeed += 0.4f;

            //play sound
            GameObject.Find("Paddle_Player").GetComponent<AudioSource>().Play();

            return;
        }

        //if ball hits left of player paddleLe
        if(col.tag == "paddlePlayerLeft")
        {
            //if ball is moving right, switch horizontal direction
            if(hspeed > 0)
                hspeed *= -1.0f;

            //if ball is moving left, increase hspeed
            else
                hspeed -= 1.0f;

            //switch direction
            vspeed = Mathf.Abs(vspeed);

            //set new velocity
            rb.velocity = new Vector2(hspeed, vspeed);

            //increase speed
            vspeed += 0.4f;

            //play sound
            GameObject.Find("Paddle_Player").GetComponent<AudioSource>().Play();

            return;
        }

        //if ball hits wall
        if(col.tag == "Wall")
        {
            //flip horizontal direction
            hspeed *= -1.0f;

            //set new velocity
            rb.velocity = new Vector2(hspeed, vspeed);

            //play sound
            GameObject.Find("WallLeft").GetComponent<AudioSource>().Play();

            return;
        }

        //if ball reaches the top of the screen
        if(col.tag == "ceiling")
        {
            //flip vertical direction
            vspeed *= -1.0f;

            //set new velocity
            rb.velocity = new Vector2(hspeed, vspeed);

            //play sound
            GameObject.Find("Ceiling").GetComponent<AudioSource>().Play();

            return;
        }

        //if the ball reaches the bottom of screen
        if(col.tag == "goal")
        {
            //lose the game
            Lose();
            return;
        }
    }

    //when the ball reaches a goal
    void Lose()
    {
        Debug.Log("you lose");

        //put the ball in the middle with no speed
        transform.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);

        //stop the stopwatch
        GameObject.Find("Stopwatch").GetComponent<Stopwatch>().stopStopwatch();

        //display lose text
        GameObject.Find("LoseText").GetComponent<Lose>().DisplayLoseText();

        //play sound
        GameObject.Find("Bottom").GetComponent<AudioSource>().Play();
        GameObject.Find("Ball").GetComponent<AudioSource>().Play();
        GameObject.Find("DeathMessage").GetComponent<AudioSource>().Play();

        //call reset function one second later
        Invoke("Reset", 2.0f);
    }

    //reset the playing field after a score
    void Reset()
    {
        //reset the speed to default
        hspeed = 2f;
        vspeed = 3f;
        rb.velocity = new Vector2(hspeed, vspeed);

        //reorient screen if necessary
        GameObject.Find("Field").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //reset inverted text if necessary
        GameObject.Find("InvertText").GetComponent<TMP_Text>().text = "";

        //restart the stopwatch
        GameObject.Find("Stopwatch").GetComponent<Stopwatch>().startStopwatch();

        //clear the lose text
        GameObject.Find("LoseText").GetComponent<Lose>().Clear();
    }
}