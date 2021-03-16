using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    //README ---> Add this

    private Text textObj;
    private string story;

    private void Awake()
    {
        textObj = GetComponent<Text>();
        story = textObj.text;

        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        { 
            textObj.text += c;
            yield return new WaitForSeconds(0.01f);
        }
    }

}
