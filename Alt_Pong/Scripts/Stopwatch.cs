using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    bool stopwatchActive = false;
    float currTime;
    private TMP_Text currTimeText;

    void Start()
    {
        //init vars
        currTime = 0;
        currTimeText = GetComponent<TMP_Text>();

        //start the stopwatch 2 seconds later with the game
        Invoke("startStopwatch", 2.0f);
    }

    void Update()
    {
        //if the stopwatch has been started, increment the time
        if(stopwatchActive)
            currTime += Time.deltaTime;

        //get the difference in time and display in the text object
        TimeSpan time = TimeSpan.FromSeconds(currTime);
        currTimeText.text = time.Seconds.ToString() + "." + time.Milliseconds.ToString().Substring(0, 1);
    }

    //start the stopwatch
    public void startStopwatch()
    {
        stopwatchActive = true;
    }

    //stop and reset the stopwatch
    public void stopStopwatch()
    {
        currTime = 0;
        currTimeText.text = "0.0";
        stopwatchActive = false;
    }
}