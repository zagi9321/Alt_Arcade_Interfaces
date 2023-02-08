using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlipScreen : MonoBehaviour
{
    private GameObject field;
    int flipped = -1;

    void Start()
    {
        field = GameObject.Find("Field");
        InvokeRepeating("StartFlip", 3.0f, 3.0f);
    }

    void StartFlip()
    {
        int rand = Random.Range(0, 4);

        if(rand == 0)
        {
            field.transform.localScale = new Vector3(-1.0f * field.transform.localScale.x, 1.0f, 1.0f);
            flipped *= -1;
        }

        if(flipped == 1)
            GameObject.Find("InvertText").GetComponent<TMP_Text>().text = "INVERTED";
        else
            GameObject.Find("InvertText").GetComponent<TMP_Text>().text = "";
    }
}