using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreChanger : MonoBehaviour
{
    TMP_Text textReference;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        textReference = GetComponent<TMP_Text>();
    }

    public void AddScore()
    {
        score++;
        textReference.text = score.ToString();  
    }
}
