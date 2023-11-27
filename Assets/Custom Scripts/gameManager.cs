using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gameManager : MonoBehaviour
{
    /// <summary>
    /// The max amount of books the player must get (>=1)
    /// </summary>
    public int winScore;
    private int score;
    public UnityEvent maxScoreReached;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= winScore)
        {
            maxScoreReached.Invoke();
        }
    }

    public void incrament()
    {
        score++;
    }
    public void decrament()
    {
        score--;
    }
}
