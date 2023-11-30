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
        StartCoroutine(change());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator change()
    {
        if (timer.getTimeLeft() <= 300)
        {
            Debug.Log("test1");
            float minutes = Mathf.FloorToInt(timer.getTimeLeft() / 60);
            Debug.Log(minutes);
            yield return new WaitForSecondsRealtime(5);
            Debug.Log("jumbling code");
            text.text = jumbleCode(code);
            Debug.Log("jumbling code successful");
            yield return new WaitForSecondsRealtime(5);
            Debug.Log("unjumbling code successful");
            text.text = code;
        }
        StartCoroutine(change());
    }


    private string jumbleCode(string code)
    {
        char[] scrambledCode=new char[code.Length];
        int startingLength = code.Length;
        for(int i = 0, j; i < startingLength; i++)
        {
            j = Random.Range(0, code.Length);
            scrambledCode[i] = code[j];
            code = code.Substring(0, j) + code.Substring(j + 1);
        }
        return new string(scrambledCode);
    }


}
