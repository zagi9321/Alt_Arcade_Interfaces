using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lose : MonoBehaviour
{
    private TMP_Text loseText;

    void Start()
    {
        loseText = GetComponent<TMP_Text>();
    }

    public void DisplayLoseText()
    {
        loseText.text = "theres rats in you;re soup";
    }

    public void Clear()
    {
        loseText.text = "";
    }
}
