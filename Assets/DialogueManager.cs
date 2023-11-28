using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

public NPC npc;

bool isTalking = false;

float distance;
// float currentResponseTracker = 0;

public GameObject player;
public GameObject dialogueUI;

private Transform GameObject;
private Transform DialogueManager;

public Text npcName;
public Text npcDialogueBox;
public Text playerResponse;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.postion, this.transform.postion);
        if (distance <= 2.5f)
        {
            if(Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }
        }
    }

    void StartConversation()
    {
        isTalking = true;
        // currentResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];

    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

}
