using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{

    public TextMeshProUGUI text;
    public TImer timer;
    public string code;

    // Start is called before the first frame update
    void Start()
    {
        text.text = code;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.getTimeLeft() <= 300)
        {
    
            float minutes = Mathf.FloorToInt(timer.getTimeLeft() / 60);
            waitNormal(minutes);
            text.text = jumbleCode(code);

            waitJumbled(minutes);
            text.text = code;
        }
    }

    private IEnumerator waitNormal(float minutes)
    {
        yield return new WaitForSecondsRealtime(Random.Range(12f - 5f / ((minutes + 1)/2), 12f));
    }

    private IEnumerator waitJumbled(float minutes)
    {
        yield return new WaitForSecondsRealtime(Random.Range(3f, 3f + 8f / (minutes + 1)));
    }

    private string jumbleCode(string code)
    {
        char[] scrambledCode=new char[code.Length];
        for(int i = 0, j; i < code.Length; i++)
        {
            j = Random.Range(0, code.Length);
            scrambledCode[i] = code[j];
            code = code.Substring(0, j) + code.Substring(j + 1);
        }
        return new string(scrambledCode);
    }


}
