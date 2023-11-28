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

public GameObject dialogueUI;
    public GameObject npcNameObject;
    public GameObject npcDialogueObject;
    public Text npcName;
public Text npcDialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    public void StartConversation()
    {
        isTalking = true;
        npcNameObject.SetActive(true);
        npcDialogueObject.SetActive(true);
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];

    }

    public void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
        npcNameObject.SetActive(false);
        npcDialogueObject.SetActive(false);
    }

}
