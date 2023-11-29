using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class gameManager : MonoBehaviour
{
    /// <summary>
    /// The max amount of books the player must get (>=1)
    /// </summary>
    public int maxScore;
    /// <summary>
    /// The number of books a player got
    /// </summary>
    private int score;
    /// <summary>
    /// Timer object
    /// </summary>
    public TImer timer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for new books
        checkBook();
        ///Check Win
        checkWin();
    }

    /// <summary>
    /// Checks if the number of books has exceeded its maximum and disables the timer if it does.
    /// </summary>
    private void checkWin()
    {
        if (score >= maxScore)
        {
            timer.DisableTimer();
        }
    }
    /// <summary>
    /// The socket player put the books in
    /// </summary>
    [SerializeField, Tooltip("The Socket that should be checked for books.")]
    private XRSocketInteractor socket;
    /// <summary>
    /// Increases score if the player found a book, and then disables the book
    /// </summary>
    private void checkBook()
    {
        if (socket.hasSelection)
        {
            score++;
            GameObject book = socket.GetOldestInteractableSelected().transform.gameObject;
            book.SetActive(false);
            Debug.Log("score got!");
        }
    }

    /// <summary>
    /// Sets number of books player has found so far
    /// </summary>
    public void setScore(int score)
    {
        this.score = score;
    }
    /// <summary>
    /// Gets number of books player has found so far
    /// </summary>
    public int getScore()
    {
        return score;
    }
}
