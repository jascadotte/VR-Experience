using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

public NPC npc;


public GameObject dialogueUI;
    public GameObject npcNameObject;
    public GameObject npcDialogueObject;
    public Text npcName;
public Text npcDialogueBox;

    private bool tutorialDone = false;
    private bool gameDone = false;
    /// <summary>
    /// Counter that keeps track of which dialogue option the player sees. 0 is the first one and the subsequent numbers are subsequent dialogues
    /// </summary>
    private int dialogueCounter=0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    public void StartConversation()
    {
        npcNameObject.SetActive(true);
        npcDialogueObject.SetActive(true);
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        dialogueCounter = 0;
        NextDialogue();

    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        npcNameObject.SetActive(false);
        npcDialogueObject.SetActive(false);
    }
    /// <summary>
    /// updates textbox with next dialogue. Triggered when player selects while close to the npc
    /// </summary>
    public void NextDialogue()
    {
        if (gameDone)
        {
            if (dialogueCounter >= npc.finishedDialogue.Length) dialogueCounter = 0;
            npcDialogueBox.text = npc.finishedDialogue[dialogueCounter];
            
        }
        else if (tutorialDone)
        {
            if (dialogueCounter >= npc.dialogue.Length) dialogueCounter = 0;
            npcDialogueBox.text = npc.dialogue[dialogueCounter];
        }
        else
        {

            npcDialogueBox.text = npc.tutorialDialogue[dialogueCounter];
        }

        dialogueCounter++;
        if (dialogueCounter >= npc.tutorialDialogue.Length & !tutorialDone)
        {
            tutorialDone = true;
            dialogueCounter = 0;
        }
    }

    public bool getTutorialDone()
    {
        return tutorialDone;
    }

    public void gameFinished()
    {
        gameDone = true;
    }
}
