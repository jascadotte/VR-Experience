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
        if(tutorialDone) npcDialogueBox.text = npc.dialogue[dialogueCounter];
        else npcDialogueBox.text = npc.tutorialDialogue[dialogueCounter];

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
        dialogueCounter++;

        if (dialogueCounter < npc.tutorialDialogue.Length & !tutorialDone)
        {
            npcDialogueBox.text = npc.tutorialDialogue[dialogueCounter];
        }
        else if (dialogueCounter < npc.dialogue.Length)
        {
            npcDialogueBox.text = npc.dialogue[dialogueCounter];
        }

        if (dialogueCounter >= npc.dialogue.Length - 1)
        {
            tutorialDone = true;
            dialogueCounter = -1;
        }
    }

    public bool getTutorialDone()
    {
        return tutorialDone;
    }

}
