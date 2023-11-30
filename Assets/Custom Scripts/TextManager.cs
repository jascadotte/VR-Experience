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
        text.fontStyle = FontStyles.Bold;
        StartCoroutine(change());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator change()
    {
        if (timer.getTimeLeft() <= 240)
        {
            float minutes = Mathf.FloorToInt(timer.getTimeLeft() / 60);

            yield return new WaitForSecondsRealtime(Random.Range(9f-(5-minutes),10f));
            text.text = jumbleCode(code);

            yield return new WaitForSecondsRealtime(Random.Range(3f, 4f+(5-minutes)));
            text.text = code;
        }
        yield return new WaitForSecondsRealtime(1);
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
