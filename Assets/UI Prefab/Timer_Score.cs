using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer_Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score;
    public TextMeshProUGUI clockText;
    public float clockTime;
    // Start is called before the first frame update
    void Start()
    {
      setClockText();
      setScoreText();
    }
    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void setClockText()
    {
        float t = Time.timeSinceLevelLoad; //scene loaded

        int seconds = (int)(t % 60);// return remainder of seconds/60 as an it
        t /= 60; //minutes
        int minutes = (int)(t % 60);//remainder of minutes
        t /= 60;//hours
        int hours = (int)(t % 60);//remainder of hours
        clockText.text = string.Format("{0}:{1}:{2}",
           hours.ToString("00"), minutes.ToString("00"), seconds.ToString("00"));
    }

    // Update is called once per frame
    void Update()
    {
       setClockText();
       setScoreText();
    }
    
}
