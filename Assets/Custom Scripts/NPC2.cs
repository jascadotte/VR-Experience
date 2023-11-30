using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NPC file 2", menuName = "NPC files Exit")]

public class NPC2 : ScriptableObject
{

    public new string name;
    [TextArea(3, 15)]
    
    public string[] exitDialogue;
    [TextArea(3, 15)]

    public string[] dialogue;

}
