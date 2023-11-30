using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TImer : MonoBehaviour
{
    public float TimeLimit;
    private float TimeLeft;
    private bool TimerOn = false;
    public TextMeshProUGUI timeTextBox;
    public DialogueManager dialogue;

    public UnityEvent TimerExpired;


    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            TimeLeft -= Time.deltaTime;
            if(TimeLeft <= 0)
            {
                TimerExpired.Invoke();
                TimeLeft = 0;
                TimerOn = false;
            }
            updateTimer(TimeLeft);
        }
    }

    private void updateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeTextBox.text = string.Format("{0:0}: {1:00}", minutes, seconds);
    }

    public void EnableTimer()
    {
        if (dialogue.getTutorialDone())
        { TimerOn = true; }
    }
    public void DisableTimer()
    {
        TimerOn = false;
    }

    public float getTimeLeft()
    {
        return TimeLeft;
    }


}
