using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC files Archive")]

public class NPC : ScriptableObject
{

    public new string name;
    [TextArea(3, 15)]
    
    public string[] tutorialDialogue;
    [TextArea(3, 15)]

    public string[] dialogue;

}
